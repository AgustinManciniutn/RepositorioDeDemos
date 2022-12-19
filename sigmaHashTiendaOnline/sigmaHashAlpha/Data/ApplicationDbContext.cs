using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using sigmaHashAlpha.Infrastructure.Reservations;
using sigmaHashAlpha.Infrastructure.Roles;
using sigmaHashAlpha.Models;
using sigmaHashAlpha.Models.Architecture;
using AProduct = sigmaHashAlpha.Models.Architecture.Product;

namespace sigmaHashAlpha.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
        
    }
    protected override void OnModelCreating(ModelBuilder builder)
    {

        builder.Entity<Attr>().HasOne<Category>(c => c.Category).WithMany(a => a.Attributes).HasForeignKey(c => c.CategoryId).OnDelete(DeleteBehavior.Cascade);

        builder.Entity<AttributeOption>().HasOne<Attr>(c => c.Attribute).WithMany(a => a.AttributeOptions).HasForeignKey(a => a.AttributeId).OnDelete(DeleteBehavior.Cascade).HasPrincipalKey(x => x.AttributeId);

        builder.Entity<ProductAttribute>().HasOne<AProduct>(p => p.Product).WithMany(c => c.ProductAttributes).HasForeignKey(a => a.ProductId).OnDelete(DeleteBehavior.Cascade).HasPrincipalKey(x => x.ProductId);


        base.OnModelCreating(builder);
        //builder.ApplyConfiguration(new ApplicationManagerEntityConfiguration());
    }
    public DbSet<RoledUsers> RoledUsers { get; set; }
    public DbSet<ProductImage> ProductImages { get; set; }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Attr> Attributes { get; set; }
    public DbSet<AttributeOption> AttributeOptions { get; set; }

    public DbSet<Product> Products { get; set; }

    public DbSet<ProductAttribute> ProductAttributes { get; set; }


    //public DbSet<CategoryAttribute> CategoryAttributes { get; set; }


    //public DbSet<GPU> Gpus { get; set; }
    //public DbSet<CPU> Cpus { get; set; }
    //public DbSet<RAM> Rams { get; set; }
    //public DbSet<Motherboard> Motherboards { get; set; }
    //public DbSet<PSU> Psus { get; set; }
    //public DbSet<Mouse> Mouses { get; set; }
    //public DbSet<Keyboard> Keyboards { get; set; }
    //public DbSet<GMonitor> Monitors { get; set; }
    //public DbSet<Storage> Storages { get; set; }
    //public DbSet<Case> Cases { get; set; }
    //public DbSet<Miscellaneous> Miscellaneous { get; set; }
    public DbSet<Reservation> Reservations { get; set; }
    public DbSet<Sale> Sales { get; set; }
    public DbSet<ReservationItem> ReservationItems { get; set; }
    public DbSet<User_Reservation> UserReservations { get; set; }

    public void DetachAllEntities()
    {
        var changedEntriesCopy = this.ChangeTracker.Entries()
            .Where(e => e.State == EntityState.Added ||
                        e.State == EntityState.Modified ||
                        e.State == EntityState.Deleted)
            .ToList();

        foreach (var entry in changedEntriesCopy)
            entry.State = EntityState.Detached;
    }

}