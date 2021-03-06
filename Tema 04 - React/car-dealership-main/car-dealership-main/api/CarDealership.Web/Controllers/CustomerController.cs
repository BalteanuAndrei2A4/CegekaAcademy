using CarDealership.Data;
using CarDealership.Data.Models;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebCarDealership.Request;

namespace WebCarDealership.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly DealershipDbContext _dbContext;

        public CustomerController(DealershipDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CustomerRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dbModel = new Customer
            {
                Name = model.Name,
                Email = model.Email
            };

            _dbContext.Customers.Add(dbModel);

            await _dbContext.SaveChangesAsync();

            return Created(Request.GetDisplayUrl(), dbModel);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] CustomerRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dbModel = _dbContext.Customers.Find(model.Id);
            if (dbModel == null)
                return BadRequest("No customer with this id!");

            if (model.Name != null)
                dbModel.Name = model.Name;
            if (dbModel.Email != null)
                dbModel.Email = model.Email;

            _dbContext.Customers.Update(dbModel);

            await _dbContext.SaveChangesAsync();

            return Created(Request.GetDisplayUrl(), dbModel);
        }
        [HttpDelete("Delete/{Id}")]
        public async Task<ActionResult> Delete(int Id)
        {
            
            var dbModel = _dbContext.Customers.Find(Id);
            if (dbModel == null)
                return BadRequest("No customer with this id!");

            _dbContext.Customers.Remove(dbModel);

            await _dbContext.SaveChangesAsync();

            return Created(Request.GetDisplayUrl(), dbModel);

        }
        [HttpGet("{Id}")]
        public async Task<ActionResult> GetById(int Id)
        {

            var dbModel = _dbContext.Customers.Find(Id);
            if (dbModel == null)
                return BadRequest("No customer with this id!");


            foreach (var customer in _dbContext.Customers)
            {
                if (customer.Id == Id)
                    return Ok(customer);

            }
            await _dbContext.SaveChangesAsync();

            return BadRequest();

        }
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            await _dbContext.SaveChangesAsync();

            return Ok(_dbContext.Customers);

        }

    }
}
