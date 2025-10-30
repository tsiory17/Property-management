using ManageProperty.Models;

namespace ManageProperty.Repositories
{
    public interface ITenantRepository
    {
        Task<List<Tenant>> GetAllAsync();
        Task<Tenant?> GetByIdAsync(int id);
        Task AddAsync(Tenant tenant);
        Task UpdateAsync(Tenant tenant);
        Task DeleteAsync(int id);
        bool Exists(int id);
        List<UserViewModel> Search(string? searchTerm);
        Task<bool> EmailExistsAsync(string email);
    }
}
