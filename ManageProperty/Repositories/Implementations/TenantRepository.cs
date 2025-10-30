using ManageProperty.Data;
using ManageProperty.Models;
using Microsoft.EntityFrameworkCore;

namespace ManageProperty.Repositories
{
    public class TenantRepository : ITenantRepository
    {
        private readonly EstateDbContext _context;

        public TenantRepository(EstateDbContext context)
        {
            _context = context;
        }

        public async Task<List<Tenant>> GetAllAsync() =>
            await _context.Tenants.ToListAsync();

        public async Task<Tenant?> GetByIdAsync(int id) =>
            await _context.Tenants.FirstOrDefaultAsync(t => t.TenantId == id);

        public async Task AddAsync(Tenant tenant)
        {
            _context.Tenants.Add(tenant);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Tenant tenant)
        {
            _context.Tenants.Update(tenant);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var tenant = await _context.Tenants.FindAsync(id);
            if (tenant != null)
            {
                _context.Tenants.Remove(tenant);
                await _context.SaveChangesAsync();
            }
        }

        public bool Exists(int id) =>
            _context.Tenants.Any(t => t.TenantId == id);

        public async Task<bool> EmailExistsAsync(string email) =>
            await _context.Tenants.AnyAsync(t => t.Email.ToLower() == email.ToLower());

        public List<UserViewModel> Search(string? searchTerm)
        {
            var query = from t in _context.Tenants
                        join r in _context.Roles on t.RoleId equals r.RoleId
                        where string.IsNullOrEmpty(searchTerm) ||
                              t.FirstName.Contains(searchTerm) ||
                              t.LastName.Contains(searchTerm)
                        select new UserViewModel
                        {
                            userId = t.TenantId,
                            FirstName = t.FirstName,
                            LastName = t.LastName,
                            Email = t.Email,
                            Phone = t.Phone,
                            RoleName = r.RoleName
                        };

            return query.ToList();
        }
    }
}
