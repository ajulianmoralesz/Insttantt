using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insttantt.DataAccess.Repositories
{
    public interface IMongoRepository<T> where T : class
    {
        Task<T> Insert(T entity);
        Task InsertRange(List<T> entities);
    }
}
