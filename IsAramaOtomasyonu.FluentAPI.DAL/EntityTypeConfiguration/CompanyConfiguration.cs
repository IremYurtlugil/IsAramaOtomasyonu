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
    class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.ToTable("Company"); //company nesnesinin databasedeki tablo 
            builder.HasKey(a => a.CompanyId); //primary key
            // builder.Ignore(a => a.Address); //database de bir address kolonu 

            builder.Property(a => a.Address)
                .HasMaxLength(150)
                 .IsRequired();

            builder.Property(a => a.CompanyName)
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(a => a.PhoneNumber)
                .HasMaxLength(11)
                .IsRequired()
                .HasColumnType("char") //kolon tipi
                .HasColumnName("Phone"); //kolon adı

            builder.Property(a => a.Password)
                  .IsRequired();

            builder.HasIndex(a => a.PhoneNumber)
                .IsUnique(); //unique olarak işaretledik

            builder.Property(a => a.Address)
                .IsRequired();

            builder.Property(a => a.JobRight)
                .IsRequired();

        }
    }
}
