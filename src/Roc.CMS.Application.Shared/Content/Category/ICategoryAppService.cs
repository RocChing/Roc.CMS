using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System.Threading.Tasks;

namespace Roc.CMS.Content
{
    public interface ICategoryAppService : IApplicationService
    {
        Task<PagedResultDto<CategoryListDto>> GetCategories(CategoryListInput input);

        Task CreateOrUpdateCategory(CategoryDto input);

        Task<CategoryCreateOrEditOutput> GetCategoryForEdit(NullableIdDto id);
    }
}
