namespace ListApi.DAL.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ILineRepository Lines { get; }
        INotebookRepository Notebooks { get; }
        Task SaveAsync();
    }
}