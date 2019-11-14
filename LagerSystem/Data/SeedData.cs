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

            var items = new Item[]
            {
                new Item {Amount = 11, Name = "Cola", PalletId = pallet.Single(i => i.Id == 1).Id},
                new Item {Amount = 1, Name = "Toilet", PalletId = pallet.Single(i => i.Id == 2).Id},
                new Item {Amount = 100, Name = "Playstation", PalletId = pallet.Single(i => i.Id == 3).Id},
            };

            foreach (var item in items)
            {
                context.Items.Add(item);
            }
            context.SaveChanges();

           
        }
    }
}
