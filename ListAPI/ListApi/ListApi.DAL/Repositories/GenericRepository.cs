using ListApi.DAL.Data;
using ListApi.DAL.Entities;
using ListApi.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ListApi.DAL.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : Entity
    {
        protected DatabaseContext _context;
        protected DbSet<T> _entity;

        public GenericRepository(DatabaseContext context)
        {
            _context = context;
            _entity = _context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _entity.ToListAsync();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _entity.FindAsync(id);
        }

        public async Task CreateAsync(T entity)
        {
            await _entity.AddAsync(entity);
        }

        public void Edit(T entity)
        {
            _entity.Update(entity);
        }

        public void Delete(T entity)
        {
            _entity.Remove(entity);
        }

        public async Task<bool> CheckIfNameExistsCreate(string name)
        {
            return await _entity.AnyAsync(e => e.Name == name);
        }

        public async Task<bool> CheckIfNameExistsEdit(string nameRequest, string nameEdit)
        {
            return await _entity.AnyAsync(e => e.Name == nameRequest) && nameEdit != nameRequest;
        }
    }
}
