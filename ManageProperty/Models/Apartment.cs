using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ManageProperty.Models;

public partial class Apartment
{
    public int ApartmentId { get; set; }

    public int BuildingId { get; set; }

    [Range(1, 10, ErrorMessage = "Number of Room must be between 1 and 10.")]
    public int NumberOfRooms { get; set; }
    [Range(500, 10000, ErrorMessage = "Rent should be between 500$ and 10,000$")]
    public double Rent { get; set; }

    public string Status { get; set; } = null!;
}
