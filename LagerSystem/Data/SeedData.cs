using LagerSystem.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace LagerSystem.Data
{
    public class SeedData
    {
        public void InitData(StorageContext context)
        {
            if (context.StockItems.Any())
            {
                return;
            }

            //var storage = new Storage()
            //{
            //    StorageName = "Lager 1",
            //    Racks = new List<Rack>()
            //    {
            //        new Rack {Height = 2, Width = 2,},
            //        new Rack {Height = 3, Width = 3,}
            //    }

            //};
            //storage.Generate();
            //context.Storages.Add(storage);
            //context.SaveChanges();

            //var pallet = new Pallet[]
            //{
            //    new Pallet{},
            //    new Pallet{},
            //    new Pallet{},
            //};


            //foreach (var item in pallet)
            //{
            //    context.Pallets.Add(item);
            //}
            //context.SaveChanges();

            string line;
            List<StockItem> stockItems = new List<StockItem>();

            StreamReader file = new StreamReader(@"C:\Users\i3028\source\repos\LagerSystem\LagerSystem\Data\MOCK_DATA.csv");

            while ((line = file.ReadLine()) != null)
            {
                var words = line.Split(new[] { ',' });
                stockItems.Add(new StockItem
                {
                    Name = words[0],
                    Amount = Convert.ToInt32(words[1])
                });

            }

            //var stock = new StockItem[]
            //{
            //    new StockItem { Name = "Cola", Amount = 1000},
            //    new StockItem { Name = "Cola Light", Amount = 1000},
            //    new StockItem { Name = "Cola Zero", Amount = 1000},
            //    new StockItem { Name = "Cola Cherry", Amount = 1000},
            //};
            foreach (var item in stockItems)
            {
                context.StockItems.Add(item);
            }
            context.SaveChanges();



        }
    }
}
