using Abp.Modules;
using Abp.Reflection.Extensions;

namespace Roc.CMS
{
    public class AbpZeroTemplateClientModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(AbpZeroTemplateClientModule).GetAssembly());
        }
    }
}
