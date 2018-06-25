using Abp.Zero.Ldap.Authentication;
using Abp.Zero.Ldap.Configuration;
using Roc.CMS.Authorization.Users;
using Roc.CMS.MultiTenancy;

namespace Roc.CMS.Authorization.Ldap
{
    public class AppLdapAuthenticationSource : LdapAuthenticationSource<Tenant, User>
    {
        public AppLdapAuthenticationSource(ILdapSettings settings, IAbpZeroLdapModuleConfig ldapModuleConfig)
            : base(settings, ldapModuleConfig)
        {
        }
    }
}