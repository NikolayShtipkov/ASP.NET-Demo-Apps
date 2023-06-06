using ListApi.BLL.Services.Interfaces;
using ListApi.DAL.Entities;
using ListApi.DAL.Repositories.Interfaces;

namespace ListApi.BLL.Services
{
    public class LineService : ILineService
    {
        private readonly IUnitOfWork _unitOfWork;

        public LineService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Line>> GetAllLinesAsync()
        {
            return await _unitOfWork.Lines.GetAllAsync();
        }

        public async Task<Line> GetLineByIdAsync(Guid lineId)
        {
            var line = await _unitOfWork.Lines.GetByIdAsync(lineId);
            if (line == null)
            {
                throw new Exception("Line not found.");
            }

            return line;
        }

        public async Task CreateLineAsync(Line line)
        {
            bool lineExists = await _unitOfWork.Lines.CheckIfNameExistsCreate(line.Name);
            if (lineExists)
            {
                throw new Exception($"Line {line.Name} exists.");
            }

            line.CreatedAt = DateTime.Now;

            await _unitOfWork.Lines.CreateAsync(line);
            await _unitOfWork.SaveAsync();
        }

        public async Task EditLineAsync(Line line, Guid lineId)
        {
            var lineToEdit = await _unitOfWork.Lines.GetByIdAsync(lineId);
            if (lineToEdit == null)
            {
                throw new Exception("Line not found.");
            }

            bool nameExists = await _unitOfWork.Lines.CheckIfNameExistsEdit(line.Name, lineToEdit.Name);
            if (nameExists)
            {
                throw new Exception("Name already in use.");
            }

            lineToEdit.Name = line.Name;
            lineToEdit.Description = line.Description;

            _unitOfWork.Lines.Edit(lineToEdit);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteLineAsync(Guid lineId)
        {
            var line = await _unitOfWork.Lines.GetByIdAsync(lineId);
            if (line == null)
            {
                throw new Exception("Line not found.");
            }

            _unitOfWork.Lines.Delete(line);
            await _unitOfWork.SaveAsync();
        }
    }
}
