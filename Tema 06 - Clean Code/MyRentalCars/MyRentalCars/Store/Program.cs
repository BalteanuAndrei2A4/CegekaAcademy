using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyRentalCars.Model;
using MyRentalCars.Store.Model;

namespace MyRentalCars.Store
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("\nSetam preturile pentru orasul dorit!\n");
            RentalLocation myBussisness = new RentalLocation("Iasi");
            myBussisness.getPrices();
            

            Console.WriteLine("\nAdaugam niste customeri:\n");
            myBussisness.addCustomer(new Customer(1, "Andrei Biceps"));
            myBussisness.addCustomer(new Customer(2, "Diana Forta"));
            myBussisness.addCustomer(new Customer(3, "Dragonu Ak47"));

            myBussisness.getCustomers();

            Console.WriteLine("\nAfisez un anumit customer dupa id\n");
            myBussisness.printCustomer(myBussisness.FindCustomerById(2));
           

            Console.WriteLine("\nAdaugam niste masini!\n");

            myBussisness.addCar(new Car(1, "Ford Mondeo"));
            myBussisness.addCar(new Car(2, "Trabant rosu"));
            myBussisness.addCar(new Car(3, "Mercedes Benz"));
            myBussisness.addCar(new Car(4, "Fiat Punto"));
            myBussisness.addCar(new Car(5, "Volswagen passat"));

            myBussisness.getCars();

            Console.WriteLine("\nAfisez o masina anume dupa id.\n");

            myBussisness.printCar(myBussisness.FindCarById(5));


            
            myBussisness.addRental(new RentalInfo(myBussisness.FindCustomerById(1), myBussisness.FindCarById(3), 2,PriceCode.Regular), PriceCode.Regular);
            myBussisness.addRental(new RentalInfo(myBussisness.FindCustomerById(3),myBussisness.FindCarById(2), 3, PriceCode.Regular), PriceCode.Regular);
            myBussisness.addRental(new RentalInfo(myBussisness.FindCustomerById(1),myBussisness.FindCarById(2), 1, PriceCode.Premium), PriceCode.Premium);
            myBussisness.addRental(new RentalInfo(myBussisness.FindCustomerById(3),myBussisness.FindCarById(2), 3, PriceCode.Premium), PriceCode.Premium);
            myBussisness.addRental(new RentalInfo(myBussisness.FindCustomerById(2),myBussisness.FindCarById(2), 2, PriceCode.Mini), PriceCode.Mini);
            myBussisness.addRental(new RentalInfo(myBussisness.FindCustomerById(1),myBussisness.FindCarById(2), 4, PriceCode.Mini), PriceCode.Mini);
            myBussisness.addRental(new RentalInfo(myBussisness.FindCustomerById(3),myBussisness.FindCarById(2), 2, PriceCode.Premium), PriceCode.Premium);
            myBussisness.addRental(new RentalInfo(myBussisness.FindCustomerById(3),myBussisness.FindCarById(2), 1, PriceCode.Premium), PriceCode.Premium);


            myBussisness.GetAllIncome();


        }
    }
}
