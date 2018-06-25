using System.Threading.Tasks;
using Abp.Web.Models;
using Acr.UserDialogs;
using Flurl.Http;
using Roc.CMS.Extensions;
using Roc.CMS.Localization;

namespace Roc.CMS.Core.Threading
{
    public class AbpExceptionHandler
    {
        public async Task<bool> HandleIfAbpResponseAsync(FlurlHttpException httpException)
        {
            var ajaxResponse = await httpException.GetResponseJsonAsync<AjaxResponse>();
            if (ajaxResponse == null)
            {
                return false;
            }

            if (!ajaxResponse.__abp)
            {
                return false;
            }

            if (ajaxResponse.Error == null)
            {
                return false;
            }

            UserDialogs.Instance.HideLoading();

            if (string.IsNullOrEmpty(ajaxResponse.Error.Details))
            {
                UserDialogs.Instance.Alert(ajaxResponse.Error.GetConsolidatedMessage(), L.Localize("Error"));
            }
            else
            {
                UserDialogs.Instance.Alert(ajaxResponse.Error.Details, ajaxResponse.Error.GetConsolidatedMessage());
            }

            return true;
        }
    }
}