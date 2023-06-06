using ListApi.DAL.Data;
using ListApi.DAL.Entities;
using ListApi.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ListApi.DAL.Repositories
{
    public class NotebookRepository : GenericRepository<Notebook>, INotebookRepository
    {
        public NotebookRepository(DatabaseContext context) : base(context)
        {
        }

        public void AddLineToNotebookAsync(Notebook notebook, Line line)
        {
            notebook.Lines.Add(line);
        }
    }
}
