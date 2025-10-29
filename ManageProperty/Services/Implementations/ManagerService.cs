using ManageProperty.Models;
using ManageProperty.Repositories;
using ManageProperty.Services;

namespace ManageProperty.Services
{
    public class ManagerService : IManagerService
    {
        private readonly IManagerRepository _repository;

        public ManagerService(IManagerRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Manager>> GetAllManagersAsync() =>
            await _repository.GetAllAsync();

        public async Task<Manager?> GetManagerByIdAsync(int id) =>
            await _repository.GetByIdAsync(id);

        public async Task<bool> CreateManagerAsync(Manager manager)
        {
            await _repository.AddAsync(manager);
            return true;
        }

        public async Task<bool> UpdateManagerAsync(Manager manager)
        {
            if (!_repository.Exists(manager.ManagerId)) return false;
            await _repository.UpdateAsync(manager);
            return true;
        }

        public async Task<bool> DeleteManagerAsync(int id)
        {
            if (!_repository.Exists(id)) return false;
            await _repository.DeleteAsync(id);
            return true;
        }

        public List<UserViewModel> SearchManagers(string? searchTerm) =>
            _repository.Search(searchTerm);
    }
}
