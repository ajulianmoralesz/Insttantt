using Insttantt.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Insttantt.DataAccess.Configurations
{
    public class FlowExecutionConfig : IEntityTypeConfiguration<FlowExecution>
    {
        public void Configure(EntityTypeBuilder<FlowExecution> builder)
        {
            builder.ToTable("FlowExecution");

            builder.AddDefaultConfig();

            builder.Property(x => x.IdFlow)
                .HasColumnType("int")
                .IsRequired();

            builder.Property(x => x.IsDone)
                .HasColumnType("bit")
                .HasDefaultValue(false)
                .IsRequired();

            builder.HasOne(x => x.Flow).WithMany(x => x.Executions).HasPrincipalKey(x=> x.Id).HasForeignKey(x=> x.IdFlow).HasConstraintName("FK_FlowExecution_Flow");
        }
    }
}
