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


            var user = ConsoleHelper.GetEmploeeFromUserInput();
            var resultOfPrecudere = DbHelper.ExecuteProcedure($"EXEC @returnValue = AddEmployee @Name = '{user.Name}', @SurName = '{user.Surname}', @Age = {user.Age}, @PhoneNumber = '{user.PhoneNumber}', @Salary = {user.Salary}", dbContext);
            Console.WriteLine($"Result of procedure {resultOfPrecudere}");
            ConsoleHelper.PrintTable(dbContext.Employees);
        }
    }
}
