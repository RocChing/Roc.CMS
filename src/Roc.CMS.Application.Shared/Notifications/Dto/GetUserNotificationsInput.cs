using Abp.Notifications;
using Roc.CMS.Dto;

namespace Roc.CMS.Notifications.Dto
{
    public class GetUserNotificationsInput : PagedInputDto
    {
        public UserNotificationState? State { get; set; }
    }
}