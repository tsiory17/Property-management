using ManageProperty.Models;

namespace ManageProperty.Repositories
{
    public interface IApartmentRepository
    {
        Task<List<Apartment>> GetByManagerIdAsync(int managerId);
        Task<Apartment?> GetByIdAsync(int id);
        Task AddAsync(Apartment apartment);
        Task UpdateAsync(Apartment apartment);
        Task DeleteAsync(int id);
        bool Exists(int id);
        Task<List<Apartment>> SearchByStatusAsync(int managerId, string? status);
        Task<List<string>> GetDistinctStatusesAsync(int managerId);
        Task<List<Apartment>> SortAsync(string sortOrder);
        ApartmentViewModel? GetApartmentWithBuilding(int id);
    }
}
