using System.Collections.Generic;
using LinkerPad.Models.DailyActivity;

namespace LinkerPad.Models.Report
{
    public class ReportViewModel
    {
        public IList<DailyActivityViewModel> DailyActivitesViewModel { get; set; }

        public bool OfficialReport { get; set; }
    }
}