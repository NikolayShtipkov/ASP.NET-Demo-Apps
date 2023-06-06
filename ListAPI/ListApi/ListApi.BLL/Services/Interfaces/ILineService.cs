using ListApi.DAL.Entities;

namespace ListApi.BLL.Services.Interfaces
{
    public interface ILineService
    {
        Task CreateLineAsync(Line line);
        Task DeleteLineAsync(Guid lineId);
        Task EditLineAsync(Line line, Guid lineId);
        Task<IEnumerable<Line>> GetAllLinesAsync();
        Task<Line> GetLineByIdAsync(Guid lineId);
    }
}