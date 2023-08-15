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
    public class StepConfig : IEntityTypeConfiguration<Step>
    {
        public void Configure(EntityTypeBuilder<Step> builder)
        {
            builder.ToTable("Step");

            builder.AddDefaultConfig();

            builder.Property(x => x.Code)
                .HasMaxLength(10)
                .IsRequired();

            builder.Property(x => x.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.Url)
                .HasMaxLength(200)
                .IsRequired();

            builder.HasData(
                new Step() { Id = 1, Code = "STP-0001", Name = "Enviar Valores", Url = "https://localhost:7285/api/Parameters/inputparameters", Active = true, CreatedBy = "unknow", CreatedOn = DateTime.Now, ModifiedBy = "unknow", ModifiedOn = DateTime.Now },
                new Step() { Id = 2, Code = "STP-0002", Name = "Sumar", Url = "https://localhost:7285/api/Operation/adittion", Active = true, CreatedBy = "unknow", CreatedOn = DateTime.Now, ModifiedBy = "unknow", ModifiedOn = DateTime.Now },
                new Step() { Id = 3, Code = "STP-0003", Name = "Restar", Url = "https://localhost:7285/api/Operation/subtraction", Active = true, CreatedBy = "unknow", CreatedOn = DateTime.Now, ModifiedBy = "unknow", ModifiedOn = DateTime.Now },
                new Step() { Id = 4, Code = "STP-0004", Name = "Multiplicar", Url = "https://localhost:7285/api/Operation/multiplication", Active = true, CreatedBy = "unknow", CreatedOn = DateTime.Now, ModifiedBy = "unknow", ModifiedOn = DateTime.Now },
                new Step() { Id = 5, Code = "STP-0005", Name = "Dividir", Url = "https://localhost:7285/api/Operation/division", Active = true, CreatedBy = "unknow", CreatedOn = DateTime.Now, ModifiedBy = "unknow", ModifiedOn = DateTime.Now },
                new Step() { Id = 6, Code = "STP-0006", Name = "Operacion Compuesta", Url = "https://localhost:7285/api/Operation/compound", Active = true, CreatedBy = "unknow", CreatedOn = DateTime.Now, ModifiedBy = "unknow", ModifiedOn = DateTime.Now }
                );
        }
    }
}
