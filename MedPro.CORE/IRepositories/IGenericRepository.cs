using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MedPro.CORE.IRepositories
{
    public interface IGenericRepository<T, K> where T : class
    {
        Task<T> GetAsync(K id);
        Task<IEnumerable<T>> GetAllAsync();
        Task AddAsync(T item);
        Task UpdateAsync(K id, T item);
        T Delete(K id);
        Task<T> DeleteUserDependentItemAsync(K id1, string id2);
        Task<T> FindByIdAsync(K id);
        Task<T> FindOneAsync(Expression<Func<T, bool>> criteria);
        Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> criteria);
        int GetCount();
    }
}
