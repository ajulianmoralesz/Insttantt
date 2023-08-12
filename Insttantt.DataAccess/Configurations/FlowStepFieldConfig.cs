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
    public class FlowStepFieldConfig : IEntityTypeConfiguration<FlowStepField>
    {
        public void Configure(EntityTypeBuilder<FlowStepField> builder)
        {
            builder.ToTable("FlowStepField");

            builder.AddDefaultConfig();

            builder.Property(x => x.IsOutput)
                .HasColumnType("bit")
                .IsRequired();

            builder.Property(x => x.IdField)
                .HasColumnType("int")
                .IsRequired();

            builder.Property(x => x.DefaultValue)
                .HasMaxLength(200)
                .HasDefaultValue("")
                .IsRequired(false);

            builder.Property(x => x.IdFlowStep)
                .HasColumnType("int")
                .IsRequired();

            builder.HasOne(x => x.FlowStep).WithMany(x => x.Fields).HasPrincipalKey(x=> x.Id).HasForeignKey(x=> x.IdFlowStep).HasConstraintName("FK_FlowStepField_FlowStep");
            builder.HasOne(x => x.Field).WithMany(x => x.FlowStepFields).HasPrincipalKey(x => x.Id).HasForeignKey(x => x.IdField).HasConstraintName("FK_FlowStepField_Field");
        }
    }
}
