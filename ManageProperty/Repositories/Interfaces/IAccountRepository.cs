using ManageProperty.Models;

namespace ManageProperty.Repositories
{
    public interface IAccountRepository
    {
        Owner? GetOwnerByCredentials(string email, string password);
        Manager? GetManagerByCredentials(string email, string password);
        Tenant? GetTenantByCredentials(string email, string password);
    }
}
