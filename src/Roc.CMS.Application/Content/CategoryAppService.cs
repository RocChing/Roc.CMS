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
        //protected override string CreatePermissionName { get => AppPermissions.Pages_Contents_Category_Create; }
        //protected override string UpdatePermissionName { get => AppPermissions.Pages_Contents_Category_Edit; }
        //protected override string DeletePermissionName { get => AppPermissions.Pages_Contents_Category_Delete; }

        public async Task<PagedResultDto<CategoryListDto>> GetCategories(CategoryListInput input)
        {
            CheckPermission(AppPermissions.Pages_Contents_Category_Query);

            string filter = input.Filter;
            var query = _repository.GetAll()
                .WhereIf(!string.IsNullOrEmpty(filter), a => a.Name.Contains(filter) || a.Remark.Contains(filter) || a.Code.Contains(filter))
                .WhereIf(input.ParentId.HasValue, a => a.ParentId == input.ParentId.Value);

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
                              ParentName = c.Name
                          };

            int count = await myQuery.CountAsync();
            var categories = await myQuery.OrderBy(input.Sorting).PageBy(input).ToListAsync();

            return new PagedResultDto<CategoryListDto>(count, ObjectMapper.Map<List<CategoryListDto>>(categories));
        }

        [AbpAuthorize(AppPermissions.Pages_Contents_Category_Create, AppPermissions.Pages_Contents_Category_Edit)]
        public async Task CreateOrUpdateCategory(CategoryDto input)
        {
            var category = ObjectMapper.Map<Category>(input);
            category.TenantId = AbpSession.TenantId;
            if (category.IsTransient())
            {
                category.Code = await GetNextChildCodeAsync(input.ParentId);
            }
            await _repository.InsertOrUpdateAsync(category);
        }

        [AbpAuthorize(AppPermissions.Pages_Contents_Category_Create, AppPermissions.Pages_Contents_Category_Edit)]
        public async Task<CategoryCreateOrEditOutput> GetCategoryForEdit(NullableIdDto dto)
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

            var categories = from item in _repository.GetAll()
                             orderby new { item.ParentId, item.Id }
                             select new ComboboxItemDto(item.Id.ToString(), GetFormatName(item.Code, item.Name));

            return new CategoryCreateOrEditOutput()
            {
                IsEditMode = editMode,
                Category = ObjectMapper.Map<CategoryDto>(category),
                Categories = categories.ToList(),
                Targets = GetCategroyTargets()
            };
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

        private List<ComboboxItemDto> GetCategroyTargets()
        {
            var blank = CategoryTarget.BLANK;
            var self = CategoryTarget.SELF;

            List<ComboboxItemDto> list = new List<ComboboxItemDto>();
            list.Add(new ComboboxItemDto(((int)blank).ToString(), blank.ToString()+"(新开页面)"));
            list.Add(new ComboboxItemDto(((int)self).ToString(), self.ToString()+"(本页面)"));
            return list;
        }

        private string GetFormatName(string code, string name)
        {
            if (string.IsNullOrEmpty(code)) return name;
            int level = code.Split('.').Length;

            return new string('-', level * 2) + name;
        }
        #endregion
    }
}
