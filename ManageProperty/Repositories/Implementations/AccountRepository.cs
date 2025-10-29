using ManageProperty.Data;
using ManageProperty.Models;
using ManageProperty.Repositories;
namespace ManageProperty.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly EstateDbContext _context;

        public AccountRepository(EstateDbContext context)
        {
            _context = context;
        }

        public Owner? GetOwnerByCredentials(string email, string password)
        {
            return _context.Owners.FirstOrDefault(o => 
                o.Email.ToLower() == email.ToLower() && o.Password == password);
        }

        public Manager? GetManagerByCredentials(string email, string password)
        {
            return _context.Managers.FirstOrDefault(m => 
                m.Email.ToLower() == email.ToLower() && m.Password == password);
        }

        public Tenant? GetTenantByCredentials(string email, string password)
        {
            return _context.Tenants.FirstOrDefault(t => 
                t.Email.ToLower() == email.ToLower() && t.Password == password);
        }
    }
}
