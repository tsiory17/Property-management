using ManageProperty.Data;
using ManageProperty.Models;
using Microsoft.EntityFrameworkCore;

namespace ManageProperty.Repositories
{
    public class BuildingRepository : IBuildingRepository
    {
        private readonly EstateDbContext _context;

        public BuildingRepository(EstateDbContext context)
        {
            _context = context;
        }

        public async Task<List<Building>> GetByManagerIdAsync(int managerId)
        {
            return await _context.Buildings
                .Where(b => b.ManagerId == managerId)
                .ToListAsync();
        }

        public async Task<Building?> GetByIdAsync(int id)
        {
            return await _context.Buildings
                .FirstOrDefaultAsync(b => b.BuildingId == id);
        }

        public async Task AddAsync(Building building)
        {
            _context.Buildings.Add(building);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Building building)
        {
            _context.Buildings.Update(building);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var building = await _context.Buildings.FindAsync(id);
            if (building != null)
            {
                _context.Buildings.Remove(building);
                await _context.SaveChangesAsync();
            }
        }

        public bool Exists(int id)
        {
            return _context.Buildings.Any(b => b.BuildingId == id);
        }
    }
}
