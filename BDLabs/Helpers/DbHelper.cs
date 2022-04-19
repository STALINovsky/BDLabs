using DataBaseAccess;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDLabs.Helpers
{
    public static class DbHelper
    {
        public static object ExecuteScalar(string commandText, BDLabsDbContext dbContext)
        {
            using var command = dbContext.Database.GetDbConnection().CreateCommand();
            command.CommandText = commandText;

            dbContext.Database.OpenConnection();
            var result = command.ExecuteScalar();
            return result;
        }

        public static int ExecuteProcedure(string commandText, BDLabsDbContext dbContext)
        {
            var parameterReturn = new SqlParameter
            {
                ParameterName = "ReturnValue",
                SqlDbType = System.Data.SqlDbType.Int,
                Direction = System.Data.ParameterDirection.Output,
            };
            dbContext.Database.ExecuteSqlRaw(commandText, parameterReturn);
            int returnValue = (int)parameterReturn.Value;

            return returnValue;
        }
    }
}
