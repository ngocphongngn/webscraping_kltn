using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace JobSeeking.BE.Infrashtructure.DataContext
{
    public interface IDatabaseContext
    {
        MySqlConnection Connection { get; }
    }
}
