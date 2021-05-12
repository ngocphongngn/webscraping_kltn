using JobSeeking.BE.ApplicationCore.Entities.JobSeeking;
using JobSeeking.BE.ApplicationCore.Interfaces;
using JobSeeking.BE.Infrashtructure.Data.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JobSeeking.BE.Infrashtructure.Data.Repositories
{
    public class SpecialtyRepository : BaseRepository<Specialty>, ISpecialtyRepository
    {
        //public async Task<IEnumerable<Specialty>> GetListSpecialty()
        //{
        //   return await Task.FromResult(GetEntities("Proc_GetListSpecialty", new object[] { }));
        //}
    }
}
