using JobSeeking.BE.ApplicationCore.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobSeeking.BE.API.Interfaces
{
    public interface IJobService
    {
        Task<ActionServiceResult> CrawlerJobFromOtherSystem(List<int> systemCode);
    }
}
