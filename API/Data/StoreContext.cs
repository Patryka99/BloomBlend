using API.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public class StoreContext : DbContext
{
    public StoreContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<Size> Sizes { get; set; }
    public DbSet<ProductsSizes> ProductsSizes { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Product>()
                .HasMany(s => s.Sizes)
                .WithMany(p => p.Products)
                .UsingEntity<ProductsSizes>(
                    u => u.HasOne(wit => wit.Size)
                        .WithMany()
                        .HasForeignKey(wit => wit.SizeId),

                    u => u.HasOne(wit => wit.Product)
                        .WithMany()
                        .HasForeignKey(wit => wit.ProductId),

                    wit =>
                    {
                        wit.HasKey(x => x.Id);
                    }
                    );
        }



            // builder.Entity<User>()
            //     .HasOne(a => a.Address)
            //     .WithOne()
            //     .HasForeignKey<UserAddress>(a => a.Id)
            //     .OnDelete(DeleteBehavior.Cascade);

        // builder.Entity<Role>()
        //     .HasData(
        //         new Role{Id = 1, Name = "Member", NormalizedName ="MEMBER"},
        //         new Role{Id = 2, Name = "Admin", NormalizedName ="ADMIN"}
        //     );
        
}
