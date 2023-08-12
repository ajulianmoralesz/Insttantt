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

            //builder.HasData(
            //    new FieldOptionValue() { Id=1, IdField = 5, Value = "CC", Active = true, CreatedBy = "unknow", CreatedOn = DateTime.Now, ModifiedBy = "unknow", ModifiedOn = DateTime.Now },
            //    new FieldOptionValue() { Id=2, IdField = 5, Value = "NIT", Active = true, CreatedBy = "unknow", CreatedOn = DateTime.Now, ModifiedBy = "unknow", ModifiedOn = DateTime.Now },
            //    new FieldOptionValue() { Id=3, IdField = 5, Value = "TI", Active = true, CreatedBy = "unknow", CreatedOn = DateTime.Now, ModifiedBy = "unknow", ModifiedOn = DateTime.Now },
            //    new FieldOptionValue() { Id=4, IdField = 9, Value = "GET", Active = true, CreatedBy = "unknow", CreatedOn = DateTime.Now, ModifiedBy = "unknow", ModifiedOn = DateTime.Now },
            //    new FieldOptionValue() { Id=5, IdField = 9, Value = "POST", Active = true, CreatedBy = "unknow", CreatedOn = DateTime.Now, ModifiedBy = "unknow", ModifiedOn = DateTime.Now },
            //    new FieldOptionValue() { Id=6, IdField = 9, Value = "PUT", Active = true, CreatedBy = "unknow", CreatedOn = DateTime.Now, ModifiedBy = "unknow", ModifiedOn = DateTime.Now },
            //    new FieldOptionValue() { Id=7, IdField = 9, Value = "DELETE", Active = true, CreatedBy = "unknow", CreatedOn = DateTime.Now, ModifiedBy = "unknow", ModifiedOn = DateTime.Now }
            //    );
        }
    }
}
