using System;
using System.Collections.Generic;
using System.Text;

namespace JobSeeking.BE.ApplicationCore.Entities.JobSeeking
{
    public class JobDetail
    {
        public Guid JobDetailID { get; set; }
        public int JobDetailCode { get; set; }
        public Guid? JobID { get; set; }
        public string Welfare { get; set; }
        public string RequiredWork { get; set; }
        public string Reason { get; set; }
        public string CompanyInformation { get; set; }
        public string HiringDate { get; set; }
        public string Level { get; set; }
        public string Skill { get; set; }
        public string LanguageDisplayInFile { get; set; }
        public string MajorsDetail { get; set; }
    }
}
