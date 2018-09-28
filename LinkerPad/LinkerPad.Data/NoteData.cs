using System;

namespace LinkerPad.Data
{
    public class NoteData
    {
        public virtual Guid Id { set; get; }

        public virtual ProjectData ProjectData { set; get; }

        public virtual UserData CreatedBy { set; get; }

        public virtual DateTime ReportDate { get; set; }

        public virtual DateTime CreateDate { get; set; }

        public virtual DateTime ModifiedDate { get; set; }

        public virtual string Title { get; set; }

        public virtual string Description { get; set; }

    }
}
