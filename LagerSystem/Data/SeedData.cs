using LagerSystem.Models;
using System.Collections.Generic;
using System.Linq;

namespace LagerSystem.Data
{
    public class SeedData
    {
        public void InitData(StorageContext context)
        {
            if (context.Storages.Any())
            {
                return;
            }

            var storage = new Storage()
            {
                StorageName = "Lager 1",
                NumberOfRacks = 2,
                Racks = new List<Rack>()
                {
                    new Rack {Height = 2, Width = 2,},
                    new Rack {Height = 3, Width = 3,}
                }

            };
            storage.Generate();
            context.Storages.Add(storage);
            context.SaveChanges();

            var pallet = new Pallet[]
            {
                new Pallet{},
                new Pallet{},
                new Pallet{},
            };


            foreach (var item in pallet)
            {
                context.Pallets.Add(item);
            }
            context.SaveChanges();

            var stock = new StockItem[]
            {
                new StockItem { Name = "Cola", Amount = 1000},
                new StockItem { Name = "Cola Light", Amount = 1000},
                new StockItem { Name = "Cola Zero", Amount = 1000},
                new StockItem { Name = "Cola Cherry", Amount = 1000},
            };
            foreach (var item in stock)
            {
                context.StockItems.Add(item);
            }
            context.SaveChanges();


           
        }
    }
}
