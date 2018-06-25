namespace Roc.CMS.Services.Permission
{
    public interface IPermissionService
    {
        bool HasPermission(string key);
    }
}