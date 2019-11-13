using LagerSystem.Models;
using System.Collections.Generic;
using System.Linq;

namespace LagerSystem.Data
{
    public class SeedData
    {
        public  void InitData(StorageContext context)
        {
            //if (context.Storages.Any())
            //{
            //    return;
            //}

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
            context.Storages.Add(storage);
          //  context.SaveChanges();


            //Rack test = new Rack();
            //test.generate(storage.Racks);
            //Rack test1 = new Rack();
            //Rack test2 = new Rack();

            //context.Racks.Add(test);
            context.SaveChanges();
        }
    }
}
