using Abp.Application.Navigation;
using Abp.Localization;
using Roc.CMS.Authorization;

namespace Roc.CMS.Web.Areas.Sys.Startup
{
    public class SysNavigationProvider : NavigationProvider
    {
        public const string MenuName = "App";

        public override void SetNavigation(INavigationProviderContext context)
        {
            var menu = context.Manager.Menus[MenuName] = new MenuDefinition(MenuName, new FixedLocalizableString("Main Menu"));

            menu
                .AddItem(new MenuItemDefinition(
                        SysPageNames.Host.Dashboard,
                        L("Dashboard"),
                        url: "Sys/HostDashboard",
                        icon: "flaticon-line-graph",
                        requiredPermissionName: AppPermissions.Pages_Administration_Host_Dashboard
                    )
                ).AddItem(new MenuItemDefinition(
                    SysPageNames.Host.Tenants,
                    L("Tenants"),
                    url: "Sys/Tenants",
                    icon: "flaticon-list-3",
                    requiredPermissionName: AppPermissions.Pages_Tenants
                    )
                ).AddItem(new MenuItemDefinition(
                        SysPageNames.Host.Editions,
                        L("Editions"),
                        url: "Sys/Editions",
                        icon: "flaticon-app",
                        requiredPermissionName: AppPermissions.Pages_Editions
                    )
                ).AddItem(new MenuItemDefinition(
                        SysPageNames.Tenant.Dashboard,
                        L("Dashboard"),
                        url: "Sys/Dashboard",
                        icon: "flaticon-line-graph",
                        requiredPermissionName: AppPermissions.Pages_Tenant_Dashboard
                    )
                ).AddItem(new MenuItemDefinition(
                        SysPageNames.Common.Administration,
                        L("Administration"),
                        icon: "flaticon-interface-8"
                    ).AddItem(new MenuItemDefinition(
                            SysPageNames.Common.OrganizationUnits,
                            L("OrganizationUnits"),
                            url: "Sys/OrganizationUnits",
                            icon: "flaticon-map",
                            requiredPermissionName: AppPermissions.Pages_Administration_OrganizationUnits
                        )
                    ).AddItem(new MenuItemDefinition(
                            SysPageNames.Common.Roles,
                            L("Roles"),
                            url: "Sys/Roles",
                            icon: "flaticon-suitcase",
                            requiredPermissionName: AppPermissions.Pages_Administration_Roles
                        )
                    ).AddItem(new MenuItemDefinition(
                            SysPageNames.Common.Users,
                            L("Users"),
                            url: "Sys/Users",
                            icon: "flaticon-users",
                            requiredPermissionName: AppPermissions.Pages_Administration_Users
                        )
                    ).AddItem(new MenuItemDefinition(
                            SysPageNames.Common.Languages,
                            L("Languages"),
                            url: "Sys/Languages",
                            icon: "flaticon-tabs",
                            requiredPermissionName: AppPermissions.Pages_Administration_Languages
                        )
                    ).AddItem(new MenuItemDefinition(
                            SysPageNames.Common.AuditLogs,
                            L("AuditLogs"),
                            url: "Sys/AuditLogs",
                            icon: "flaticon-folder-1",
                            requiredPermissionName: AppPermissions.Pages_Administration_AuditLogs
                        )
                    ).AddItem(new MenuItemDefinition(
                            SysPageNames.Host.Maintenance,
                            L("Maintenance"),
                            url: "Sys/Maintenance",
                            icon: "flaticon-lock",
                            requiredPermissionName: AppPermissions.Pages_Administration_Host_Maintenance
                        )
                    ).AddItem(new MenuItemDefinition(
                            SysPageNames.Tenant.SubscriptionManagement,
                            L("Subscription"),
                            url: "Sys/SubscriptionManagement",
                            icon: "flaticon-refresh"
                            ,
                            requiredPermissionName: AppPermissions.Pages_Administration_Tenant_SubscriptionManagement
                        )
                    ).AddItem(new MenuItemDefinition(
                            SysPageNames.Common.UiCustomization,
                            L("VisualSettings"),
                            url: "Sys/UiCustomization",
                            icon: "flaticon-medical",
                            requiredPermissionName: AppPermissions.Pages_Administration_UiCustomization
                        )
                    ).AddItem(new MenuItemDefinition(
                            SysPageNames.Host.Settings,
                            L("Settings"),
                            url: "Sys/HostSettings",
                            icon: "flaticon-settings",
                            requiredPermissionName: AppPermissions.Pages_Administration_Host_Settings
                        )
                    )
                    .AddItem(new MenuItemDefinition(
                            SysPageNames.Tenant.Settings,
                            L("Settings"),
                            url: "Sys/Settings",
                            icon: "flaticon-settings",
                            requiredPermissionName: AppPermissions.Pages_Administration_Tenant_Settings
                        )
                    )
                )
                .AddItem(new MenuItemDefinition(
                        SysPageNames.Content.Contents,
                        L(SysPageNames.Content.Contents),
                        icon: "flaticon-interface-8",
                        requiredPermissionName: AppPermissions.Pages_Contents
                    ).AddItem(new MenuItemDefinition(SysPageNames.Content.Categorys,
                        L(SysPageNames.Content.Categorys),
                        url: "Sys/category",
                        icon: "flaticon-map",
                        requiredPermissionName: AppPermissions.Pages_Contents_Category)
                    ).AddItem(new MenuItemDefinition(SysPageNames.Content.Articles,
                        L(SysPageNames.Content.Articles),
                        url: "Sys/DemoUiComponents",
                        icon: "flaticon-folder-1",
                        requiredPermissionName: AppPermissions.Pages_Contents_Article)
                    ).AddItem(new MenuItemDefinition(SysPageNames.Content.Images,
                        L(SysPageNames.Content.Images),
                        url: "Sys/DemoUiComponents",
                        icon: "flaticon-tabs",
                        requiredPermissionName: AppPermissions.Pages_Contents_Image)
                    )
                )
                .AddItem(new MenuItemDefinition(
                        SysPageNames.Common.DemoUiComponents,
                        L("DemoUiComponents"),
                        icon: "flaticon-shapes",
                        requiredPermissionName: AppPermissions.Pages_DemoUiComponents
                    )
                );
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, AbpZeroTemplateConsts.LocalizationSourceName);
        }
    }
}