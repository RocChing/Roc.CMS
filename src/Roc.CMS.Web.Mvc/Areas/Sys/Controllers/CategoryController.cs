using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Roc.CMS.Web.Controllers;
using Roc.CMS.Authorization;
using Abp.AspNetCore.Mvc.Authorization;
using Abp.Application.Services.Dto;
using Roc.CMS.Content;

namespace Roc.CMS.Web.Areas.Sys.Controllers
{
    [Area(AppConsts.AppAreaName)]
    [AbpMvcAuthorize(AppPermissions.Pages_Administration_AuditLogs)]
    public class CategoryController : AbpZeroTemplateControllerBase
    {
        private ICategoryAppService _categoryAppService;

        public CategoryController(ICategoryAppService categoryAppService)
        {
            _categoryAppService = categoryAppService;
        }

        public async Task<ActionResult> Index()
        {
            ViewBag.FilterText = Request.Query["filterText"];
            var output = await _categoryAppService.GetCategoryForEdit(new NullableIdDto());
            output.Categories.Insert(0, new ComboboxItemDto("", ""));

            return View(output);
        }

        public async Task<PartialViewResult> CreateOrEditModal(int? id)
        {
            var output = await _categoryAppService.GetCategoryForEdit(new NullableIdDto(id));

            return PartialView("_CreateOrEditModal", output);
        }
    }
}
