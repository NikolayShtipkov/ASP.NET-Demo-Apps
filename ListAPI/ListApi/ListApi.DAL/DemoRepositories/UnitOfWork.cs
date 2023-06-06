using ListApi.DAL.Data;

namespace Demo
{
    public class UnitOfWork : IDisposable
    {
        private readonly DatabaseContext _context;

        private NotebookRepository _notebookRepository;
        private LineRepository _lineRepository;

        public UnitOfWork(DatabaseContext context)
        {
            _context = context;
        }

        public NotebookRepository Notebooks
            => _notebookRepository ??= new NotebookRepository(_context);
        public LineRepository Lines
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
