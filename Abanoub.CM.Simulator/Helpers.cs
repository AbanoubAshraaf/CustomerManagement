using Abanoub.CM.BOL.Models;
using Abanoub.CM.BOL.Payloads;

namespace Abanoub.CM.Simulator
{
    public static class Helpers
    {
        public static CustomersPayload GetCustomersDemoPayload(int i)
        {
            var random = new Random();

            return new CustomersPayload()
            {
                Customers = new List<Customer>() {
                    new Customer
                    {
                        FirstName = Constants.FirstNames[random.Next(Constants.FirstNames.Length)],
                        LastName = Constants.LastNames[random.Next(Constants.LastNames.Length)],
                        Age = random.Next(10, 90),
                        Id = i
                    },
                    new Customer
                    {
                        FirstName = Constants.FirstNames[random.Next(Constants.FirstNames.Length)],
                        LastName = Constants.LastNames[random.Next(Constants.LastNames.Length)],
                        Age = random.Next(10, 90),
                        Id = i + 1
                    }
                }
            };
        }
    }
}
