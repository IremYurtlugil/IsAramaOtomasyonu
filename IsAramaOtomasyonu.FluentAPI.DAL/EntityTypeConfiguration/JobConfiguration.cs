using IsAramaOtomasyonu.FluentAPI.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsAramaOtomasyonu.FluentAPI.DAL.EntityTypeConfiguration
{
    class JobConfiguration : IEntityTypeConfiguration<Job>
    {
        public void Configure(EntityTypeBuilder<Job> builder)
        {
            builder.HasKey(a => a.JobId);
            builder.Property(a => a.Position)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(a => a.Description)
                 .IsRequired();

            builder.Property(a => a.Salary).HasPrecision(8, 2); //123,45
        }
    }
}
