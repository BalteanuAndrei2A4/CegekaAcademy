using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRentalCars.Model
{
    public class Customer
    {
        public int id { get; set; }
        public string name { get; set; }
        public int loyaltyPoints { get; set; }

        public List<RentalInfo> rentedCars = new List<RentalInfo>();

        public Customer(int id, string name)
        {
            this.id = id;
            this.name = name;
        }

        public void AddRental(RentalInfo rental)
        {
            rentedCars.Add(rental);
        }
    }
}
