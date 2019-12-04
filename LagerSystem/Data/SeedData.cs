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

            string line;
            List<StockItem> stockItems = new List<StockItem>();

            StreamReader file = new StreamReader(@"C:\Users\Z003XMPW\Source\Repos\LagerSystem\LagerSystem\Data\MOCK_DATA.csv");

            while ((line = file.ReadLine()) != null)
            {
                var words = line.Split(new[] { ',' });
                stockItems.Add(new StockItem
                {
                    Name = words[0],
                    Amount = Convert.ToInt32(words[1])
                });

            }
            foreach (var item in stockItems)
            {
                context.StockItems.Add(item);
            }
            context.SaveChanges();



        }
    }
}
