using System;
using System.Collections.Generic;
using System.Text;

namespace JobSeeking.BE.Infrashtructure.DataContext
{
    public interface IDatabaseContextFactory
    {
        IDatabaseContext Context();
    }
}

