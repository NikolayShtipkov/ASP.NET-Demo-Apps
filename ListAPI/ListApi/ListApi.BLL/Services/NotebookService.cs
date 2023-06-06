using ListApi.BLL.Services.Interfaces;
using ListApi.DAL.Entities;
using ListApi.DAL.Repositories.Interfaces;

namespace ListApi.BLL.Service
{
    public class NotebookService : INotebookService
    {
        private readonly IUnitOfWork _unitOfWork;

        public NotebookService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Notebook>> GetAllNotebooksAsync()
        {
            return await _unitOfWork.Notebooks.GetAllAsync();
        }

        public async Task<Notebook> GetNotebookByIdAsync(Guid notebookId)
        {
            var notebook = await _unitOfWork.Notebooks.GetByIdAsync(notebookId);
            if (notebook == null)
            {
                throw new Exception("Notebook not found.");
            }

            return notebook;
        }

        public async Task CreateNotebookAsync(Notebook notebook)
        {
            bool notebookExists = await _unitOfWork.Notebooks.CheckIfNameExistsCreate(notebook.Name);
            if (notebookExists)
            {
                throw new Exception($"Notebook {notebook.Name} exists.");
            }

            await _unitOfWork.Notebooks.CreateAsync(notebook);
            await _unitOfWork.SaveAsync();
        }

        public async Task EditNotebookAsync(Notebook notebook, Guid notebookId)
        {
            var notebookToEdit = await _unitOfWork.Notebooks.GetByIdAsync(notebookId);
            if (notebookToEdit == null)
            {
                throw new Exception("Notebook not found.");
            }

            bool nameExists = await _unitOfWork.Notebooks.CheckIfNameExistsEdit(notebook.Name, notebookToEdit.Name);
            if (nameExists)
            {
                throw new Exception();
            }

            notebookToEdit.Name = notebook.Name;
            notebookToEdit.Description = notebook.Description;

            _unitOfWork.Notebooks.Edit(notebookToEdit);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteNotebookAsync(Guid notebookId)
        {
            var notebook = await _unitOfWork.Notebooks.GetByIdAsync(notebookId);
            if (notebook == null)
            {
                throw new Exception("Notebook not found.");
            }

            _unitOfWork.Notebooks.Delete(notebook);
            await _unitOfWork.SaveAsync();
        }
    }
}
