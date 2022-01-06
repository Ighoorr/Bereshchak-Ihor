using System;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1
{
    public class AppDBContext:DbContext
    {
      public DbSet<Student> Students { get; set; }
      public DbSet<University> Universities { get; set; }





        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
            .UseSqlite(@"Data Source = Students.db;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<University>().Navigation(x => x.Students).AutoInclude();
            modelBuilder.Entity<Student>().Navigation(x => x.University).AutoInclude();
        }

    }




}