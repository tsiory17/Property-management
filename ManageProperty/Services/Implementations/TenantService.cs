using ManageProperty.Models;
using ManageProperty.Repositories;

namespace ManageProperty.Services
{
    public class TenantService : ITenantService
    {
        private readonly ITenantRepository _repository;

        public TenantService(ITenantRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Tenant>> GetAllTenantsAsync() =>
            await _repository.GetAllAsync();

        public async Task<Tenant?> GetTenantByIdAsync(int id) =>
            await _repository.GetByIdAsync(id);

        public async Task<bool> CreateTenantAsync(Tenant tenant)
        {
            await _repository.AddAsync(tenant);
            return true;
        }

        public async Task<bool> UpdateTenantAsync(Tenant tenant)
        {
            if (!_repository.Exists(tenant.TenantId)) return false;
            await _repository.UpdateAsync(tenant);
            return true;
        }

        public async Task<bool> DeleteTenantAsync(int id)
        {
            if (!_repository.Exists(id)) return false;
            await _repository.DeleteAsync(id);
            return true;
        }

        public List<UserViewModel> SearchTenants(string? searchTerm) =>
            _repository.Search(searchTerm);

        public async Task<bool> RegisterTenantAsync(Tenant tenant)
        {
            if (await _repository.EmailExistsAsync(tenant.Email))
                return false; 

            await _repository.AddAsync(tenant);
            return true;
        }
    }
}
