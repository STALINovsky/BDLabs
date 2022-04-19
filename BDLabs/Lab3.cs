using BDLabs.Helpers;
using DataBaseAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDLabs
{
    public static class Lab3
    {
        public static void DoLab(BDLabsDbContext dbContext)
        {
            DoCringe();

            ConsoleHelper.PrintTable(dbContext.Employees);
            dbContext.Employees.Add(new() { Name = "Alexey", Surname = "Suslav", Age = 19, PhoneNumber = "+6666666", Salary = 99999 });
            dbContext.Employees.Add(new() { Name = "Egor", Surname = "Katlinsky", Age = 20, PhoneNumber = "+5555555", Salary = 88888 });
            dbContext.SaveChanges();
            ConsoleHelper.PrintTable(dbContext.Employees);
        }


        public static void DoCringe()
        {
            var bookStore = new DataSet("BookStore");
            var booksTable = new DataTable("Books");
            // добавление  таблицы в  dataset
            bookStore.Tables.Add(booksTable);

            // создание столбцов для таблицы Books
            var idColumn = new DataColumn("Id", Type.GetType("System.Int32"));
            idColumn.Unique = true; // столбец будет иметь уникальное значение
            idColumn.AllowDBNull = false; // не может принимать null
            idColumn.AutoIncrement = true; // будет автоинкрементироваться
            idColumn.AutoIncrementSeed = 1; // начальное значение
            idColumn.AutoIncrementStep = 1; // приращении при добавлении новой строки

            var nameColumn = new DataColumn("Name", Type.GetType("System.String"));
            var priceColumn = new DataColumn("Price", Type.GetType("System.Decimal"));
            priceColumn.DefaultValue = 100; // значение по умолчанию
            var discountColumn = new DataColumn("Discount", Type.GetType("System.Decimal"));
            discountColumn.Expression = "Price * 0.2";

            booksTable.Columns.Add(idColumn);
            booksTable.Columns.Add(nameColumn);
            booksTable.Columns.Add(priceColumn);
            booksTable.Columns.Add(discountColumn);
            // определение первичного ключа таблицы books
            booksTable.PrimaryKey = new DataColumn[] { booksTable.Columns["Id"] };

            DataRow row = booksTable.NewRow();
            row.ItemArray = new object[] { null, "Война и мир", 200 };
            booksTable.Rows.Add(row); // добавление первой строки
            booksTable.Rows.Add(new object[] { null, "Отцы и дети", 170 }); // добавление второй строки
            booksTable.Rows.Add(new object[] { null, "Преступление и наказание", 270 }); // добавление //третьей строки
            booksTable.Rows.Add(new object[] { null, "Идиот", 270 }); // добавление четвертой строки
            booksTable.Rows.Add(new object[] { null, "Арзипелаг ГУЛАГ", 3000 }); // добавление пятой //строки



            foreach (DataRow r in booksTable.Rows)
            {
                string result = "";
                foreach (var cell in r.ItemArray)
                {
                    result += cell + "  ";
                }
                Console.WriteLine(result);
            }
        }
    }
}
