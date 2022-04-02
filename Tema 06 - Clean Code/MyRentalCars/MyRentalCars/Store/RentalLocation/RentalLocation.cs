using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyRentalCars.Model;
using MyRentalCars.Money;
using MyRentalCars.Store.Model;


    public class RentalLocation
    {
        public string location { get; set; }

        public Dictionary<PriceCode, double> prices = new Dictionary<PriceCode, double>();

        public List<Discount> discounts = new List<Discount>();

        public List<Customer> customers = new List<Customer>();

        public List<Car> cars = new List<Car>();

        public Dictionary<PriceCode, double> incomeTotal = new Dictionary<PriceCode, double>();

        public RentalLocation(string location)
        {
            this.location = location;
            setPrices(this.location);
            initializeIncome();
        }
        
        public void initializeIncome()
        {
        incomeTotal.Add(PriceCode.Premium, 0);
        incomeTotal.Add(PriceCode.Mini, 0);
        incomeTotal.Add(PriceCode.Regular, 0);
        }
        public void setPrices(string location)
        {
            if(location == "Iasi")
            {
                this.prices.Add(PriceCode.Regular,20);
                this.prices.Add(PriceCode.Premium, 30);
                this.prices.Add(PriceCode.Mini, 15);
            }
            if(location == "Bucuresti")
            {
                this.prices.Add(PriceCode.Regular,30);
                this.prices.Add(PriceCode.Premium, 30 + 30 * 33 / 100);
                this.prices.Add(PriceCode.Mini, 30 * 0.75);
                this.prices.Add(PriceCode.Luxury, 70);   
            }
        }

        public void getPrices()
        {
            foreach(KeyValuePair<PriceCode,double> kvp in this.prices)
            {
                Console.WriteLine("Key = {0}, Value = {1}", kvp.Key, kvp.Value); 
            }
        }

    public void addCustomer(Customer customer)
    {
        customers.Add(customer);
    }

    public void getCustomers()
    {
        foreach (Customer customer in customers)
        {
            Console.WriteLine("name = {0}, id = {1} ",customer.name,customer.id);
        }
    }

    public Customer FindCustomerById(int idCustomer)
    {
        foreach (Customer customer in customers)
        {
           if(customer.id == idCustomer)
            {
                return customer;
            }
        }
        return null;
    }


    public void addCar(Car vrumVrum)
    {
        this.cars.Add(vrumVrum);
    }

    public void getCars()
    {
        foreach(Car car in cars)
        {
            Console.WriteLine("id = {0} , model = {1}", car.id, car.model);
        }
    }

    public Car FindCarById(int idCar)
    {
        foreach (Car car in cars)
        {
            if (car.id == idCar)
            {
                return car;
            }
        }
        return null;
    }

    public void printCustomer(Customer customer)
    {
        Console.WriteLine("name = {0}, id = {1} ", customer.name, customer.id);
    }

    public void printCar(Car car)
    {
        Console.WriteLine("id = {0}, model = {1} ", car.id, car.model);
    }

    public void addRental(RentalInfo rental,PriceCode priceCode)
    {
        rental.customer.AddRental(rental);
        addLoyaltyPointsToCustomer(rental.customer,priceCode,rental.daysRented);
        double amount = calculateAmount(rental.customer, priceCode, rental.daysRented);
        incomeTotal[priceCode] = amount+ incomeTotal[priceCode];
    }

    public void addLoyaltyPointsToCustomer(Customer customer,PriceCode priceCode,int daysRented)
    {
        if (priceCode == PriceCode.Regular)
            customer.loyaltyPoints++;

        if (priceCode == PriceCode.Premium && daysRented >= 2)
            customer.loyaltyPoints += 2;

        if (priceCode == PriceCode.Premium && daysRented < 2)
            customer.loyaltyPoints++;

    }

    public double calculateAmount(Customer customer, PriceCode priceCode, int daysRented)
    {
        double amount = 0;
        switch (priceCode)
        {
            case PriceCode.Regular:
                amount += prices[priceCode] * 2;
                if (daysRented > 2)
                    amount += (daysRented - 2) * prices[priceCode]*0.75;
                break;
            case PriceCode.Premium:
                amount += daysRented * prices[priceCode];
                break;
            case PriceCode.Mini:
                amount += prices[priceCode] * 3;
                if (daysRented > 3)
                    amount += (daysRented - 3) * prices[priceCode]*0.66;
                break;
        }

        if (customer.loyaltyPoints >= 5)
        {
            amount = amount * 0.95;
        }
        return amount;
    }

    public void GetAllIncome()
    {
        foreach (KeyValuePair<PriceCode, double> kvp in this.incomeTotal)
        {
            Console.WriteLine("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
        }
    }
}

