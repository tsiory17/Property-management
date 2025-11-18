using System;
using System.Collections.Generic;

namespace ManageProperty.Models;

public partial class Building
{
    public int BuildingId { get; set; }
    public int OwnerId { get; set; }
    public int ManagerId { get; set; }
    public string Address { get; set; } = null!;
    public string City { get; set; } = null!;
    public string Zip { get; set; } = null!;
    public string? BuildingImageUrl { get; set; }
    public ICollection<Apartment> Apartments { get; set; } = new List<Apartment>(); //Navigation property //
}
