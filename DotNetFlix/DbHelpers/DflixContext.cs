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
    public DbSet<MovieDAL> Posts { get; set; }
}
