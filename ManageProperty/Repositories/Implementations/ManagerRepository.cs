using ManageProperty.Data;
using ManageProperty.Models;
using ManageProperty.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ManageProperty.Repositories
{
    public class ManagerRepository : IManagerRepository
    {
        private readonly EstateDbContext _context;

        public ManagerRepository(EstateDbContext context)
        {
            _context = context;
        }

        public async Task<List<Manager>> GetAllAsync() =>
            await _context.Managers.ToListAsync();

        public async Task<Manager?> GetByIdAsync(int id) =>
            await _context.Managers.FirstOrDefaultAsync(m => m.ManagerId == id);

        public async Task AddAsync(Manager manager)
        {
            _context.Managers.Add(manager);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Manager manager)
        {
            _context.Managers.Update(manager);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var manager = await _context.Managers.FindAsync(id);
            if (manager != null)
            {
                _context.Managers.Remove(manager);
                await _context.SaveChangesAsync();
            }
        }

        public bool Exists(int id) =>
            _context.Managers.Any(m => m.ManagerId == id);

        public List<UserViewModel> Search(string? searchTerm)
        {
            var query = from m in _context.Managers
                        join r in _context.Roles on m.RoleId equals r.RoleId
                        where string.IsNullOrEmpty(searchTerm) ||
                              m.FirstName.Contains(searchTerm) ||
                              m.LastName.Contains(searchTerm)
                        select new UserViewModel
                        {
                            userId = m.ManagerId,
                            FirstName = m.FirstName,
                            LastName = m.LastName,
                            Email = m.Email,
                            Phone = m.Phone,
                            RoleName = r.RoleName
                        };
            return query.ToList();
        }
    }
}
