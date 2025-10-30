using ManageProperty.Models;

namespace ManageProperty.Services
{
    public interface ITenantService
    {
        Task<List<Tenant>> GetAllTenantsAsync();
        Task<Tenant?> GetTenantByIdAsync(int id);
        Task<bool> CreateTenantAsync(Tenant tenant);
        Task<bool> UpdateTenantAsync(Tenant tenant);
        Task<bool> DeleteTenantAsync(int id);
        List<UserViewModel> SearchTenants(string? searchTerm);
        Task<bool> RegisterTenantAsync(Tenant tenant);
    }
}
