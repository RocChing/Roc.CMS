using Xamarin.Forms.Internals;

namespace Roc.CMS.Behaviors
{
    [Preserve(AllMembers = true)]
    public interface IAction
    {
        bool Execute(object sender, object parameter);
    }
}