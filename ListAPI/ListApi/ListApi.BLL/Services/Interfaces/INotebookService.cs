using ListApi.DAL.Entities;

namespace ListApi.BLL.Services.Interfaces
{
    public interface INotebookService
    {
        Task CreateNotebookAsync(Notebook notebook);
        Task DeleteNotebookAsync(Guid notebookId);
        Task EditNotebookAsync(Notebook notebook, Guid notebookId);
        Task<IEnumerable<Notebook>> GetAllNotebooksAsync();
        Task<Notebook> GetNotebookByIdAsync(Guid notebookId);
    }
}