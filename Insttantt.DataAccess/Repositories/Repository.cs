using Insttant.DataAccess.Repositories;
using Insttantt.DataAccess.DbContexts;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage;
using System.Linq.Expressions;
using System.Reflection;

namespace Insttantt.DataAccess.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected InsttanttDbContext DbContext { get; set; }
        protected DbSet<T> DbSet { get; set; }

        public Repository(InsttanttDbContext dbContext)
        {
            DbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext), "dbContext it's Null");
            DbSet = DbContext.Set<T>();
        }

        public virtual IQueryable<T> GetAll()
        {
            return DbSet;
        }

        public virtual async Task<bool> AllAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken)
        {
            return await DbSet.AllAsync(predicate, cancellationToken);
        }

        public virtual IQueryable<T> GetAllActive()
        {
            var arg = Expression.Parameter(typeof(T), "p");
            var body = Expression.Call(Expression.Property(arg, "Active"), "Equals", null, Expression.Constant(true));
            var predicate = Expression.Lambda<Func<T, bool>>(body, arg);

            return DbSet.Where(predicate);
        }
        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await DbSet.FindAsync(id);
        }
        public virtual async Task<T> GetByIdAsync(string id)
        {
            return await DbSet.FindAsync(id);
        }
        public virtual async Task<List<T>> ToListAsync()
        {
            return await DbSet.ToListAsync();
        }
        public virtual T Add(T entity)
        {
            try
            {
                var dbEntityEntry = DbContext.Entry<T>(entity);
                if (dbEntityEntry.State == EntityState.Detached)
                {
                    DbSet.Add(entity);
                }
                dbEntityEntry.State = EntityState.Added;

                return dbEntityEntry.Entity;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
        public virtual async void AddAsync(T entity)
        {
            EntityEntry dbEntityEntry = DbContext.Entry(entity);
            if (dbEntityEntry.State == EntityState.Detached)
            {
                await DbSet.AddAsync(entity);
            }
            dbEntityEntry.State = EntityState.Added;
        }
        public virtual void AddRange(List<T> entities)
        {
            DbContext.AddRange(entities);
        }
        public virtual async void AddRangeAsync(T[] entities)
        {
            await DbContext.AddRangeAsync(entities);
        }
        public virtual void DeleteRangeAsync(T[] entities)
        {
            DbContext.RemoveRange(entities);
        }
        public virtual void Update(T entity)
        {
            EntityEntry dbEntityEntry = DbContext.Entry(entity);
            if (dbEntityEntry.State == EntityState.Detached)
            {
                DbSet.Attach(entity);
            }
            dbEntityEntry.State = EntityState.Modified;
        }

        // DELETE
        public virtual async void DeleteAsync(int id)
        {
            var entity = await this.GetByIdAsync(id);
            if (entity == null) return;
            EntityEntry dbEntityEntry = DbContext.Entry(entity);
            if (dbEntityEntry.State == EntityState.Deleted)
            {
                DbSet.Attach(entity);
                DbSet.Remove(entity);
            }
            dbEntityEntry.State = EntityState.Deleted;
        }
        public virtual async void DeactivateAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity == null) return;
            PropertyInfo active = entity.GetType().GetProperty("Active");
            if (active != null)
            {
                active.SetValue(entity, true, null);
            }

            EntityEntry dbEntityEntry = DbContext.Entry(entity);
            if (dbEntityEntry.State == EntityState.Detached)
            {

                DbSet.Attach(entity);
            }
            dbEntityEntry.State = EntityState.Modified;
        }
        public virtual void Deactivate(T entity)
        {
            DbContext.Entry(entity).State = EntityState.Unchanged;
            entity.GetType().GetProperty("Active")?.SetValue(entity, false);
            DbContext.Entry(entity).Property("Active").IsModified = true;
        }
        public async Task<bool> SaveAsync(CancellationToken cancellationToken)
        {
            return (await DbContext.SaveChangesAsync(cancellationToken)) > 0;
        }
        public bool Save() => (DbContext.SaveChanges()) > 0;

        public IQueryable<T> GetAllIncluding(params Expression<Func<T, object>>[] includeProperties)
        {
            return includeProperties.Aggregate<Expression<Func<T, object>>, IQueryable<T>>(DbSet, (current, includeProperty) => current.Include(includeProperty));
        }

        public async Task<IEnumerable<T>> GetByConditionsAsync(Expression<Func<T, bool>> expression)
        {
            return await DbSet.Where(expression).ToListAsync();
        }

        public IDbContextTransaction BeginTransaction()
        {
            return DbContext.Database.BeginTransaction();
        }

        public async Task<IEnumerable<T>> ExecuteStoreProcedure(string storeProcedure, SqlParameter[] parameters)
        {
            return await DbSet.FromSqlRaw($"EXEC {storeProcedure}", parameters).ToListAsync();
        }

        public async Task<IEnumerable<T>> ExecuteStoreProcedure(string storeProcedure, Dictionary<string, object> parameters)
        {
            var spparams = parameters.Select(x => new SqlParameter($"@{x.Key}", x.Value)).ToArray();
            return await DbSet.FromSqlRaw($"EXEC {storeProcedure}", spparams).ToListAsync();
        }
    }
}