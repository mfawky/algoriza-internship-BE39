using MedPro.CORE.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MedPro.EF.Repositories
{
    public class GenericRepository<T, K> : IGenericRepository<T, K> where T : class
    {
        private readonly ApplicationDbContext _context;
        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(T item) => await _context.Set<T>().AddAsync(item);

        public T Delete(K id)
        {
            var result = _context.Set<T>().Find(id);
            if (result == null)
            {
                return null;
            }
            _context.Remove(result);
            return result;
        }

        public async Task<T> DeleteUserDependentItemAsync(K id1, string id2)
        {
            var result = await _context.Set<T>().FindAsync(id2, id1);

            if (result == null)
            {
                return null;
            }

            _context.Remove(result);

            return result;
        }

        public async Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> criteria)
                    => await _context.Set<T>().Where(criteria).ToListAsync();

        public async Task<T> FindByIdAsync(K id) => await _context.Set<T>().FindAsync(id);
        public async Task<T> FindOneAsync(Expression<Func<T, bool>> criteria)
                    => await _context.Set<T>().FirstOrDefaultAsync(criteria);

        public async Task<IEnumerable<T>> GetAllAsync()
                    => await _context.Set<T>().ToListAsync();

        public async Task<T> GetAsync(K id)
                    => await _context.Set<T>().FindAsync(id);

        public int GetCount() => _context.Set<T>().Count();


        public async Task UpdateAsync(K id, T item)
        {
            var result = await _context.Set<T>().FindAsync(id);
            if (result != null)
                _context.Entry(item).State = EntityState.Modified;
        }
    }
}

