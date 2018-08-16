﻿using System;

namespace LinkerPad.Data
{
    public class ProjectData
    {
        public virtual Guid Id { get; set; }

        public virtual UserData UserData { get; set; }

        public virtual string ProjectPicture { get; set; }

        public virtual string Name { get; set; }

        public virtual string Code { get; set; }

        public virtual string Address { get; set; }

        public virtual int MaximunmMember { get; set; }

        public virtual DateTime CreateDate { get; set; }

        public virtual DateTime StartDate { get; set; }

        public virtual DateTime EndDate { get; set; }
    }
}