using System.Collections.Generic;
using Roc.CMS.Authorization.Users.Dto;
using Roc.CMS.Dto;

namespace Roc.CMS.Authorization.Users.Exporting
{
    public interface IUserListExcelExporter
    {
        FileDto ExportToFile(List<UserListDto> userListDtos);
    }
}