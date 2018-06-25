using System.Threading.Tasks;

namespace Roc.CMS.Identity
{
    public interface ISmsSender
    {
        Task SendAsync(string number, string message);
    }
}