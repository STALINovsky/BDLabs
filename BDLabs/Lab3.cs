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
            dbContext.Employees.Add(ConsoleHelper.GetEmploeeFromUserInput());
            dbContext.Employees.Add(ConsoleHelper.GetEmploeeFromUserInput());
            dbContext.SaveChanges();
            ConsoleHelper.PrintTable(dbContext.Employees);
        }


        public static void DoCringe()
        {
            var ProductStore = new DataSet("ProductStore");
            var ProductTable = new DataTable("Product");
            // добавление  таблицы в  dataset
            ProductStore.Tables.Add(ProductTable);

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

            ProductTable.Columns.Add(idColumn);
            ProductTable.Columns.Add(nameColumn);
            ProductTable.Columns.Add(priceColumn);
            ProductTable.Columns.Add(discountColumn);
            // определение первичного ключа таблицы product
            ProductTable.PrimaryKey = new DataColumn[] { ProductTable.Columns["Id"] };

            DataRow row = ProductTable.NewRow();
            row.ItemArray = new object[] { null, "Монитор", 200 };
            ProductTable.Rows.Add(row); // добавление первой строки
            ProductTable.Rows.Add(new object[] { null, "Мышка", 170 }); // добавление второй строки
            ProductTable.Rows.Add(new object[] { null, "Клавиатура", 270 }); // добавление //третьей строки
            ProductTable.Rows.Add(new object[] { null, "Системный блок", 270 }); // добавление четвертой строки
            ProductTable.Rows.Add(new object[] { null, "Процессор", 3000 }); // добавление пятой //строки

            foreach (DataRow r in ProductTable.Rows)
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
