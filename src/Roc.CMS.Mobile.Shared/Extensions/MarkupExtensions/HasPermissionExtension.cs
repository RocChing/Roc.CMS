using System;
using Roc.CMS.Core;
using Roc.CMS.Core.Dependency;
using Roc.CMS.Services.Permission;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Roc.CMS.Extensions.MarkupExtensions
{
    [ContentProperty("Text")]
    public class HasPermissionExtension : IMarkupExtension
    {
        public string Text { get; set; }
        
        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (ApplicationBootstrapper.AbpBootstrapper == null || Text == null)
            {
                return false;
            }

            var permissionService = DependencyResolver.Resolve<IPermissionService>();
            return permissionService.HasPermission(Text);
        }
    }
}