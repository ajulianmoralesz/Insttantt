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
    public class FlowExecutionFieldConfig : IEntityTypeConfiguration<FlowExecutionField>
    {
        public void Configure(EntityTypeBuilder<FlowExecutionField> builder)
        {
            builder.ToTable("FlowExecutionField");

            builder.AddDefaultConfig();

            builder.Property(x => x.IdFlowStepField)
                .HasColumnType("int")
                .IsRequired();

            builder.Property(x => x.IdFlowExecution)
                .HasColumnType("int")
                .IsRequired();

            builder.Property(x => x.value)
                .HasMaxLength(500)
                .IsRequired();

            builder.HasOne(x => x.FlowExecution).WithMany(x=> x.Fields).HasPrincipalKey(x=> x.Id).HasForeignKey(x=> x.IdFlowExecution).HasConstraintName("FK_FlowExecutionField_FlowExecution");
            builder.HasOne(x => x.FlowStepField).WithMany(x => x.FlowExecutionFields).HasPrincipalKey(x => x.Id).HasForeignKey(x => x.IdFlowStepField).HasConstraintName("FK_FlowExecutionField_FlowStepField").OnDelete(DeleteBehavior.NoAction);
        }
    }
}
