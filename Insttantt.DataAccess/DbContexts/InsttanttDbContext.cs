using Insttantt.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Insttantt.DataAccess.DbContexts
{
    public class InsttanttDbContext : DbContext, IInsttanttDbContext
    {
        public InsttanttDbContext(DbContextOptions<InsttanttDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
        }

        public Task<int> SaveChangesAsync()
        {
            return base.SaveChangesAsync();
        }

        #region DbSets

        public virtual DbSet<Step> Steps { get; set; }
        public virtual DbSet<Field> Fields { get; set; }
        public virtual DbSet<FieldOptionValue> FieldOptionValues { get; set; }
        public virtual DbSet<Flow> Flows { get; set; }
        public virtual DbSet<FlowStep> FlowSteps { get; set; }
        public virtual DbSet<FlowStepField> FlowStepsFields { get; set; }
        public virtual DbSet<FlowExecution> FlowExecutions { get; set; }
        public virtual DbSet<FlowExecutionField> FlowExecutionFields { get; set; }

        #endregion
    }
}
