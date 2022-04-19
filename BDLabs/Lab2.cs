using BDLabs.Helpers;
using DataBaseAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDLabs
{
    public static class Lab2
    {
        public static void DoLab(BDLabsDbContext dbContext)
        {
            ConsoleHelper.PrintTable(dbContext.Employees);
            var result = DbHelper.ExecuteScalar("SELECT COUNT(*) FROM Employees", dbContext);
            Console.WriteLine($"result of 'SELECT COUNT(*) FROM Employees': {result} ");

            var resultOfPrecudere = DbHelper.ExecuteProcedure("EXEC @returnValue = AddEmployee @Name = 'Dmitry', @SurName = 'Ovchinnikov', @Age = 18, @PhoneNumber = '+7777777', @Salary = 9999", dbContext);
            Console.WriteLine($"Result of procedure {resultOfPrecudere}");

        }
    }
}
