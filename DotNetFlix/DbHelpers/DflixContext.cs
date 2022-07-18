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
    public DflixContext(DbContextOptions options) : base(options) {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<CartDAL>()
              .HasMany(a => a.CartItems)
              .WithOne(e => e.CartDAL)
              .IsRequired();

        modelBuilder.Entity<CartItemDAL>()
              .HasOne(a => a.MovieDAL);


        modelBuilder.Entity<UserDAL>().HasData(new UserDAL
        {
            UserId = 1,
            UserFirstName = "John",
            UserLastName = "Snow",
        });
    }

    public DbSet<UserDAL> Users { get; set; }
    public DbSet<MovieDAL> Movies { get; set; }
    public DbSet<CartDAL> Carts { get; set; }
    public DbSet<CartItemDAL> CartItems { get; set; }

    /*
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<ShoppingCartItemDAL>()
            .HasOne(x => x.MovieDAL);

        modelBuilder.Entity<ShoppingCartItemDAL>()
            .HasOne<UserDAL>(s => s.UserDAL)
            .WithMany(g => g.ShoppingCartItems)
            .HasForeignKey(s => s.UserForeignKey);
    }
    */
}
