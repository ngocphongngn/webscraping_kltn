using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobSeeking.BE.API.Controllers.Base;
using JobSeeking.BE.API.Interfaces;
using JobSeeking.BE.API.Interfaces.Base;
using JobSeeking.BE.ApplicationCore.Entities.Base;
using JobSeeking.BE.ApplicationCore.Entities.JobSeeking;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace JobSeeking.BE.API.Controllers
{
    [ApiController]
    public class JobController : BaseController<Job>
    {
        private new readonly IBaseEntityService<Job> _baseEntityService;
        public readonly IJobService _jobService;
        public readonly ILogger<JobController> _logger;
        /// <summary>
        ///  Contructor
        /// </summary>
        /// <param name="baseEntityService"></param>
        public JobController(IBaseEntityService<Job> baseService, IJobService jobService, ILogger<JobController> logger) : base(baseService)
        {
            _baseEntityService = baseService;
            _jobService = jobService;
            _logger = logger;
        }
        /// <summary>
        /// nnphong - service crawler du lieu
        /// </summary>
        /// <param name="systemCode"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Crawler")]
        public async Task<ActionServiceResult> CrawlerJobFromOtherSystem([FromBody] List<int> lstSystemCode)
        {
            return await _jobService.CrawlerJobFromOtherSystem(lstSystemCode);
        }
    }
}
