using Insttantt.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insttantt.DataAccess.Configurations
{
    public class FieldOptionValueConfig : IEntityTypeConfiguration<FieldOptionValue>
    {
        public void Configure(EntityTypeBuilder<FieldOptionValue> builder)
        {
            builder.ToTable("FieldOptionValue");

            builder.AddDefaultConfig();

            builder.Property(x => x.IdField)
                .HasColumnType("int")
                .IsRequired();

            builder.Property(x => x.Value)
                .HasMaxLength(50)
                .IsRequired();

            builder.HasOne(x => x.Field).WithMany(x=> x.fieldOptionValues).HasPrincipalKey(x=> x.Id).HasForeignKey(x=>x.IdField).HasConstraintName("FK_FieldOptionValue_Field");
        }
    }
}
