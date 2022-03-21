using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tema3Databases.Models;

namespace Tema3Databases.Controllers
{
    
    [ApiController]
    public class CarOfferController : Controller
    {
        private static List<CarOffer> avaibleCars = new List<CarOffer>()
        {
            new CarOffer()
            {
                Id = 1,
                Make = "Ford",
                Model =  "Fiesta",
                AvailableStock = 100,
                UnitPrice = 3200,
            }
            
        };
    [HttpGet("/AvailableCars")]
    public async Task<ActionResult<List<CarOffer>>> Get()
    {
        return Ok(avaibleCars);
    }
}
}
