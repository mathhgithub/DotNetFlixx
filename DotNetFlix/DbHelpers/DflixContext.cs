using DotNetFlix.DbEntities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetFlix.DbHelpers;

public class DflixContext : DbContext
{
    public DflixContext(DbContextOptions options) : base(options)
    {

    }

    public DbSet<UserDAL> Users { get; set; }

    public DbSet<MovieDAL> Movies { get; set; }

    public DbSet<ShoppingCartItemDAL> CartItems { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<ShoppingCartItemDAL>()
            .HasOne(x => x.MovieDAL);

        modelBuilder.Entity<ShoppingCartItemDAL>()
            .HasOne<UserDAL>(s => s.UserDAL)
            .WithMany(g => g.ShoppingCartItems)
            .HasForeignKey(s => s.UserForeignKey);
    }
}
