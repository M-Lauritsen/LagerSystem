using LagerSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LagerSystem.Data
{
    public class SeedData
    {
        public static void InitData(StorageContext context)
        {
            if (context.Storages.Any())
            {
                return;
            }

            var storage = new Storage()
            {
                StorageName = "Lager 1",
                NumberOfRacks = 2
            };

            context.Storages.Add(storage);
            context.SaveChanges();

            var racks = new Rack[]
            {
                new Rack { Id = 1, Height = 8, Width = 8},
                new Rack { Id = 2, Height = 4, Width = 4},
                new Rack { Id = 3, Height = 4, Width = 4},
                new Rack { Id = 4, Height = 8, Width = 8},
            };




        }
    }
}
