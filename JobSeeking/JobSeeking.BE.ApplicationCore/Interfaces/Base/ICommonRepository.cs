using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JobSeeking.BE.ApplicationCore.Interfaces.Base
{
    public interface ICommonRepository<T>
    {
        Task<IEnumerable<T>> Get(string procedureName, object[] parameters);

        int Check(string procedureName, object[] parameters);
    }
}
