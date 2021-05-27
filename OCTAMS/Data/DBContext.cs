using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OCTAMS.Data.Entites;
using OCTAMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore;


namespace OCTAMS.Data
{
    public class DBContext : IdentityDbContext<Users>
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {
           
        }
        public DbSet<Register> Register { get; set; }
        public DbSet<Story> Story { get; set; }
        public DbSet<Questions> Questions { get; set; }
        public DbSet<Articles> Articles { get; set; }
        public DbSet<Volunteer> Volunteers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }

}
