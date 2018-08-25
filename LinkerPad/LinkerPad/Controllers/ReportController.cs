using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using LinkerPad.Business.BusinessLogicInterface;
using LinkerPad.Data;
using LinkerPad.Models.DailyActivity;
using LinkerPad.Models.Equipment;
using LinkerPad.Models.Material;
using LinkerPad.Models.Report;
using Rotativa;

namespace LinkerPad.Controllers
{
    public class ReportController : Controller
    {
        private readonly IDailyActivityLogic _dailyActivityLogic;
        private readonly IMaterialLogic _materialLogic;
        private readonly IEquipmentLogic _equipmentLogic;

        public ReportController(IDailyActivityLogic dailyActivityLogic, IMaterialLogic materialLogic, IEquipmentLogic equipmentLogic)
        {
            _dailyActivityLogic = dailyActivityLogic;
            _materialLogic = materialLogic;
            _equipmentLogic = equipmentLogic;
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
            IList<MaterialData> materialDatas = _materialLogic.GetProjectMaterials(projectId, reportDate).ToList();
            IList<EquipmentData> equipmentDatas = _equipmentLogic.GetProjectEquipment(projectId, reportDate).ToList();

            ReportViewModel reportViewModel = new ReportViewModel
            {
                DailyActivitesViewModel = dailyActivityDatas.Select(DailyActivityViewModel.GetDailyActivityViewModel).ToList(),
                MaterialsViewModel = materialDatas.Select(MaterialViewModel.GetMaterialViewModel).ToList(),
                EquipmentViewModel = equipmentDatas.Select(EquipmentViewModel.GetEquipmentViewModel).ToList()
            };

            return View(reportViewModel);
        }
    }
}