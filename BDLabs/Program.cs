using BDLabs;
using ConsoleTables;
using DataBaseAccess;
using Microsoft.EntityFrameworkCore;
using Model;
using System.Text.Json;

var dbContext = new BDLabsDbContext();
Console.WriteLine("Laba DO 10701219");

    Console.WriteLine(@"Welcome to the club body");
    Console.WriteLine("Write lab name to execute lab");
    //Lab2.DoLab(dbContext);
    Lab3.DoLab(dbContext);
    Lab4.DoLab(dbContext);



