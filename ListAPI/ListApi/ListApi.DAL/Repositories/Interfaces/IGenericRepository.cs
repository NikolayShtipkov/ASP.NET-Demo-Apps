using ListApi.DAL.Entities;

namespace ListApi.DAL.Repositories.Interfaces
{
    public interface IGenericRepository<T> where T : Entity
    {
        Task<bool> CheckIfNameExistsCreate(string name);
        Task<bool> CheckIfNameExistsEdit(string nameRequest, string nameEdit);
        Task CreateAsync(T entity);
        void Delete(T entity);
        void Edit(T entity);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(Guid id);
    }
}