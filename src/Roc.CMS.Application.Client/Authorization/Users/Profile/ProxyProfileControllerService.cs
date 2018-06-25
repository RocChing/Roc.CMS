using System.IO;
using System.Threading.Tasks;
using Roc.CMS.Authorization.Users.Profile.Dto;

namespace Roc.CMS.Authorization.Users.Profile
{
    public class ProxyProfileControllerService : ProxyControllerBase
    {
        public async Task<UploadProfilePictureOutput> UploadProfilePicture(Stream stream, string fileName)
        {
            return await ApiClient
                .PostMultipartAsync<UploadProfilePictureOutput>(GetEndpoint(nameof(UploadProfilePicture)), stream, fileName);
        }
    }
}