using Microsoft.EntityFrameworkCore;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Data
{
    internal class DataContextEF : DbContext
    {
        public DbSet<Computer>? Computer { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured) //sprawdzenie, czy juz bylo skonfigurowane
            {
                options.UseSqlServer("Server=localhost;Database=DotNetCourseDatabase;TrustServerCertificate=true;Trusted_Connection=true;",
                    options => options.EnableRetryOnFailure());
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("TutorialAppSchema"); //ustawienie defaultowego schema

            modelBuilder.Entity<Computer>()
                //.HasNoKey(); // gdy nie ma klucza
                .HasKey(c => c.ComputerId); // gdy jakas wartość jest kluczem, jest niepowtarzalna
                //.ToTable("Computer", "TutorialAppSchema"); //wybór tabeli Computer w TutorialAppSchema
                //.ToTable("TableName", "SchemaName");
        }
    }
}
