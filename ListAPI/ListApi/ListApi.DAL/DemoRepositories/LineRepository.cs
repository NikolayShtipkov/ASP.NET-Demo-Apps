using ListApi.DAL.Data;
using ListApi.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace Demo
{
    public class LineRepository
    {
        private readonly DatabaseContext _context;

        public LineRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<List<Line>> GetAll()
        {
            return await _context.Lines.ToListAsync();
        }

        public async Task<Line> GetById(Guid lineId)
        {
            return await _context.Lines.FirstOrDefaultAsync(l => l.Id == lineId);
        }

        public async Task CreateNotebook(Line line)
        {
            await _context.Lines.AddAsync(line);
        }

        public void UpdateNotebook(Line line)
        {
            _context.Lines.Update(line);
        }

        public void DeleteNotebook(Line line)
        {
            _context.Lines.Remove(line);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
