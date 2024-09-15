using JuliePro.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuliePro.Data
{
    public class JulieProDbContext : DbContext
    {
        public JulieProDbContext(DbContextOptions<JulieProDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Générer des données de départ
            modelBuilder.GenerateData();
        }

        public DbSet<Speciality> Speciality { get; set; }
        public DbSet<Trainer> Trainer { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Objective> Objective { get; set; }
    }
}
