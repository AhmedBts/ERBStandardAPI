using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistence;
using Microsoft.Data.SqlClient;

namespace Common
{
    public static class ADOData
    {
        
        public static   IEnumerable<dynamic> CollectionFromSql(this DbContext dbContext, string Sql)
        {
            using (var cmd = dbContext.Database.GetDbConnection().CreateCommand())
            {
                cmd.CommandText = Sql;
                if (cmd.Connection.State != ConnectionState.Open)
                    cmd.Connection.Open();

                cmd.CommandTimeout = 60;
                using (var dataReader = cmd.ExecuteReader())
                {

                    while ( dataReader.Read())
                    {
                        var dataRow = GetDataRow(dataReader);
                        yield return dataRow;

                    }
                }


            }
        }

        public static dynamic GetDataRow(DbDataReader dataReader)
        {
            var dataRow = new ExpandoObject() as IDictionary<string, object>;
            for (var fieldCount = 0; fieldCount < dataReader.FieldCount; fieldCount++)
                dataRow.Add(dataReader.GetName(fieldCount), dataReader[fieldCount]);
            return dataRow;
        }


        public static DataTable CollectionFromSqlDT(this DbContext db, string Sql)
        {
          


            var dataTable = new DataTable();
            try
            {

                using (var connection = new SqlConnection(db.Database.GetDbConnection().ConnectionString))
                {
                    SqlCommand command = new SqlCommand();
                    connection.Open();
        
                    command.Connection = connection;
                    command.CommandText = string.Format(Sql);
                    var dataReader = command.ExecuteReader();

                    dataTable.Load(dataReader);
                }

                return dataTable;


            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
