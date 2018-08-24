using System;

namespace LinkerPad.Data
{
    public class ConfirmationData
    {
        public virtual Guid Id { get; set; }

        public virtual ProjectData ProjectData { get; set; }    

        public virtual UserData ConfirmedBy  { get; set; }

        public virtual DateTime ReportDate { get; set; }

        public virtual DateTime CreateDate { get; set; }
    }
}
