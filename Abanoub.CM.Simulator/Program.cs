using Abanoub.CM.BOL.Models;
using Abanoub.CM.BOL.Payloads;
using Abanoub.CM.BOL.Utility;
using Abanoub.CM.Simulator;
using System.Net.Http.Json;
using System.Text.Json;


await CheckApiHealth();
await Task.WhenAll(postRequest(), getRequest());
Console.ReadLine(); ;

static async Task postRequest()
{
    var client = new HttpClient();

    for (int i = 1; i < (Constants.NumberOfRequests * 2); i += 2)
    {
        try
        {
            var payload = Helpers.GetCustomersDemoPayload(i);
            var response = await client.PostAsJsonAsync(Constants.URL, payload);
            var errorMessage = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            Console.WriteLine($"POST request {i} status code: {response.StatusCode} {errorMessage}");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }

    };
}
static async Task getRequest()
{
    var client = new HttpClient();

    for (int i = 0; i < Constants.NumberOfRequests; i++)
    {
        var resp = await client.GetAsync(Constants.URL);

        Console.WriteLine($"GET request {i + 1} status code: {resp.StatusCode}");

        if (resp.IsSuccessStatusCode)
        {
            var responseBody = await resp.Content.ReadAsStringAsync();
            var responseData = JsonSerializer.Deserialize<ResponseData<List<Customer>>>(responseBody, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            Console.WriteLine($"GET request {i + 1} response : ");

            if (responseData == null || responseData.Data == null)
            {
                Console.WriteLine("Empty response");
            }
            else if (!responseData.Success)
            {
                Console.WriteLine(responseData.Message);
            }
            else
            {
                foreach (var customer in responseData.Data)
                {
                    Console.WriteLine($"- {customer.FirstName} {customer.LastName}, Age: {customer.Age}, ID: {customer.Id}");
                }
            }

        }

    }
}


/// <summary>
///  This function to help us run the simulator and the WebApi programs at the same time 
///  This function created to help us to make sure that the server that resulted from runing the WebApi program already initiated
/// </summary>
static async Task CheckApiHealth()
{
    var client = new HttpClient();

    while (true)
    {
        try
        {
            Thread.Sleep(10000);

            var resp = await client.GetAsync(Constants.URL_Health);
            if (resp.IsSuccessStatusCode)
            {
                Console.WriteLine("WebApi Healthy!");
            }
            break;
        }
        catch (Exception)
        {
            Console.WriteLine("Server is not ready");
        }
    }
}


