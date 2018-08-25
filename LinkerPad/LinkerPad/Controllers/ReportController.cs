using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using LinkerPad.Business.BusinessLogicInterface;
using LinkerPad.Data;
using LinkerPad.Models.DailyActivity;
using LinkerPad.Models.Report;
using Rotativa;

namespace LinkerPad.Controllers
{
    public class ReportController : Controller
    {
        private readonly IDailyActivityLogic _dailyActivityLogic;

        public ReportController(IDailyActivityLogic dailyActivityLogic)
        {
            _dailyActivityLogic = dailyActivityLogic;
        }

        public ActionResult CreatePdfReport(Guid projectId, DateTime reportDate)
        {
            return new ActionAsPdf("ReportResult", new { projectId, reportDate })
            {
                FileName = "Report.pdf"
            };
        }
        // GET: Report
        public ActionResult ReportResult(Guid projectId, DateTime reportDate)
        {
            IList<DailyActivityData> dailyActivityDatas = _dailyActivityLogic.GetProjectDailyActivies(projectId, reportDate).ToList();

            ReportViewModel reportViewModel = new ReportViewModel
            {
                DailyActivitesViewModel = dailyActivityDatas.Select(DailyActivityViewModel.GetDailyActivityViewModel).ToList()
            };

            return View(reportViewModel);
        }
    }
}