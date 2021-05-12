using JobSeeking.BE.ApplicationCore.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace JobSeeking.BE.ApplicationCore.Entities.JobSeeking
{
    /// <summary>
    /// Bảng Master: Việc làm
    /// </summary>
    public partial class Job : BaseEntity
    {
        /// <summary>
        /// Khóa chính
        /// </summary>
        public Guid JobID { get; set; }
        /// <summary>
        /// Mã việc làm
        /// </summary>
        public string JobCode { get; set; }
        /// <summary>
        /// Tên việc làm
        /// </summary>
        public string JobName { get; set; }
        /// <summary>
        /// Mã hệ thống đã lấy dữ liệu
        /// </summary>
        public int SystemID { get; set; }
        /// <summary>
        /// Mã ngành nghề
        /// </summary>
        public Guid? MajorsIn { get; set; }
        /// <summary>
        /// Lương
        /// </summary>
        public string Salary { get; set; }
        /// <summary>
        /// Địa điểm làm việc
        /// </summary>
        public string Location { get; set; }
        /// <summary>
        /// link logo
        /// </summary>
        public string Logo { get; set; }
        /// <summary>
        /// Tên công ty
        /// </summary>
        public string CompanyName { get; set; }
        /// <summary>
        /// Thời gian cập nhật
        /// </summary>
        public string UpdateTime { get; set; }
        /// <summary>
        /// url link đến detail
        /// </summary>
        public string UrlDetail { get; set; }
    }
}
