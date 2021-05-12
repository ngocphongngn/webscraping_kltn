using JobSeeking.BE.ApplicationCore.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using static JobSeeking.BE.ApplicationCore.Enums.Enumeration;

namespace JobSeeking.BE.ApplicationCore.Entities.Base
{
    public class ActionServiceResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public SystemCode SystemCode { get; set; }
        public object Data { get; set; }

        /// <summary>
        /// Hàm khởi tạo mặc định
        /// </summary>
        public ActionServiceResult()
        {
            Success = true;
            //Message = Resources.Success;
            SystemCode = SystemCode.Success;
            Data = null;
        }
    }
}