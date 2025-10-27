using System.ComponentModel.DataAnnotations.Schema;

namespace ManageProperty.Models
{
    public class ApartmentImage
    {
        public int ApartmentImageId { get; set; }
        public int ApartmentId { get; set; }
        public string ImageUrl { get; set; } = null!;
        [ForeignKey("ApartmentId")]
        public Apartment Apartment { get; set; } = null!;
    }
}