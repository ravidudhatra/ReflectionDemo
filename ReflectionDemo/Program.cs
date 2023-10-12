using ReflectionDemo.Models;
using ReflectionDemo;

namespace ReflectionDemo
{
    public class Program
    {
        public static void Main()
        {
            Customer customer = new Customer
            {
                FirstName = "Bob",
                LastName = "Jones",
                Age = 32,
                Addresses = new List<Address>
            {
                new Address { StreetNumber = 123, StreetName = "Main St" },
                new Address { StreetNumber = 450, StreetName = "Red Rd" }
            },
                RelatedCustomers = new List<Customer>
            {
                new Customer { FirstName = "Wanda", LastName = "Jones", Age = 31 }
            }
            };

            string result = ClassHelper.GetPropertiesAndValues(customer);
            Console.WriteLine(result);

        }
    }
}