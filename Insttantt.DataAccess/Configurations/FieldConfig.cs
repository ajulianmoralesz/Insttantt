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
    public class FieldConfig : IEntityTypeConfiguration<Field>
    {
        public void Configure(EntityTypeBuilder<Field> builder)
        {
            builder.ToTable("Field");

            builder.AddDefaultConfig();

            builder.Property(x => x.Code)
                .HasMaxLength(10)
                .IsRequired();

            builder.Property(x => x.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder.HasData(
                new Field() { Id = 1, Code = "F-0001", Name = "Valor X", Active = true, CreatedBy = "unknow", CreatedOn = DateTime.Now, ModifiedBy = "unknow", ModifiedOn = DateTime.Now },
                new Field() { Id = 2, Code = "F-0002", Name = "Valor Y", Active = true, CreatedBy = "unknow", CreatedOn = DateTime.Now, ModifiedBy = "unknow", ModifiedOn = DateTime.Now },
                new Field() { Id = 3, Code = "F-0003", Name = "Resultado Suma", Active = true, CreatedBy = "unknow", CreatedOn = DateTime.Now, ModifiedBy = "unknow", ModifiedOn = DateTime.Now },
                new Field() { Id = 4, Code = "F-0004", Name = "Resultado Resta", Active = true, CreatedBy = "unknow", CreatedOn = DateTime.Now, ModifiedBy = "unknow", ModifiedOn = DateTime.Now },
                new Field() { Id = 5, Code = "F-0005", Name = "Resultado Multiplicación", Active = true, CreatedBy = "unknow", CreatedOn = DateTime.Now, ModifiedBy = "unknow", ModifiedOn = DateTime.Now },
                new Field() { Id = 6, Code = "F-0006", Name = "Resultado División", Active = true, CreatedBy = "unknow", CreatedOn = DateTime.Now, ModifiedBy = "unknow", ModifiedOn = DateTime.Now },
                new Field() { Id = 7, Code = "F-0007", Name = "Resultado Compuesta", Active = true, CreatedBy = "unknow", CreatedOn = DateTime.Now, ModifiedBy = "unknow", ModifiedOn = DateTime.Now }
                );
        }
    }
}
