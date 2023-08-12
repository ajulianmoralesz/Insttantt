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
    public class FlowStepConfig : IEntityTypeConfiguration<FlowStep>
    {
        public void Configure(EntityTypeBuilder<FlowStep> builder)
        {
            builder.ToTable("FlowStep");

            builder.AddDefaultConfig();

            builder.Property(x => x.IdStep)
                .HasColumnType("int")
                .IsRequired();

            builder.Property(x => x.IdFlow)
                .HasColumnType("int")
                .IsRequired();



            builder.HasOne(x => x.Flow).WithMany(x => x.Steps).HasPrincipalKey(x=> x.Id).HasForeignKey(x=> x.IdFlow).HasConstraintName("FK_FlowStep_Flow");
            builder.HasOne(x => x.Step).WithMany(x => x.FlowSteps).HasPrincipalKey(x=> x.Id).HasForeignKey(x=> x.IdStep).HasConstraintName("FK_FlowStep_Step");
        }
    }
}
