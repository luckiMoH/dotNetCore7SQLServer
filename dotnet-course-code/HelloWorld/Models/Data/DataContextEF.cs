using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
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
        private IConfiguration _config;
        public DataContextEF(IConfiguration config)
        {
            _config = config;
        }
        public DbSet<Computer>? Computer { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured) //sprawdzenie, czy juz bylo skonfigurowane
            {
                options.UseSqlServer(_config.GetConnectionString("DefaultConnection"),
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
