using ManageProperty.Models;

namespace ManageProperty.Repositories
{
    public interface IBuildingRepository
    {
        Task<List<Building>> GetByManagerIdAsync(int managerId);
        Task<Building?> GetByIdAsync(int id);
        Task AddAsync(Building building);
        Task UpdateAsync(Building building);
        Task DeleteAsync(int id);
        bool Exists(int id);
    }
}
