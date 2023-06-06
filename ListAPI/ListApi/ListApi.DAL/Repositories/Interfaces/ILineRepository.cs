using ListApi.DAL.Entities;

namespace ListApi.DAL.Repositories.Interfaces
{
    public interface ILineRepository : IGenericRepository<Line>
    {
        Task<IEnumerable<Line>> GetLinesFromNotebookAsync(Guid notebookId);
    }
}