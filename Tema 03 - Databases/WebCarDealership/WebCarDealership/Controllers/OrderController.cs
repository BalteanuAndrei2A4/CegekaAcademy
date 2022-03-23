using CarDealership.Data.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebCarDealership.Request;

namespace WebCarDealership.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly DealershipDbContext _dbContext;

        public OrderController(DealershipDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        public async Task<IActionResult> Post(OrderRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }



            var offer = await _dbContext.CarOffers.FirstOrDefaultAsync(offer => offer.Id == model.CarOfferId);
            if (offer == null)
            {
                return NotFound("car offer not found");
            }

            if (offer.AvailableStock <= model.Quantity)
            {
                return BadRequest("Not enough cars of this model are available in stock!");
            }

            offer.AvailableStock -= model.Quantity;

            var dbOrder = new Order()
            {
                CarOfferId = model.CarOfferId,
                CustomerId = model.CustomerId,
                Date = DateTime.UtcNow,
                Quantity = model.Quantity,
                OrderAmount = model.Quantity * offer.UnitPrice
            };
            _dbContext.Orders.Add(dbOrder);

            int numberOfRecordsAffected = await _dbContext.SaveChangesAsync();
            if (numberOfRecordsAffected == 0)
            {
            }

            return Ok(dbOrder);
        }

        [HttpGet]
        public async Task<IActionResult> Post()
        {
            var orders = await _dbContext.Orders.ToListAsync();
            return Ok(orders);
        }
        [HttpGet("Filter")]
        public async Task<IActionResult> Post(int customerId)
        {
            var offers = await _dbContext.Orders.ToListAsync();
            var offersById = new List<Order>();
            foreach(var offer in offers)
            {
                if (offer.CustomerId == customerId)
                    offersById.Add(offer);

            }
            return Ok(offersById);
        }
    }
}
