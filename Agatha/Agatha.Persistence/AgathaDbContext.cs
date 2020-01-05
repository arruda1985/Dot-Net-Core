using Agatha.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Agatha.Persistence
{
    public class AgathaDbContext : DbContext
    {
        public AgathaDbContext(DbContextOptions<AgathaDbContext> options) : base(options)
        {
        }

        public DbSet<Store> Stores { get; set; }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Contact> Contact { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<ProductImage> ProductImages { get; set; }

        public DbSet<Sale> Sales { get; set; }

        public DbSet<ProductSale> ProductsSale { get; set; }

        public DbSet<Address> Address { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
               .HasMany(p => p.Images)
               .WithOne(pi => pi.Product);

            modelBuilder.Entity<Sale>()
             .Property(p => p.Created)
             .HasColumnType("datetime2");

            modelBuilder.Entity<Sale>()
                  .HasMany(ps => ps.ProductsSale)
                  .WithOne(s => s.Sale);

            modelBuilder.Entity<Sale>()
                 .HasOne(ps => ps.Address);


            modelBuilder.Entity<Sale>()
                 .HasOne(ps => ps.Customer);

            modelBuilder.Entity<Customer>()
                  .HasMany(c => c.Addresses)
                  .WithOne(a => a.Customer);


            modelBuilder.Entity<Customer>()
                  .HasOne(c => c.Contact);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AgathaDbContext).Assembly);
        }
    }
}
