using CarDealership.Data;
using CarDealership.Data.Models;
using CarDealership.Web.Requests;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarDealership.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarOfferController : ControllerBase
    {
        private readonly DealershipDbContext _dbContext;

        public CarOfferController(DealershipDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _dbContext.CarOffers.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CarOfferRequestModel model)
        {
            var dbModel = new CarOffer
            {
                Make = model.Make,
                Model = model.Model,
                AvailableStock = model.AvailableStock,
                UnitPrice = model.UnitPrice,
                DiscountPercentage = model.DiscountPercentage,
                Image = model.Image ?? string.Empty
            };

            _dbContext.CarOffers.Add(dbModel);

            await _dbContext.SaveChangesAsync();

            return Created(Request.GetDisplayUrl(), dbModel);
        }
        [HttpGet("{Id}")]
        public async Task<ActionResult> GetCarById(int Id)
        {
            
            var dbModel = _dbContext.CarOffers.Find(Id);
            if (dbModel == null)
                return BadRequest("No order with this id!");

         
            await _dbContext.SaveChangesAsync();

            return Ok(dbModel);

        }
    }
}