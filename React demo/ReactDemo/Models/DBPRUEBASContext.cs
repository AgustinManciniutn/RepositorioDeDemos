using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ReactDemo.Models;

namespace ReactDemo.Models;

public class ApplicationDbContext : DbContext
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
    public DbSet<Product> ReactProducts { get; set; }


}