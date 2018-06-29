using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System.Threading.Tasks;

namespace Roc.CMS.Content
{
    public interface ICategoryAppService : IApplicationService
    {
        /// <summary>
        /// 活动分类列表（带分页）
        /// </summary>
        /// <param name="input">输入参数</param>
        /// <returns></returns>
        Task<PagedResultDto<CategoryListDto>> GetCategories(CategoryListInput input);

        /// <summary>
        /// 添加或修改分类
        /// </summary>
        /// <param name="input">分类实体</param>
        /// <returns></returns>
        Task CreateOrUpdateCategory(CategoryDto input);

        /// <summary>
        /// 获得分类
        /// </summary>
        /// <param name="id">分类ID</param>
        /// <returns></returns>
        Task<CategoryCreateOrEditOutput> GetCategoryForEdit(CategoryGetDto id);

        /// <summary>
        /// 删除分类
        /// </summary>
        /// <param name="id">分类ID</param>
        /// <returns></returns>
        Task DeleteCategory(int id);
    }
}
