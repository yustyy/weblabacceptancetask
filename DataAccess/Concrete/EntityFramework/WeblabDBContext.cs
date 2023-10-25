using System;
using Core.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Drawing;
using System.Runtime.ConstrainedExecution;
using static System.Collections.Specialized.BitVector32;

namespace DataAccess.Concrete.EntityFramework
{
    public class WeblabDBContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host =localhost; Database =weblabtaskDB; Username =postgres;");
        }

       public DbSet<User> users {get; set; }


    }
}

