using ManageProperty.Models;
using ManageProperty.Repositories;

namespace ManageProperty.Services
{
    public class BuildingService : IBuildingService
    {
        private readonly IBuildingRepository _repository;

        public BuildingService(IBuildingRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Building>> GetBuildingsForManagerAsync(int managerId)
        {
            return await _repository.GetByManagerIdAsync(managerId);
        }

        public async Task<Building?> GetBuildingByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<bool> CreateBuildingAsync(Building building)
        {
            await _repository.AddAsync(building);
            return true;
        }

        public async Task<bool> UpdateBuildingAsync(Building building)
        {
            if (!_repository.Exists(building.BuildingId))
                return false;

            await _repository.UpdateAsync(building);
            return true;
        }

        public async Task<bool> DeleteBuildingAsync(int id)
        {
            if (!_repository.Exists(id))
                return false;

            await _repository.DeleteAsync(id);
            return true;
        }
    }
}
