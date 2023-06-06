using ListApi.DAL.Data;
using ListApi.DAL.Entities;
using ListApi.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ListApi.DAL.Repositories
{
    public class LineRepository : GenericRepository<Line>, ILineRepository
    {
        public LineRepository(DatabaseContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Line>> GetLinesFromNotebookAsync(Guid notebookId)
        {
            var notebook = await _context.Notebooks.FirstOrDefaultAsync(n => n.Id == notebookId);
            return notebook.Lines;
        }
    }
}
