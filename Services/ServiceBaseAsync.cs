using JuliePro.Data;
using Microsoft.EntityFrameworkCore;

namespace JuliePro.Services
{
    public class ServiceBaseAsync<T> : IServiceBaseAsync<T> where T : class
    {
        protected readonly JulieProDbContext _dbContext;

        public ServiceBaseAsync(JulieProDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<T> CreateAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }


        public virtual async Task DeleteAsync(int id)
        {
            var entity = await this.GetByIdAsync(id);
            if (entity != null)
            {
                _dbContext.Set<T>().Remove(entity);
                await _dbContext.SaveChangesAsync();
            }
        }


        public async Task EditAsync(T entity)
        {
            if (_dbContext.Entry(entity).State == EntityState.Detached)
                _dbContext.Update<T>(entity);
            else _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }


        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }


        public async Task<T?> GetByIdAsync(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

    }

}
