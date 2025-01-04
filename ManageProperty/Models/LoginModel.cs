using System.ComponentModel.DataAnnotations;

namespace ManageProperty.Models
{
    public class LoginModel
    {
        [EmailAddress]
        public string email { get; set; }
        public string password { get; set; }
    }

}
