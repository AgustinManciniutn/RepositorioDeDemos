using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using sigmaHashAlpha.Infrastructure.Reservations;
using sigmaHashAlpha.Infrastructure.Roles;
using sigmaHashAlpha.Models;
using sigmaHashAlpha.Models.Products;

namespace sigmaHashAlpha.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
        
    }
    protected override void OnModelCreating(ModelBuilder builder)
    {


        base.OnModelCreating(builder);
        //builder.ApplyConfiguration(new ApplicationManagerEntityConfiguration());
    }
    public DbSet<RoledUsers> RoledUsers { get; set; }
    public DbSet<ProductList> Products { get; set; }
    public DbSet<ProductImage> ProductImages { get; set; }
    public DbSet<GPU> Gpus { get; set; }
    public DbSet<CPU> Cpus { get; set; }
    public DbSet<RAM> Rams { get; set; }
    public DbSet<Motherboard> Motherboards { get; set; }
    public DbSet<PSU> Psus { get; set; }
    public DbSet<Mouse> Mouses { get; set; }
    public DbSet<Keyboard> Keyboards { get; set; }
    public DbSet<GMonitor> Monitors { get; set; }
    public DbSet<Storage> Storages { get; set; }
    public DbSet<Case> Cases { get; set; }
    public DbSet<Miscellaneous> Miscellaneous { get; set; }
    public DbSet<Reservation> Reservations { get; set; }
    public DbSet<Sale> Sales { get; set; }
    public DbSet<ReservationItem> ReservationItems { get; set; }
    public DbSet<User_Reservation> UserReservations { get; set; }

}