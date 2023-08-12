using System.Linq.Expressions;

namespace Insttant.DataAccess.Repositories
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        Task<bool> AllAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken);
        IQueryable<T> GetAllIncluding(params Expression<Func<T, object>>[] includeProperties);
        Task<IEnumerable<T>> GetByConditionsAsync(Expression<Func<T, bool>> expression);
        IQueryable<T> GetAllActive();
        T Add(T entity);
        void AddRange(List<T> entities);
        void AddAsync(T entity);
        void AddRangeAsync(T[] entities);
        void Update(T entity);
        void DeleteAsync(int id);
        void DeleteRangeAsync(T[] entities);
        void DeactivateAsync(int id);
        void Deactivate(T entity);
        Task<T> GetByIdAsync(int id);
        Task<T> GetByIdAsync(string id);
        bool Save();
        Task<bool> SaveAsync(CancellationToken cancellationToken);
        Task<List<T>> ToListAsync();
        Task<IEnumerable<T>> ExecuteStoreProcedure(string storeProcedure, Dictionary<string, object> parameters);

    }
}
