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
using LinkerPad.Models.Project;
using LinkerPad.Models.Account;

namespace LinkerPad.Controllers
{
    public class ReportController : Controller
    {
        private readonly IDailyActivityLogic _dailyActivityLogic;
        private readonly IMaterialLogic _materialLogic;
        private readonly IEquipmentLogic _equipmentLogic;
        private readonly IProjectLogic _projectLogic;
        private readonly IAccountLogic _accountLogic;


        public ReportController(IDailyActivityLogic dailyActivityLogic, IMaterialLogic materialLogic, IEquipmentLogic equipmentLogic, IProjectLogic projectLogic, IAccountLogic accountLogic)
        {
            _dailyActivityLogic = dailyActivityLogic;
            _materialLogic = materialLogic;
            _equipmentLogic = equipmentLogic;
            _projectLogic = projectLogic;
            _accountLogic = accountLogic;
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

            ProjectData projectData = _projectLogic.GetProjectData(projectId);

            UserData userData = _accountLogic.GetUser(projectData.UserData.Id);

            ReportViewModel reportViewModel = new ReportViewModel
            {
                DailyActivitesViewModel = dailyActivityDatas.Select(DailyActivityViewModel.GetDailyActivityViewModel).ToList(),
                MaterialsViewModel = materialDatas.Select(MaterialViewModel.GetMaterialViewModel).ToList(),
                EquipmentViewModel = equipmentDatas.Select(EquipmentViewModel.GetEquipmentViewModel).ToList(),
                ProjectViewModel = ProjectViewModel.GetProjectViewModel(projectData, UserRole.Admin),
                ProjectCreator = UserInformationViewModel.GetUserInformationViewModel(userData)
            };

            return View(reportViewModel);
        }
    }
}