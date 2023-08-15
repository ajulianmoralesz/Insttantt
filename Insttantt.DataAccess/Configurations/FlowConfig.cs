using Insttantt.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Insttantt.DataAccess.Configurations
{
    public class FlowConfig : IEntityTypeConfiguration<Flow>
    {
        public void Configure(EntityTypeBuilder<Flow> builder)
        {
            builder.ToTable("Flow");

            builder.AddDefaultConfig();

            builder.Property(x => x.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.Description)
                .HasMaxLength(200)
                .IsRequired(false);

            builder.HasData(new Flow() { Id = 1, Name = "Flujo de Prueba", Description="Flujo con operaciones matematicas que dependen de la primera entrada de variables", Active = true, CreatedBy = "unknow", CreatedOn = DateTime.Now, ModifiedBy = "unknow", ModifiedOn = DateTime.Now });
             
        }
    }
}
