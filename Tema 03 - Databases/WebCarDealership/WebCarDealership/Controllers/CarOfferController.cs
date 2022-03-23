using CarDealership.Data.Model;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebCarDealership.Request;

namespace WebCarDealership.Controllers
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
            var offers = await _dbContext.CarOffers.ToListAsync();
            return Ok(offers);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CarOfferRequest model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dbModel = new CarOffer
            {
                Make = model.Make,
                Model = model.Model,
                AvailableStock = model.AvailableStock
            };

            _dbContext.CarOffers.Add(dbModel);

            await _dbContext.SaveChangesAsync();

            return Created(Request.GetDisplayUrl(), dbModel);
        }
        [HttpDelete("CarOffer/Delete/{Id}")]
        public async Task<ActionResult> Delete(int Id)
        {

            var dbModel = _dbContext.CarOffers.Find(Id);
            if (dbModel == null)
                return BadRequest("No customer with this id!");

            _dbContext.CarOffers.Remove(dbModel);

            await _dbContext.SaveChangesAsync();

            return Created(Request.GetDisplayUrl(), dbModel);

        }

        [HttpPut("CarOffer/Update/{Id}")]
        public async Task<IActionResult> Put(int Id, [FromBody] CarOfferRequest model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dbModel = _dbContext.CarOffers.Find(Id);
            if (dbModel == null)
                return BadRequest("No customer with this id!");

            dbModel.Model = model.Model;
            dbModel.AvailableStock = model.AvailableStock; 
            dbModel.Make = model.Make;
            _dbContext.CarOffers.Update(dbModel);

            await _dbContext.SaveChangesAsync();

            return Created(Request.GetDisplayUrl(), dbModel);
        }

    }
}
