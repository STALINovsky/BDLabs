using BDLabs.Helpers;
using DataBaseAccess;
using Microsoft.EntityFrameworkCore;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDLabs
{
    record EmployeeSalary(string FullName, decimal Salary);
    record EmployeeSalaryCriteria(string FullName, decimal CriteriaValue);

    public static class Lab4
    {
        public static void DoLab(BDLabsDbContext dbContext)
        {
            ConsoleHelper.PrintTable(dbContext.Employees);
            Console.WriteLine("Enter 1 to sort by Name");
            Console.WriteLine("Enter 2 to sort by Name DESC");
            Console.WriteLine("Enter 3 to sort by Salary");
            Console.WriteLine("Enter 4 to sort by Salary DESC");
            
            var originalQuery = dbContext.Employees;
            var input = Console.ReadLine();
            IQueryable<Emploee> resultQuery = input switch
            {
                "1" => originalQuery.OrderBy(e => e.Name),
                "2" => originalQuery.OrderByDescending(e => e.Name),
                "3" => originalQuery.OrderBy(e => e.Salary),
                "4" => originalQuery.OrderByDescending(e => e.Salary),
                _ => originalQuery,
            };

            ConsoleHelper.PrintTable(resultQuery);
            

            Console.WriteLine("Enter filter criteria for name or nothing to skip it");
            var nameFilter = Console.ReadLine();
            if (!string.IsNullOrEmpty(nameFilter))
            {
                resultQuery = originalQuery.Where(x => EF.Functions.Like(x.Name, nameFilter));
            }
            ConsoleHelper.PrintTable(resultQuery);

            Console.WriteLine("Enter minimal salary or nothing to skip");
            if (int.TryParse(Console.ReadLine(), out var resultSalary))
            {
                resultQuery = originalQuery.Where(x => x.Salary > resultSalary);
            }
            ConsoleHelper.PrintTable(resultQuery);

            Console.WriteLine("Enter minimal age or nothing to skip");
            if (int.TryParse(Console.ReadLine(), out var resultAge))
            {
                resultQuery = originalQuery.Where(x => x.Age > resultAge);
            }
            ConsoleHelper.PrintTable(resultQuery);

            var EmployeeSalaries = dbContext.Employees.Select(e => new EmployeeSalary(e.Name + e.Surname, e.Salary));
            ConsoleHelper.PrintTable(EmployeeSalaries);

            var EmployeeSalaryCriteries = dbContext.Employees.Select(e => new EmployeeSalaryCriteria(e.Name + e.Surname, e.Salary / e.Age));
            ConsoleHelper.PrintTable(EmployeeSalaryCriteries);
        }
    }
}
