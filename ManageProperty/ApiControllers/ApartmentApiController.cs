using ManageProperty.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Elfie.Serialization;
using Microsoft.EntityFrameworkCore;

namespace ManageProperty.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApartmentApiController : Controller
    {
        private readonly EstateDbContext _context;
        public ApartmentApiController(EstateDbContext context)
        {
            _context = context;
        }

        [HttpGet("viewApartments")]
        public async Task<IActionResult> GetAllApartments()
        {
            try
            {
                var apartments = await _context.Apartments
                .Include(a => a.Building)
                .Select(a => new
                {
                    a.ApartmentId,
                    a.NumberOfRooms,
                    a.Rent,
                    a.Status,
                    BuildingAddress = a.Building.Address,
                    a.Building.City,
                    a.Building.Zip,
                    ApartmentImages = a.ApartmentImages.Select(img => img.ImageUrl).ToList()
                })
                .ToListAsync();
                return Ok(apartments);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}