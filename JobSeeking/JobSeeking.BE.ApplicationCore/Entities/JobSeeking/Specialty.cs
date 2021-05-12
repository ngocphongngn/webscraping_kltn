using JobSeeking.BE.ApplicationCore.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace JobSeeking.BE.ApplicationCore.Entities.JobSeeking
{
    public partial class Specialty : BaseEntity
    { 
        public int SpecialtyID { get; set; }
        public string SpecialtyName { get; set; }
        public int SubSpecialty { get; set; }
        public string JobPosition { get; set; }

    }
}
