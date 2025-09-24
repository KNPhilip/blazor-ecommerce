using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Domain.Models;

namespace DataAccess.Data;

public sealed class EcommerceContext : IdentityDbContext<DbUser>
{
    public EcommerceContext(DbContextOptions<EcommerceContext> options) : base(options)
    {
    }

    public EcommerceContext()
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BlazorEcommerce;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<DbUser>()
            .HasData(DataSeeder.SeedPublishers());

        modelBuilder.Entity<Category>()
            .HasData(DataSeeder.SeedCategories());

        modelBuilder.Entity<ProductType>()
            .HasData(DataSeeder.SeedProductTypes());

        modelBuilder.Entity<Product>()
            .HasData(DataSeeder.SeedProducts());

        modelBuilder.Entity<Image>()
            .HasData(DataSeeder.SeedImages());

        modelBuilder.Entity<ProductVariant>()
            .HasData(DataSeeder.SeedProductVariants());

        modelBuilder.Entity<ProductVariant>()
            .HasKey(p => new { p.ProductId, p.ProductTypeId });

        modelBuilder.Entity<CartItem>()
            .HasKey(ci => new { ci.UserId, ci.ProductId, ci.ProductTypeId });

        modelBuilder.Entity<OrderItem>()
            .HasKey(oi => new { oi.OrderId, oi.ProductId, oi.ProductTypeId });

        modelBuilder.Entity<Product>()
            .HasMany(p => p.Publishers)
            .WithMany(u => u.PublishedProducts)
            .UsingEntity<Dictionary<string, object>>(
                "ProductPublishers",
                j => j
                    .HasOne<DbUser>()
                    .WithMany()
                    .HasForeignKey("PublisherId")
                    .HasPrincipalKey(u => u.Id),
                j => j
                    .HasOne<Product>()
                    .WithMany()
                    .HasForeignKey("ProductId")
                    .HasPrincipalKey(p => p.Id),
                j =>
                {
                    j.HasKey("ProductId", "PublisherId");
                    j.HasData(
                        new { ProductId = 1, PublisherId = "47fac782-04bb-45f0-8700-2b9a3b855984" },
                        new { ProductId = 2, PublisherId = "9904a3cc-92aa-43e4-a743-5bdc46374c6c" },
                        new { ProductId = 3, PublisherId = "d02c893b-5ed4-4e37-bac0-0b62bb50fcdb" },
                        new { ProductId = 4, PublisherId = "dc7b8125-6391-4774-b1f2-ad92281ed289" },
                        new { ProductId = 5, PublisherId = "27045ac4-b1d1-4dbb-a13b-529456b1dad2" },
                        new { ProductId = 6, PublisherId = "bafc87aa-2221-4543-ac96-9f1e4aac691d" },
                        new { ProductId = 7, PublisherId = "35be5291-5ce0-4483-9e7d-9d60dc912f98" },
                        new { ProductId = 8, PublisherId = "a989fbed-3273-4342-bf5b-7724721e1504" },
                        new { ProductId = 9, PublisherId = "8567a393-058f-4ecb-a209-307dc6c8c8fa" },
                        new { ProductId = 10, PublisherId = "87ef6fb3-1a20-472e-b6d3-7599afb506e6" },
                        new { ProductId = 11, PublisherId = "c5534807-f265-41c6-afa8-fcbefabb164b" },
                        new { ProductId = 12, PublisherId = "3711943c-2d78-4a3f-b007-a6ee15ba0e7b" },
                        new { ProductId = 13, PublisherId = "0f39bc69-752a-495f-9e13-07b8d447e98f" },
                        new { ProductId = 14, PublisherId = "2bc82d0e-8b77-4a6a-84da-e79b618acbcf" },
                        new { ProductId = 15, PublisherId = "c5534807-f265-41c6-afa8-fcbefabb164b" },
                        new { ProductId = 16, PublisherId = "2bc82d0e-8b77-4a6a-84da-e79b618acbcf" },
                        new { ProductId = 17, PublisherId = "c5534807-f265-41c6-afa8-fcbefabb164b" },
                        new { ProductId = 18, PublisherId = "c5534807-f265-41c6-afa8-fcbefabb164b" },
                        new { ProductId = 19, PublisherId = "c5534807-f265-41c6-afa8-fcbefabb164b" },
                        new { ProductId = 20, PublisherId = "c5534807-f265-41c6-afa8-fcbefabb164b" },
                        new { ProductId = 21, PublisherId = "8a57c8e1-08f3-42b5-9671-cbc84976fb01" },
                        new { ProductId = 22, PublisherId = "e2e7e873-a404-4c13-bd5e-8c10a046c168" },
                        new { ProductId = 23, PublisherId = "e29ae0f4-c7d1-4a08-bfbb-b1fcbf2f391d" },
                        new { ProductId = 24, PublisherId = "354f78e9-61bc-4f6e-8761-3cfab3749d42" },
                        new { ProductId = 25, PublisherId = "e29ae0f4-c7d1-4a08-bfbb-b1fcbf2f391d" },
                        new { ProductId = 26, PublisherId = "e29ae0f4-c7d1-4a08-bfbb-b1fcbf2f391d" },
                        new { ProductId = 27, PublisherId = "a73f5524-6667-4a81-a1a0-1b3e3bbc432f" },
                        new { ProductId = 28, PublisherId = "7260b1d5-3c97-4bd1-8bbd-1b0183bb2393" },
                        new { ProductId = 29, PublisherId = "448d440b-c1c4-453c-8cda-608fedad3762" },
                        new { ProductId = 30, PublisherId = "d6c9880a-9926-400f-86da-79dc08234f33" },
                        new { ProductId = 31, PublisherId = "8b1922c7-8118-474b-aa7b-032bec00234c" },
                        new { ProductId = 32, PublisherId = "7c4df877-bffb-4cbd-8417-097cff415a03" }
                    );
                });
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<ProductType> ProductTypes { get; set; }
    public DbSet<ProductVariant> ProductVariants { get; set; }
    public DbSet<CartItem> CartItems { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Image> Images { get; set; }
}
