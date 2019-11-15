using LagerSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace LagerSystem.Data
{
    public class StorageContext : DbContext
    {
        public StorageContext(DbContextOptions<StorageContext> options) : base(options)
        {
        }

        public DbSet<Storage> Storages { get; set; }
        public DbSet<Rack> Racks { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Pallet> Pallets { get; set; }
        public DbSet<Item> Items { get; set; }

        protected override void OnModelCreating(ModelBuilder model)
        {
            model.Entity<Rack>()
                 .HasMany(p => p.Positions)
                 .WithOne(r => r.Rack);
        }
    }
}
