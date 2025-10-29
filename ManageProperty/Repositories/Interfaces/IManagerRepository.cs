using ManageProperty.Models;

namespace ManageProperty.Repositories
{
    public interface IManagerRepository
    {
        Task<List<Manager>> GetAllAsync();
        Task<Manager?> GetByIdAsync(int id);
        Task AddAsync(Manager manager);
        Task UpdateAsync(Manager manager);
        Task DeleteAsync(int id);
        bool Exists(int id);
        List<UserViewModel> Search(string? searchTerm);
    }
}
