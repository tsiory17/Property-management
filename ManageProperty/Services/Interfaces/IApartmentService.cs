using ManageProperty.Models;

namespace ManageProperty.Services
{
    public interface IApartmentService
    {
        Task<List<Apartment>> GetApartmentsForManagerAsync(int managerId);
        Task<Apartment?> GetApartmentByIdAsync(int id);
        Task<bool> CreateApartmentAsync(Apartment apartment);
        Task<bool> UpdateApartmentAsync(Apartment apartment);
        Task<bool> DeleteApartmentAsync(int id);
        Task<List<Apartment>> SearchByStatusAsync(int managerId, string? status);
        Task<List<string>> GetStatusesAsync(int managerId);
        Task<List<Apartment>> SortApartmentsAsync(string sortOrder);
        ApartmentViewModel? GetApartmentWithBuilding(int id);
    }
}
