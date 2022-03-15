using Microsoft.AspNetCore.Mvc;

namespace Dealership.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : Controller
    {

        private static List<Customer> customers = new List<Customer>
        {
            new Customer
            {
                Name = "Gigel",
                Age = 22,
                Budget = 3000
            }
        };
        private static List<Car> cars = new List<Car>
        {
                new Car
                {
                    Manufactor = "Ford",
                    Model = "Fiesta",
                    Color = "Red",
                    Weight = 1500,
                    HoursePower = 60,
                    Id = 1,
                    Price = 1500
                },
                new Car
                {
                    Manufactor = "Renault",
                    Model = "Megane",
                    Color = "Blue",
                    Weight = 1231,
                    HoursePower = 101,
                    Id = 2,
                    Price = 2000

                },
                new Car
                {
                    Manufactor = "Tesla",
                    Model = "S",
                    Color = "Magenta",
                    Weight = 2300,
                    HoursePower = 300,
                    Id = 3,
                    Price = 2500

                },
                new Car
                {
                    Manufactor = "Volswagen",
                    Model = "Golf6",
                    Color = "Black",
                    Weight = 2530,
                    HoursePower = 131,
                    Id = 4,
                    Price = 3000
                },
                new Car
                {
                    Manufactor = "Opel",
                    Model = "Astra",
                    Color = "White",
                    Weight = 1762,
                    HoursePower = 90,
                    Id = 5,
                    Price = 3500
                },
                new Car
                {
                    Manufactor = "Fiat",
                    Model = "Punto",
                    Color = "Green",
                    Weight = 800,
                    HoursePower = 900,
                    Id = 6,
                    Price = 4000
                },
                new Car
                {
                    Manufactor = "Seat",
                    Model = "Ibisa",
                    Color = "Ocean Blue",
                    Weight = 1234,
                    HoursePower = 170,
                    Id = 7,
                    Price = 4500
                },
                new Car
                {
                    Manufactor = "Alfa Romeo",
                    Model = "Stelvio",                                  //check this car out
                    Color = "Red",
                    Weight = 3000,
                    HoursePower = 340,
                    Id = 8,
                    Price = 5000
                },
                new Car
                {
                    Manufactor = "BMW",
                    Model = "E30",                                  //check this car out
                    Color = "Yellow",
                    Weight = 2700,
                    HoursePower = 380,
                    Id = 9,
                    Price = 5500
                }
        };



        /*
         * get fara parametri
         */
        [HttpGet("AvaibleCars")]
        public async Task<ActionResult<List<Car>>> Get()
        {
            return Ok(cars);
        }

        /*
         * get cu parametrul "id"
         */

        [HttpGet("car/{id}")]

        public async Task<ActionResult<List<Car>>> Get(int id)
        {
            var car = cars.Find(h => h.Id == id);       // functie lambda pentru a accesa exact masina care are id-ul egal cu parametrul get-ului
            if (car == null)
                return BadRequest("Car not found!");       //daca nu exista, intoarcem un BadRequest
            return Ok(car);                                //daca am gasit, intoarcem obiectul
        }

        /*
         * Post
         */
        [HttpPost("AddCar")]
        public async Task<ActionResult<List<Car>>> AddCar(Car car)
        {
            cars.Add(car);
            return Ok(cars);
        }

        [HttpPut("ModifyCar")]

        public async Task<ActionResult<List<Car>>> UpdateCar(Car request)
        {
            var car = cars.Find(h => h.Id == request.Id);       // functie lambda pentru a accesa exact masina care are id-ul egal cu parametrul get-ului
            if (car == null)
                return BadRequest("Car not found!");

            car.Weight = request.Weight;
            car.HoursePower = request.HoursePower;
            car.Manufactor = request.Manufactor;
            car.Model = request.Model;
            car.Color = request.Color;

            return Ok(cars);
        }

        [HttpDelete("DeleteCar/{id}")]

        public async Task<ActionResult<List<Car>>> Delete(int id)
        {
            var car = cars.Find(h => h.Id == id);       // functie lambda pentru a accesa exact masina care are id-ul egal cu parametrul get-ului
            if (car == null)
                return BadRequest("Car not found!");

            cars.Remove(car);
            return Ok(cars);
        }

        [HttpGet("buy/{name}")]
        public async Task<ActionResult<List<Car>>> BuyCar(string manufactor, string model ,string name)
        {
            var car = cars.Find(h => h.Manufactor == manufactor && h.Model == model);
           if (car == null)
                return BadRequest("Car not found!");

            var customer = customers.Find(t => t.Name == name);
            if (customer == null)
                return BadRequest("Customer not found!");


            customer.setCarOwned(car,customer);
            return Ok(car);
        }

        [HttpGet("ownedCars/{name}")]
        public async Task<ActionResult<List<Car>>> OwnedCars( string name)
        {
            var customer = customers.Find(t => t.Name == name);
            if (customer == null)
                return BadRequest("Customer not found!");


            return Ok(customer.carsOwned);
        }



    }
}
