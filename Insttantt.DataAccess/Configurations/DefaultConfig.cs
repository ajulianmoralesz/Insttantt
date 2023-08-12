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
    public static class DefaultConfig
    {
        public static void AddDefaultConfig<T>(this EntityTypeBuilder<T> builder) where T : class
        {
            builder.Property(x => (x as BaseEntity).Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("int")
                .UseIdentityColumn();

            builder.Property(x => (x as BaseEntity).CreatedBy)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => (x as BaseEntity).CreatedOn)
                .HasColumnType("datetime")
                .IsRequired();

            builder.Property(x => (x as BaseEntity).ModifiedBy)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => (x as BaseEntity).ModifiedOn)
                .HasColumnType("datetime")
                .IsRequired();

            builder.Property(x => (x as BaseEntity).Active)
                .HasColumnType("bit")
                .IsRequired();
        }
    }
}
