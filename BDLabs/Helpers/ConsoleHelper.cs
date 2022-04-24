using ConsoleTables;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDLabs.Helpers
{
    public class ConsoleHelper
    {
        public static void PrintTable<T>(IQueryable<T> dbSet) where T : class
        {
            Console.WriteLine($"Data table or View: {typeof(T).Name}");
            var table = ConsoleTable.From<T>(dbSet);
            table.Write();
        }

        public static Emploee GetEmploeeFromUserInput()
        {
            try
            {
                Console.WriteLine("Enter User Name");
                var name = Console.ReadLine();
                Console.WriteLine("Enter User SurName");
                var surname = Console.ReadLine();
                Console.WriteLine("Enter User Age");
                var age = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter phone number");
                var phoneNumber = Console.ReadLine();
                Console.WriteLine("Enter phone salary");
                var salary = decimal.Parse(Console.ReadLine());

                return new Emploee()
                {
                    Name = name,
                    Surname = surname,
                    Age = age,
                    PhoneNumber = phoneNumber,
                    Salary = salary
                };
            }
            catch (Exception)
            {
                Console.WriteLine("Failed to enter user, please try again");
                return GetEmploeeFromUserInput();
            }

        }
    }
}
