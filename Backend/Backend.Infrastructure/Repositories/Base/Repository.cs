using Backend.Core.Repositories.Base;
using Backend.Infrastructure.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

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

        public async Task<T> DeleteAsync(T entity)
        {
            EntityEntry<T> mEntity = _tallerContext.Set<T>().Remove(entity);
            await _tallerContext.SaveChangesAsync();

            return mEntity.Entity;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _tallerContext.Set<T>().ToListAsync();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await _tallerContext.Set<T>().FindAsync(id);
        }

        public async Task<T> UpdateAsync(T entity)
        {
            EntityEntry<T> mEntity = _tallerContext.Set<T>().Update(entity);
            await _tallerContext.SaveChangesAsync();

            return mEntity.Entity;
        }
    }
}
