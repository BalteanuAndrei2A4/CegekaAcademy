using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyRentalCars.Store.Model;

namespace MyRentalCars.Model
{
    public class RentalInfo
    {
        public Customer customer { get; set; }
        public Car car { get; set; } 
        public int daysRented { get; set; }

        public PriceCode pricecode { get; set; }

        public RentalInfo(Customer customer, Car car, int daysRented, PriceCode pricecode)
        {
            this.customer = customer;
            this.car = car;
            this.daysRented = daysRented;
            this.pricecode = pricecode;
        }
    }
}
