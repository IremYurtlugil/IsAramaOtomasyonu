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
    class QualityScoreConfiguration : IEntityTypeConfiguration<QualityScore>
    {
        public void Configure(EntityTypeBuilder<QualityScore> builder)
        {
            builder.Property(a => a.Description)
               .IsRequired()
               .HasMaxLength(50);

            builder.HasIndex(a => a.Description).IsUnique();

            builder.HasData(new List<QualityScore>()
            {
                new QualityScore { QualityScoreId=1, Description="Type Specified", Point=1 },
                new QualityScore { QualityScoreId=2, Description="Salary Specified", Point=1 },
                new QualityScore { QualityScoreId=3, Description="Fringe Benefit Specified", Point=1 },
                new QualityScore { QualityScoreId=4, Description="Not Use Objectionable Words", Point=2 },
            });
        }
    }
}
