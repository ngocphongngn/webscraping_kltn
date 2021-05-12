using AutoMapper;
using JobSeeking.BE.API.Interfaces;
using JobSeeking.BE.ApplicationCore.Entities.Base;
using JobSeeking.BE.ApplicationCore.Entities.JobSeeking;
using JobSeeking.BE.ApplicationCore.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobSeeking.BE.API.Services
{

    public class SpecialtyService: ISpecialtyService
    {
        private readonly ISpecialtyRepository _specialtyRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<SpecialtyService> _logger;
        public SpecialtyService(ISpecialtyRepository specialtyRepository, 
            IMapper mapper, ILogger<SpecialtyService> logger)
        {
            _specialtyRepository = specialtyRepository;
            _mapper = mapper;
            _logger = logger;
        }
        //public async Task<ActionServiceResult> GetListSpecialty()
        //{
        //    var res = new ActionServiceResult();
        //    Task<IEnumerable<Specialty>> list = _specialtyRepository.GetListSpecialty();
        //    res.Data = list;
        //    return res;
        //}
    }
}
