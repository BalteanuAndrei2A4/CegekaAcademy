using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MyRentalCars.Store.Model;

namespace MyRentalCars.Model
{
    public class Car
    {
        public int id { get; set; }
        public string model { get; set; }

        public Car(int id, string model)
        {
            this.id = id;
            this.model = model;
        }
    }
}
