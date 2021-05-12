using JobSeeking.BE.ApplicationCore.Interfaces.Base;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace JobSeeking.BE.Infrashtructure.Data.Repositories.Base
{
    public class CommonRepository<T> : ICommonRepository<T>
    {
        public int Check(string procedureName, object[] parameters)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="taxType"></param>
        /// <param name="organizationID"></param>
        /// <returns></returns>
        public async Task<IEnumerable<T>> Get(string procedureName, object[] parameters)
        {
            return await Task.FromResult(GetData(procedureName, parameters));
        }
        protected IEnumerable<T> GetData(string procedureName, object[] parameters)
        {
            using (DatabaseConnector databaseConnector = new DatabaseConnector())
            {
                if (parameters != null && parameters.Length > 0)
                    databaseConnector.SetParameterValue(procedureName, parameters);
                using (MySqlDataReader mySqlDataReader = databaseConnector.ExecuteReader(procedureName))
                {
                    while (mySqlDataReader.Read())
                    {
                        var entity = Activator.CreateInstance<T>();
                        for (int i = 0; i < mySqlDataReader.FieldCount; i++)
                        {
                            string fieldName = mySqlDataReader.GetName(i);
                            PropertyInfo property = entity.GetType().GetProperty(fieldName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.IgnoreCase);
                            var fieldValue = mySqlDataReader[fieldName];
                            if (property != null && fieldValue != DBNull.Value)
                            {
                                property.SetValue(entity, fieldValue, null);
                            }
                        }
                        yield return entity;
                    }
                }
            }
        }

    }
}
