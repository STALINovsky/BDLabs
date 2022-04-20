using ConsoleTables;
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
    }
}
