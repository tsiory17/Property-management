using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ManageProperty.Models;

public partial class Manager
{
    public int ManagerId { get; set; }

    [RegularExpression("2", ErrorMessage = "The value must be 2 for manager.")]

    public int RoleId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    [RegularExpression(@"^\d{10}$", ErrorMessage = "The phone number must be  10 digits.")]
    public string Phone { get; set; } = null!;
}
