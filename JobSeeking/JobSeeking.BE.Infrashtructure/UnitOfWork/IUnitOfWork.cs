using JobSeeking.BE.Infrashtructure.DataContext;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace JobSeeking.BE.Infrashtructure.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IDatabaseContext DataContext { get; }
        MySqlTransaction BeginTransaction();
        void Commit();
        void RollBack();
    }
}
