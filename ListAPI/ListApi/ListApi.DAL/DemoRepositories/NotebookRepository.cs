using ListApi.DAL.Data;
using ListApi.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    public class NotebookRepository
    {
        private readonly DatabaseContext _context;

        public NotebookRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<List<Notebook>> GetAll()
        {
            return await _context.Notebooks.ToListAsync();
        }

        public async Task<Notebook> GetById(Guid notebookId)
        {
            return await _context.Notebooks.FirstOrDefaultAsync(n => n.Id == notebookId);
        }

        public async Task CreateNotebook(Notebook notebook)
        {
            await _context.Notebooks.AddAsync(notebook);
        }

        public void UpdateNotebook(Notebook notebook)
        {
            _context.Notebooks.Update(notebook);
        }

        public void DeleteNotebook(Notebook notebook)
        {
            _context.Notebooks.Remove(notebook);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
