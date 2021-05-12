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
    public class SpecialtyController : BaseController<Specialty>
    {
        private new readonly IBaseEntityService<Specialty> _baseEntityService;
        public readonly ISpecialtyService _specialtyService;
        public readonly ILogger<SpecialtyController> _logger;
        /// <summary>
        ///  Contructor
        /// </summary>
        /// <param name="baseEntityService"></param>
        public SpecialtyController(IBaseEntityService<Specialty> baseService, ISpecialtyService specialtyService, ILogger<SpecialtyController> logger) : base(baseService)
        {
            _baseEntityService = baseService;
            _specialtyService = specialtyService;
            _logger = logger;
        }
        //[HttpGet]
        //[Route("GetListSpecialty")]
        //public async Task<ActionServiceResult> GetListSpecialty()
        //{
        //    return await _specialtyService.GetListSpecialty();
        //}
    }
}
