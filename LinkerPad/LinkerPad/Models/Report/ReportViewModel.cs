using System.Collections.Generic;
using LinkerPad.Models.DailyActivity;
using LinkerPad.Models.Equipment;
using LinkerPad.Models.Material;

namespace LinkerPad.Models.Report
{
    public class ReportViewModel
    {
        public IList<DailyActivityViewModel> DailyActivitesViewModel { get; set; }

        public IList<MaterialViewModel> MaterialsViewModel { get; set; }

        public IList<EquipmentViewModel> EquipmentViewModel { get; set; }

        public bool OfficialReport { get; set; }
    }
}