using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Roc.CMS.Content;
using Abp.Domain.Repositories;
using Abp.Authorization;
using Roc.CMS.Authorization;

namespace Roc.CMS.Content
{
    [AbpAuthorize(AppPermissions.Pages_Contents_Category)]
    public class CategoryAppService : AsyncCrudAppService<Category, CategoryDto>
    {
        public CategoryAppService(IRepository<Category> repository) : base(repository)
        {

        }

        protected override string GetPermissionName { get => AppPermissions.Pages_Contents_Category_Query; }

        protected override string GetAllPermissionName { get => AppPermissions.Pages_Contents_Category_Query; }

        protected override string CreatePermissionName { get => AppPermissions.Pages_Contents_Category_Create; }

        protected override string UpdatePermissionName { get => AppPermissions.Pages_Contents_Category_Edit; }

        protected override string DeletePermissionName { get => AppPermissions.Pages_Contents_Category_Delete; }


    }
}
