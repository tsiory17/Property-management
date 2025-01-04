namespace ManageProperty.Models
{
    public class ApartmentViewModel
    {
        public int ApartmentId { get; set; }
        public int BuildingId { get; set; }
        public int NumberOfRooms { get; set; }
        public double Rent { get; set; }
        public string Status { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
    }

}
