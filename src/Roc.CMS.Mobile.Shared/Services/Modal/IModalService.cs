using System.Threading.Tasks;
using Roc.CMS.Views;
using Xamarin.Forms;

namespace Roc.CMS.Services.Modal
{
    public interface IModalService
    {
        Task ShowModalAsync(Page page);

        Task ShowModalAsync<TView>(object navigationParameter) where TView : IXamarinView;

        Task<Page> CloseModalAsync();
    }
}
