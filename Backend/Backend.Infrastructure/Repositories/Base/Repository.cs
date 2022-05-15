using Backend.Core.Repositories.Base;
using Backend.Infrastructure.DataContext;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.Repositories.Base
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly TallerContext _tallerContext;

        public Repository(TallerContext pTallerContext)
        {
            _tallerContext = pTallerContext;
        }

        public async Task<T> AddAsync(T entity)
        {
            await _tallerContext.Set<T>().AddAsync(entity);
            await _tallerContext.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            _tallerContext.Set<T>().Remove(entity);
            await _tallerContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _tallerContext.Set<T>().ToListAsync();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await _tallerContext.Set<T>().FindAsync(id);
        }

        public async Task UpdateAsync(T entity)
        {
            _tallerContext.Set<T>().Update(entity);
            await _tallerContext.SaveChangesAsync();
        }
    }
}
