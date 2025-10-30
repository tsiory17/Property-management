using ManageProperty.Models;

namespace ManageProperty.Services
{
    public interface IBuildingService
    {
        Task<List<Building>> GetBuildingsForManagerAsync(int managerId);
        Task<Building?> GetBuildingByIdAsync(int id);
        Task<bool> CreateBuildingAsync(Building building);
        Task<bool> UpdateBuildingAsync(Building building);
        Task<bool> DeleteBuildingAsync(int id);
    }
}
