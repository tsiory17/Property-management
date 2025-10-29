using ManageProperty.Repositories;

namespace ManageProperty.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _repo;

        public AccountService(IAccountRepository repo)
        {
            _repo = repo;
        }

        public (bool isValid, string role, int userId, string userName, string email)? 
            ValidateCredentials(string accountType, string email, string password)
        {
            switch (accountType.ToLower())
            {
                case "owner":
                    var owner = _repo.GetOwnerByCredentials(email, password);
                    if (owner != null)
                        return (true, "Owner", owner.OwnerId, $"{owner.FirstName} {owner.LastName}", owner.Email);
                    break;

                case "manager":
                    var manager = _repo.GetManagerByCredentials(email, password);
                    if (manager != null)
                        return (true, "Manager", manager.ManagerId, $"{manager.FirstName} {manager.LastName}", manager.Email);
                    break;

                case "tenant":
                    var tenant = _repo.GetTenantByCredentials(email, password);
                    if (tenant != null)
                        return (true, "Tenant", tenant.TenantId, $"{tenant.FirstName} {tenant.LastName}", tenant.Email);
                    break;
            }

            return null;
        }
    }
}
