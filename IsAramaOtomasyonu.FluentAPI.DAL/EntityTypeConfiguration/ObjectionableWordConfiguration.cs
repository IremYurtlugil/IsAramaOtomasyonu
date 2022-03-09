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
    class ObjectionableWordConfiguration : IEntityTypeConfiguration<ObjectionableWord>
    {
        public void Configure(EntityTypeBuilder<ObjectionableWord> builder)
        {
           builder.HasKey(a => a.ObjectionableWordId);
           builder.Property(a => a.Word)
                .IsRequired();

           builder.HasData(new List<ObjectionableWord>()
            {
                new ObjectionableWord { ObjectionableWordId=1, Word="beceriksiz" },
                new ObjectionableWord { ObjectionableWordId=2, Word="aptal" },
                new ObjectionableWord { ObjectionableWordId=3, Word="salak" }
            });

        }
    }
}
