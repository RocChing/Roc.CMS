namespace Roc.CMS.Web.Areas.Sys.Startup
{
    public class SysPageNames
    {
        public static class Common
        {
            public const string Administration = "Administration";
            public const string Roles = "Administration.Roles";
            public const string Users = "Administration.Users";
            public const string AuditLogs = "Administration.AuditLogs";
            public const string OrganizationUnits = "Administration.OrganizationUnits";
            public const string Languages = "Administration.Languages";
            public const string DemoUiComponents = "Administration.DemoUiComponents";
            public const string UiCustomization = "Administration.UiCustomization";
        }

        public static class Host
        {
            public const string Tenants = "Tenants";
            public const string Editions = "Editions";
            public const string Maintenance = "Administration.Maintenance";
            public const string Settings = "Administration.Settings.Host";
            public const string Dashboard = "Dashboard";
        }

        public static class Tenant
        {
            public const string Dashboard = "Dashboard.Tenant";
            public const string Settings = "Administration.Settings.Tenant";
            public const string SubscriptionManagement = "Administration.SubscriptionManagement.Tenant";
        }

        /// <summary>
        /// 内容管理
        /// </summary>
        public static class Content
        {
            public const string Contents = "Content";
            public const string Categorys = "Content.Categorys";
            public const string Categorys_HeaderInfo = "Content.Categorys.HeaderInfo";
            public const string Categorys_CreateInfo = "Content.Categorys.CreateBtn";
            public const string Categorys_EditInfo = "Content.Categorys.EditInfo";
            public const string Categorys_FilterByParentName = "Content.Categorys.FilterByParentName";
            public const string Categorys_FilterByName = "Content.Categorys.FilterByName";

            //列名
            public const string Categorys_Name = "Content.Categorys.Name";
            public const string Categorys_ParentName= "Content.Categorys.ParentName";
            public const string Categorys_IsNav = "Content.Categorys.IsNav";
            public const string Categorys_IsSpecial = "Content.Categorys.IsSpecial";
            public const string Categorys_URL = "Content.Categorys.URL";
            public const string Categorys_Target = "Content.Categorys.Target";
            public const string Categorys_Remark = "Content.Categorys.Remark";

            public const string Articles = "Content.Articles";
            public const string Images = "Content.Images";
        }
    }
}
