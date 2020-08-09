using System;
using System.Collections.Generic;
using QOnT.Models;

namespace iSele.QOnT2SQL
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //string connetionString = @"Driver={Microsoft Access Driver (*.mdb, *.accdb)};DBQ=C:\\Backup\\Databases\\QuaffeeTracker08.mdb";
            //OdbcRepository myRepo = new OdbcRepository(connetionString);
            //List<OdbcData> items = myRepo.Get("SELECT * from CityTbl");

            //foreach (var item in items)
            //{
            //    Console.WriteLine($"item name: {item.DataTypeName}, value: {item.DataTypeValue}" );
            //}


            ItemUnitsTbl itemUnit = new ItemUnitsTbl();
            List<ItemUnitsTbl> itemUnits = itemUnit.GetAll("");

            foreach (var item in itemUnits)
            {
                Console.WriteLine($"Item ID: {item.ItemUnitID}, UnitDesc: {item.UnitDescription}, UnitOfMeasure: {item.UnitOfMeasure}");
            }
        }
    }
}
