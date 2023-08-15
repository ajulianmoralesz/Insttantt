using Insttant.DataAccess.Repositories;
using Insttantt.DataAccess.DbContexts;
using Insttantt.DataAccess.Repositories;
using Insttantt.Domain.Configurations;
using Insttantt.Domain.Entities;
using Insttantt.Domain.Entities.Trace;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Insttantt.DataAccess
{
    public static class DataAccessDI
    {
        public static IServiceCollection AddDataAccess(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<InsttanttDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("InsttanttCon") ?? "",
                b => b.MigrationsAssembly(typeof(InsttanttDbContext).Assembly.FullName)), ServiceLifetime.Transient);

            services.AddScoped<IInsttanttDbContext>(provider => provider.GetService<InsttanttDbContext>());

            services.AddTransient<IMongoRepository<InsttanttLog>, MongoRepository<InsttanttLog>>();
            services.AddTransient<IMongoRepository<InsttanttInconsistency>, MongoRepository<InsttanttInconsistency>>();


            services.AddTransient<IRepository<Step>, Repository<Step>>();
            services.AddTransient<IRepository<Field>, Repository<Field>>();
            services.AddTransient<IRepository<FieldOptionValue>, Repository<FieldOptionValue>>();
            services.AddTransient<IRepository<Flow>, Repository<Flow>>();
            services.AddTransient<IRepository<FlowStep>, Repository<FlowStep>>();
            services.AddTransient<IRepository<FlowStepField>, Repository<FlowStepField>>();
            services.AddTransient<IRepository<FlowExecution>, Repository<FlowExecution>>();
            services.AddTransient<IRepository<FlowExecutionField>, Repository<FlowExecutionField>>();
            return services;
        }
    }
}
