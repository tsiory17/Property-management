namespace ManageProperty.Services
{
    public interface IAccountService
    {
        (bool isValid, string role, int userId, string userName, string email)? 
            ValidateCredentials(string accountType, string email, string password);
    }
}
