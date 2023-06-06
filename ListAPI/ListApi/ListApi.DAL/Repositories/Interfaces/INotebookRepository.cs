using ListApi.DAL.Entities;

namespace ListApi.DAL.Repositories.Interfaces
{
    public interface INotebookRepository : IGenericRepository<Notebook>
    {
        void AddLineToNotebookAsync(Notebook notebook, Line line);
        Task<bool> CheckIfNameExistsCreate(string name);
        Task<bool> CheckIfNameExistsEdit(string nameRequest, string nameEdit);
    }
}