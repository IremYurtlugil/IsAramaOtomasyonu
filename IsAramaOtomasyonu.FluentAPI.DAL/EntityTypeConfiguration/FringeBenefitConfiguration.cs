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
    class FringeBenefitConfiguration : IEntityTypeConfiguration<FringeBenefit>
    {
        public void Configure(EntityTypeBuilder<FringeBenefit> builder)
        {
            builder.HasKey(a => a.FringeBenefitId);
            builder.Property(a => a.Description)
                .HasMaxLength(100)
                .IsRequired();

            builder.HasData(new List<FringeBenefit>()
            {
                new FringeBenefit { FringeBenefitId=1, Description="Yol" },
                new FringeBenefit { FringeBenefitId=2, Description="Yemek (Sodexo)" },
                new FringeBenefit { FringeBenefitId=3, Description="Çay Kahve Parası" },
                new FringeBenefit { FringeBenefitId=4, Description="Servis" }
            });
        }
    }
}
