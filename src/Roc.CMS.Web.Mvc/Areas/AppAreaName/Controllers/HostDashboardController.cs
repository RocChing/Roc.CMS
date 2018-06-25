﻿using Abp.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc;
using Roc.CMS.Authorization;
using Roc.CMS.Web.Areas.AppAreaName.Models.HostDashboard;
using Roc.CMS.Web.Controllers;

namespace Roc.CMS.Web.Areas.AppAreaName.Controllers
{
    [Area("AppAreaName")]
    [AbpMvcAuthorize(AppPermissions.Pages_Administration_Host_Dashboard)]
    public class HostDashboardController : AbpZeroTemplateControllerBase
    {
        private const int DashboardOnLoadReportDayCount = 7;

        public ActionResult Index()
        {
            return View(new HostDashboardViewModel(DashboardOnLoadReportDayCount));
        }
    }
}