using ManageProperty.Models;
using ManageProperty.Repositories;

namespace ManageProperty.Services
{
    public class ApartmentService : IApartmentService
    {
        private readonly IApartmentRepository _repository;

        public ApartmentService(IApartmentRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Apartment>> GetApartmentsForManagerAsync(int managerId)
        {
            return await _repository.GetByManagerIdAsync(managerId);
        }

        public async Task<Apartment?> GetApartmentByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<bool> CreateApartmentAsync(Apartment apartment)
        {
            await _repository.AddAsync(apartment);
            return true;
        }

        public async Task<bool> UpdateApartmentAsync(Apartment apartment)
        {
            if (!_repository.Exists(apartment.ApartmentId))
                return false;

            await _repository.UpdateAsync(apartment);
            return true;
        }

        public async Task<bool> DeleteApartmentAsync(int id)
        {
            if (!_repository.Exists(id))
                return false;

            await _repository.DeleteAsync(id);
            return true;
        }

        public async Task<List<Apartment>> SearchByStatusAsync(int managerId, string? status)
        {
            return await _repository.SearchByStatusAsync(managerId, status);
        }

        public async Task<List<string>> GetStatusesAsync(int managerId)
        {
            return await _repository.GetDistinctStatusesAsync(managerId);
        }

        public async Task<List<Apartment>> SortApartmentsAsync(string sortOrder)
        {
            return await _repository.SortAsync(sortOrder);
        }

        public ApartmentViewModel? GetApartmentWithBuilding(int id)
        {
            return _repository.GetApartmentWithBuilding(id);
        }
    }
}
