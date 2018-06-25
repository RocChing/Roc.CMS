namespace Roc.CMS.Web.Areas.Sys.Models.HostDashboard
{
    public class HostDashboardViewModel
    {
        public int ReportOnLoadDayCount { get; set; } 

        public HostDashboardViewModel(int reportOnLoadDayCount)
        {
            ReportOnLoadDayCount = reportOnLoadDayCount;
        }
    }
}