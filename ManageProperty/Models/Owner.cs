using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace ManageProperty.Models;

public partial class Owner
{

    public int OwnerId { get; set; }

    [Required]
    [RegularExpression("1", ErrorMessage = "The value must be 1 for owner.")]
    public int RoleId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;
    [EmailAddress]
    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    [RegularExpression(@"^\d{10}$", ErrorMessage = "The phone number must be  10 digits.")]
    public string Phone { get; set; } = null!;
}
