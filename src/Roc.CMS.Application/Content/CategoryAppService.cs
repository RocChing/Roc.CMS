using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Roc.CMS.Content;
using Abp.Domain.Repositories;
using Abp.Authorization;
using Abp.Linq.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using Roc.CMS.Authorization;
using Abp.Organizations;
using Abp.UI;

namespace Roc.CMS.Content
{
    [AbpAuthorize(AppPermissions.Pages_Contents_Category)]
    public class CategoryAppService : AbpZeroTemplateAppServiceBase, ICategoryAppService
    {
        private readonly IRepository<Category> _repository;
        public CategoryAppService(IRepository<Category> repository)
        {
            _repository = repository;
        }

        public async Task<PagedResultDto<CategoryListDto>> GetCategories(CategoryListInput input)
        {
            CheckPermission(AppPermissions.Pages_Contents_Category_Query);

            string filter = input.Filter;
            string parentCode = input.ParentCode;
            var query = _repository.GetAll()
                .WhereIf(!string.IsNullOrEmpty(filter), a => a.Name.Contains(filter) || a.Remark.Contains(filter) || a.Code.Contains(filter))
                .WhereIf(!string.IsNullOrEmpty(parentCode), a => a.Code.Contains(parentCode));

            var myQuery = from a in query
                          join b in _repository.GetAll() on a.ParentId equals b.Id
                          into ab
                          from c in ab.DefaultIfEmpty()
                          select new
                          {
                              a.Id,
                              a.Name,
                              a.ParentId,
                              a.Target,
                              a.URL,
                              a.IsNav,
                              a.IsSpecial,
                              a.SortId,
                              ParentName = c.Name
                          };

            int count = await myQuery.CountAsync();
            var categories = await myQuery.OrderBy(input.Sorting).PageBy(input).ToListAsync();

            return new PagedResultDto<CategoryListDto>(count, ObjectMapper.Map<List<CategoryListDto>>(categories));
        }

        [AbpAuthorize(AppPermissions.Pages_Contents_Category_Create, AppPermissions.Pages_Contents_Category_Edit)]
        public async Task CreateOrUpdateCategory(CategoryDto input)
        {
            Category category;

            if (!input.Id.HasValue)
            {
                category = ObjectMapper.Map<Category>(input);
                category.TenantId = AbpSession.TenantId;
                category.Code = await GetNextChildCodeAsync(input.ParentId);
            }
            else
            {
                category = await _repository.GetAsync(input.Id.Value);
                if (category == null)
                {
                    throw new UserFriendlyException(L("Content.Category.NotFound"));
                }
                ObjectMapper.Map(input, category);
            }
            await _repository.InsertOrUpdateAsync(category);
        }

        [AbpAuthorize(AppPermissions.Pages_Contents_Category_Create, AppPermissions.Pages_Contents_Category_Edit)]
        public async Task<CategoryCreateOrEditOutput> GetCategoryForEdit(CategoryGetDto dto)
        {
            Category category;
            bool editMode = false;
            if (dto.Id.HasValue)
            {
                category = await _repository.GetAsync(dto.Id.Value);
                editMode = true;
            }
            else
            {
                category = new Category();
            }

            CategoryLevelListInput input = new CategoryLevelListInput()
            {
                UseCodeValue = dto.UseCodeValue,
                SelectedValue = dto.UseCodeValue ? category.Code : category.Id.ToString()
            };

            var categories = await GetLevelCategories(input);

            return new CategoryCreateOrEditOutput()
            {
                IsEditMode = editMode,
                Category = ObjectMapper.Map<CategoryDto>(category),
                Categories = categories,
                Targets = GetCategroyTargets(category.Target)
            };
        }

        [AbpAuthorize(AppPermissions.Pages_Contents_Category_Delete)]
        public async Task DeleteCategory(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<List<ComboboxItemDto>> GetLevelCategories(CategoryLevelListInput input)
        {
            List<ComboboxItemDto> items = new List<ComboboxItemDto>();
            var categories = await _repository.GetAllListAsync();
            categories = categories.ToList();

            AppendCategroy(0, 1, input, categories, items);

            return items;
        }

        #region 私有方法
        private async Task<string> GetNextChildCodeAsync(int parentId)
        {
            var lastChild = await GetLastChildOrNullAsync(parentId);
            if (lastChild == null)
            {
                var parentCode = parentId > 0 ? await GetCodeAsync(parentId) : null;
                return OrganizationUnit.AppendCode(parentCode, OrganizationUnit.CreateCode(1));
            }

            return OrganizationUnit.CalculateNextCode(lastChild.Code);
        }

        private async Task<Category> GetLastChildOrNullAsync(long parentId)
        {
            var children = await _repository.GetAllListAsync(m => m.ParentId == parentId);
            return children.OrderBy(c => c.Code).LastOrDefault();
        }

        private async Task<string> GetCodeAsync(int id)
        {
            return (await _repository.GetAsync(id)).Code;
        }

        private List<ComboboxItemDto> GetCategroyTargets(CategoryTarget target)
        {
            var blank = CategoryTarget.BLANK;
            var self = CategoryTarget.SELF;

            List<ComboboxItemDto> list = new List<ComboboxItemDto>();
            ComboboxItemDto blankItem = new ComboboxItemDto(((int)blank).ToString(), blank.ToString() + "(新开页面)");
            ComboboxItemDto selfItem = new ComboboxItemDto(((int)self).ToString(), self.ToString() + "(本页面)");
            if (target == blank)
            {
                blankItem.IsSelected = true;
            }
            else if (target == self)
            {
                selfItem.IsSelected = true;
            }
            list.Add(blankItem);
            list.Add(selfItem);
            return list;
        }

        private string GetFormatName(string code, string name)
        {
            if (string.IsNullOrEmpty(code)) return name;
            int level = code.Split('.').Length;

            return new string('-', level * 2) + name;
        }

        private void AppendCategroy(int pid, int level, CategoryLevelListInput input, List<Category> categories, List<ComboboxItemDto> items)
        {
            var list = categories.Where(m => m.ParentId == pid).OrderBy(m => m.SortId);
            string blank = "";
            for (int i = 0; i < level; i++)
            {
                blank += input.Repeat;
            }
            blank += input.Pre;

            foreach (var item in list)
            {
                string value = input.UseCodeValue ? item.Code : item.Id.ToString();
                string text = blank + item.Name;
                items.Add(new ComboboxItemDto(value, text) { IsSelected = value == input.SelectedValue });
                AppendCategroy(item.Id, level + 1, input, categories, items);
            }
        }

        #endregion
    }
}
