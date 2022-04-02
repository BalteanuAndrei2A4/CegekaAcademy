using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyRentalCars.Store.Model;

namespace MyRentalCars.Money
{
    public class Discount
    {
        public PriceCode priceCode { get; set; }

        public int fullPriceDays { get; set; }

        public double discountValue { get; set; }



    }
}
