
using IsAramaOtomasyonu.FluentAPI.DAL.EntityTypeConfiguration;
using IsAramaOtomasyonu.FluentAPI.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsAramaOtomasyonu.FluentAPI.DAL
{
    class IsOtomasyonuDbContext : DbContext
    {
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<FringeBenefit> FringeBenefits { get; set; }
        public DbSet<ObjectionableWord> ObjectionableWords { get; set; }
        public DbSet<QualityScore> QualityScores { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.; Database=IsAramaOtomasyonuDB; uid=sa; pwd=Gizem123");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CompanyConfiguration());
            modelBuilder.ApplyConfiguration(new FringeBenefitConfiguration());
            modelBuilder.ApplyConfiguration(new JobConfiguration());
            modelBuilder.ApplyConfiguration(new ObjectionableWordConfiguration());
            modelBuilder.ApplyConfiguration(new QualityScoreConfiguration());
        }

    }
}
