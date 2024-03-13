using Microsoft.EntityFrameworkCore;
using SisMed.Models.Entities;
using SisMed.Models.EntityConfigurations;
using System;

namespace SisMed.Models.Contexts
{
    public class SisMedContext : DbContext
    {
        public SisMedContext(DbContextOptions<SisMedContext> options) : base(options)
        {

        }

        public DbSet<Medico> Medicos => Set<Medico>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MedicoConfiguration());
        }
    }
}
