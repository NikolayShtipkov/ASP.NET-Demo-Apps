using ListApi.DAL.Data;
using ListApi.DAL.Repositories.Interfaces;

namespace ListApi.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext _context;

        private INotebookRepository _notebookRepository;
        private ILineRepository _lineRepository;

        public UnitOfWork(DatabaseContext context)
        {
            _context = context;
        }

        public INotebookRepository Notebooks
            => _notebookRepository ??= new NotebookRepository(_context);
        public ILineRepository Lines
            => _lineRepository ??= new LineRepository(_context);

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }
    }
}
