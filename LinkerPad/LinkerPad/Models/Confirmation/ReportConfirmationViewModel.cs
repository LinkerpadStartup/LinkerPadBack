using System;
using System.Linq;
using LinkerPad.Data;
using LinkerPad.Models.Account;

namespace LinkerPad.Models.Confirmation
{
    public class ReportConfirmationViewModel : UserInformationViewModel
    {
        public bool ConfirmationStatus { get; set; }

        public static ReportConfirmationViewModel GetReportConfirmationViewModel(UserData userData, ProjectData projectData, DateTime reportDate)
        {
            return new ReportConfirmationViewModel
            {
                Id = userData.Id,
                FirstName = userData.FirstName,
                LastName = userData.LastName,
                EmailAddress = userData.Email,
                MobileNumber = userData.MobileNumber,
                Company = userData.Company,
                ProfilePicture = userData.ProfilePicture,
                UserRole = GetUserRoleInProject(userData, projectData),
                ConfirmationStatus = IsUserConfirmedThisReport(userData, projectData, reportDate)
            };
        }

        private static bool IsUserConfirmedThisReport(UserData userData, ProjectData projectData, DateTime reportDate)
        {
            return userData.ConfirmationDatas
                .Any(c =>
                    c.ConfirmedBy.Id == userData.Id
                    && c.ProjectData.Id == projectData.Id
                    && c.ReportDate.Date == reportDate.Date);
        }
    }
}