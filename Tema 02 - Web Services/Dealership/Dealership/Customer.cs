namespace Dealership
{
    public class Customer
    {
        public string Name { get; set; } = string.Empty;

        public int Age { get; set; } = 0;
        public int Budget { get; set; } = 0;

        public List<Car> carsOwned = new List<Car> { };

        public void setCarOwned(Car car,Customer customer)
        {
            customer.carsOwned.Add(car);
        }
        public void getCarsOwned()
        {
            if (carsOwned.Count == 0)
                Console.WriteLine("This customer has no cars!");
            else
                foreach (Car car in carsOwned)
                     Console.WriteLine(car);
        }

    }
}
