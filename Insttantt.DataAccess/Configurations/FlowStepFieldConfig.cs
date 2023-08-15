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

            builder.Property(x => x.IdFlowStep)
                .HasColumnType("int")
                .IsRequired();

            builder.HasOne(x => x.FlowStep).WithMany(x => x.Fields).HasPrincipalKey(x=> x.Id).HasForeignKey(x=> x.IdFlowStep).HasConstraintName("FK_FlowStepField_FlowStep");
            builder.HasOne(x => x.Field).WithMany(x => x.FlowStepFields).HasPrincipalKey(x => x.Id).HasForeignKey(x => x.IdField).HasConstraintName("FK_FlowStepField_Field");

            builder.HasData(
                new FlowStepField() { Id = 1, IdFlowStep = 1, IdField = 1, IsOutput= false, Active = true, CreatedBy = "unknow", CreatedOn = DateTime.Now, ModifiedBy = "unknow", ModifiedOn = DateTime.Now },
                new FlowStepField() { Id = 2, IdFlowStep = 1, IdField = 2, IsOutput = false, Active = true, CreatedBy = "unknow", CreatedOn = DateTime.Now, ModifiedBy = "unknow", ModifiedOn = DateTime.Now },
                new FlowStepField() { Id = 3, IdFlowStep = 2, IdField = 1, IsOutput = false, Active = true, CreatedBy = "unknow", CreatedOn = DateTime.Now, ModifiedBy = "unknow", ModifiedOn = DateTime.Now },
                new FlowStepField() { Id = 4, IdFlowStep = 2, IdField = 2, IsOutput = false, Active = true, CreatedBy = "unknow", CreatedOn = DateTime.Now, ModifiedBy = "unknow", ModifiedOn = DateTime.Now },
                new FlowStepField() { Id = 5, IdFlowStep = 2, IdField = 3, IsOutput = true, Active = true, CreatedBy = "unknow", CreatedOn = DateTime.Now, ModifiedBy = "unknow", ModifiedOn = DateTime.Now },
                new FlowStepField() { Id = 6, IdFlowStep = 3, IdField = 1, IsOutput = false, Active = true, CreatedBy = "unknow", CreatedOn = DateTime.Now, ModifiedBy = "unknow", ModifiedOn = DateTime.Now },
                new FlowStepField() { Id = 7, IdFlowStep = 3, IdField = 2, IsOutput = false, Active = true, CreatedBy = "unknow", CreatedOn = DateTime.Now, ModifiedBy = "unknow", ModifiedOn = DateTime.Now },
                new FlowStepField() { Id = 8, IdFlowStep = 3, IdField = 4, IsOutput = true, Active = true, CreatedBy = "unknow", CreatedOn = DateTime.Now, ModifiedBy = "unknow", ModifiedOn = DateTime.Now },
                new FlowStepField() { Id = 9, IdFlowStep = 4, IdField = 1, IsOutput = false, Active = true, CreatedBy = "unknow", CreatedOn = DateTime.Now, ModifiedBy = "unknow", ModifiedOn = DateTime.Now },
                new FlowStepField() { Id = 10, IdFlowStep = 4, IdField = 2, IsOutput = false, Active = true, CreatedBy = "unknow", CreatedOn = DateTime.Now, ModifiedBy = "unknow", ModifiedOn = DateTime.Now },
                new FlowStepField() { Id = 11, IdFlowStep = 4, IdField = 5, IsOutput = true, Active = true, CreatedBy = "unknow", CreatedOn = DateTime.Now, ModifiedBy = "unknow", ModifiedOn = DateTime.Now },
                new FlowStepField() { Id = 12, IdFlowStep = 5, IdField = 1, IsOutput = false, Active = true, CreatedBy = "unknow", CreatedOn = DateTime.Now, ModifiedBy = "unknow", ModifiedOn = DateTime.Now },
                new FlowStepField() { Id = 13, IdFlowStep = 5, IdField = 2, IsOutput = false, Active = true, CreatedBy = "unknow", CreatedOn = DateTime.Now, ModifiedBy = "unknow", ModifiedOn = DateTime.Now },
                new FlowStepField() { Id = 14, IdFlowStep = 5, IdField = 6, IsOutput = true, Active = true, CreatedBy = "unknow", CreatedOn = DateTime.Now, ModifiedBy = "unknow", ModifiedOn = DateTime.Now },
                new FlowStepField() { Id = 15, IdFlowStep = 6, IdField = 3, IsOutput = false, Active = true, CreatedBy = "unknow", CreatedOn = DateTime.Now, ModifiedBy = "unknow", ModifiedOn = DateTime.Now },
                new FlowStepField() { Id = 16, IdFlowStep = 6, IdField = 4, IsOutput = false, Active = true, CreatedBy = "unknow", CreatedOn = DateTime.Now, ModifiedBy = "unknow", ModifiedOn = DateTime.Now },
                new FlowStepField() { Id = 17, IdFlowStep = 6, IdField = 5, IsOutput = false, Active = true, CreatedBy = "unknow", CreatedOn = DateTime.Now, ModifiedBy = "unknow", ModifiedOn = DateTime.Now },
                new FlowStepField() { Id = 18, IdFlowStep = 6, IdField = 6, IsOutput = false, Active = true, CreatedBy = "unknow", CreatedOn = DateTime.Now, ModifiedBy = "unknow", ModifiedOn = DateTime.Now },
                new FlowStepField() { Id = 19, IdFlowStep = 6, IdField = 7, IsOutput = true, Active = true, CreatedBy = "unknow", CreatedOn = DateTime.Now, ModifiedBy = "unknow", ModifiedOn = DateTime.Now }
                );
        }
    }
}
