using ManageProperty.Models;

namespace ManageProperty.Services
{
    public interface IManagerService
    {
        Task<List<Manager>> GetAllManagersAsync();
        Task<Manager?> GetManagerByIdAsync(int id);
        Task<bool> CreateManagerAsync(Manager manager);
        Task<bool> UpdateManagerAsync(Manager manager);
        Task<bool> DeleteManagerAsync(int id);
        List<UserViewModel> SearchManagers(string? searchTerm);
    }
}
