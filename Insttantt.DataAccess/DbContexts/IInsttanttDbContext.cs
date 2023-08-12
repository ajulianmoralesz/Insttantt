using Insttantt.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insttantt.DataAccess.DbContexts
{
    public interface IInsttanttDbContext
    {
        Task<int> SaveChangesAsync();
        DbSet<Step> Steps { get; set; }
        DbSet<Field> Fields { get; set; }
        DbSet<FieldOptionValue> FieldOptionValues { get; set; }
        DbSet<Flow> Flows { get; set; }
        DbSet<FlowStep> FlowSteps { get; set; }
        DbSet<FlowStepField> FlowStepsFields { get; set; }
        DbSet<FlowExecution> FlowExecutions { get; set; }
        DbSet<FlowExecutionField> FlowExecutionFields { get; set; }
    }
}
