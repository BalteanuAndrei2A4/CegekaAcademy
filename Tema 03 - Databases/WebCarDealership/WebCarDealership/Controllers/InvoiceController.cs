using CarDealership.Data.Model;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebCarDealership.Request;

namespace WebCarDealership.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InvoiceController : ControllerBase
    {
        private readonly DealershipDbContext _dbContext;

        public InvoiceController(DealershipDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] InvoiceRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dbModel = new Invoice
            {
                CustomerId = model.CustomerId,
                InvoiceNumber = model.InvoiceNumber,
                InvoiceDate = DateTime.Now
            };

            var offers = await _dbContext.Orders.ToListAsync();
            
            decimal invoiceAmount = 0;

            foreach (var offer in offers)
            {
                if (offer.CustomerId == dbModel.CustomerId)
                    invoiceAmount += offer.OrderAmount;
            }

            dbModel.Amount = invoiceAmount;

            _dbContext.Invoices.Add(dbModel);
            await _dbContext.SaveChangesAsync();

            return Created(Request.GetDisplayUrl(), dbModel);
        }
    }
}
