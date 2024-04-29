using Abanoub.CM.BOL.Models;
using Abanoub.CM.Core;
using Newtonsoft.Json;


namespace Abanoub.CM.DAL
{
    public static class CustomersDB
    {
        public static List<Customer> Customers { get; set; }=new List<Customer>();

        public static async Task LoadCustomersDataFromFileAsync(CancellationToken cancellationToken)
        {
            if (!File.Exists(Constants.CustomersFilePath))
            {
                Customers = new List<Customer>();
            }
            else
            {
                var customersDataJson = await File.ReadAllTextAsync(Constants.CustomersFilePath, cancellationToken);
                Customers = JsonConvert.DeserializeObject<List<Customer>>(customersDataJson) ?? new List<Customer>();
            }
        }

        public static async Task SaveCustomersDataToFileSync(List<Customer> customers, CancellationToken cancellationToken)
        {
            if (!File.Exists(Constants.CustomersFilePath))
            {
                var stream = File.Create(Constants.CustomersFilePath);
                stream.Close();
            }
            string customersJson = JsonConvert.SerializeObject(customers);
            await File.WriteAllTextAsync(Constants.CustomersFilePath, customersJson, cancellationToken);
        }
    }
}
