using System;
using System.Linq;
using Abp.Organizations;
using Roc.CMS.Authorization.Roles;
using Roc.CMS.MultiTenancy;

namespace Roc.CMS.EntityHistory
{
    public static class EntityHistoryHelper
    {
        public static readonly Type[] TrackedTypes =
            HostSideTrackedTypes
                .Concat(TenantSideTrackedTypes)
                .GroupBy(type=>type.FullName)
                .Select(types=>types.First())
                .ToArray();

        public static readonly Type[] HostSideTrackedTypes =
        {
            typeof(OrganizationUnit), typeof(Role), typeof(Tenant)
        };

        public static readonly Type[] TenantSideTrackedTypes =
        {
            typeof(OrganizationUnit), typeof(Role)
        };
    }
}
