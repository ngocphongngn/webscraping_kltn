using JobSeeking.BE.ApplicationCore.Entities.JobSeeking;
using JobSeeking.BE.ApplicationCore.Interfaces;
using JobSeeking.BE.Infrashtructure.Data.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace JobSeeking.BE.Infrashtructure.Data.Repositories
{
    public class JobRepository : BaseRepository<Job>, IJobRepository
    {

    }
}
