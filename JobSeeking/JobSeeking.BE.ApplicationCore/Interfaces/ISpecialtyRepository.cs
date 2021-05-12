using JobSeeking.BE.ApplicationCore.Entities.JobSeeking;
using JobSeeking.BE.ApplicationCore.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JobSeeking.BE.ApplicationCore.Interfaces
{
    public interface ISpecialtyRepository : IBaseRepository<Specialty>
    {
        //Task<IEnumerable<Specialty>> GetListSpecialty();
    }
}
