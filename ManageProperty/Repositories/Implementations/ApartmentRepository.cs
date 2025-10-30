using ManageProperty.Data;
using ManageProperty.Models;
using Microsoft.EntityFrameworkCore;

namespace ManageProperty.Repositories
{
    public class ApartmentRepository : IApartmentRepository
    {
        private readonly EstateDbContext _context;

        public ApartmentRepository(EstateDbContext context)
        {
            _context = context;
        }

        public async Task<List<Apartment>> GetByManagerIdAsync(int managerId)
        {
            var buildingIds = await _context.Buildings
                .Where(b => b.ManagerId == managerId)
                .Select(b => b.BuildingId)
                .ToListAsync();

            return await _context.Apartments
                .Where(a => buildingIds.Contains(a.BuildingId))
                .ToListAsync();
        }

        public async Task<Apartment?> GetByIdAsync(int id)
        {
            return await _context.Apartments
                .FirstOrDefaultAsync(a => a.ApartmentId == id);
        }

        public async Task AddAsync(Apartment apartment)
        {
            _context.Apartments.Add(apartment);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Apartment apartment)
        {
            _context.Apartments.Update(apartment);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var apartment = await _context.Apartments.FindAsync(id);
            if (apartment != null)
            {
                _context.Apartments.Remove(apartment);
                await _context.SaveChangesAsync();
            }
        }

        public bool Exists(int id)
        {
            return _context.Apartments.Any(a => a.ApartmentId == id);
        }

        public async Task<List<Apartment>> SearchByStatusAsync(int managerId, string? status)
        {
            var buildingIds = await _context.Buildings
                .Where(b => b.ManagerId == managerId)
                .Select(b => b.BuildingId)
                .ToListAsync();

            var query = _context.Apartments
                .Where(a => buildingIds.Contains(a.BuildingId));

            if (!string.IsNullOrEmpty(status))
                query = query.Where(a => a.Status.ToLower() == status.ToLower());

            return await query.ToListAsync();
        }

        public async Task<List<string>> GetDistinctStatusesAsync(int managerId)
        {
            var buildingIds = await _context.Buildings
                .Where(b => b.ManagerId == managerId)
                .Select(b => b.BuildingId)
                .ToListAsync();

            return await _context.Apartments
                .Where(a => buildingIds.Contains(a.BuildingId))
                .Select(a => a.Status)
                .Distinct()
                .ToListAsync();
        }

        public async Task<List<Apartment>> SortAsync(string sortOrder)
        {
            var query = _context.Apartments.AsQueryable();

            query = sortOrder switch
            {
                "price_asc" => query.OrderBy(a => a.Rent),
                "price_desc" => query.OrderByDescending(a => a.Rent),
                "rooms_asc" => query.OrderBy(a => a.NumberOfRooms),
                "rooms_desc" => query.OrderByDescending(a => a.NumberOfRooms),
                _ => query.OrderBy(a => a.Rent)
            };

            return await query.ToListAsync();
        }

        public ApartmentViewModel? GetApartmentWithBuilding(int id)
        {
            return (from a in _context.Apartments
                    join b in _context.Buildings on a.BuildingId equals b.BuildingId
                    where a.ApartmentId == id
                    select new ApartmentViewModel
                    {
                        ApartmentId = a.ApartmentId,
                        BuildingId = b.BuildingId,
                        Rent = a.Rent,
                        NumberOfRooms = a.NumberOfRooms,
                        Status = a.Status,
                        Address = b.Address,
                        City = b.City,
                        ZipCode = b.Zip
                    }).FirstOrDefault();
        }
    }
}
