using mvc_surfboard.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

public class WebApiService
{
    private readonly HttpClient _httpClient;

    public WebApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri("https://localhost:7165/"); 
    }

    public async Task<List<Surfboard>> GetSurfboardsAsync()
    {
        HttpResponseMessage response = await _httpClient.GetAsync("api/surfboards");
        response.EnsureSuccessStatusCode();

        var jsonResponse = await response.Content.ReadAsStringAsync();
        var surfboards = JsonConvert.DeserializeObject<List<Surfboard>>(jsonResponse);
        return surfboards;
    }
    public async Task<List<Rental>> GetRentalsAsync()
    {
        HttpResponseMessage response = await _httpClient.GetAsync("api/rentals");
        response.EnsureSuccessStatusCode();

        var jsonResponse = await response.Content.ReadAsStringAsync();
        var rentals = JsonConvert.DeserializeObject<List<Rental>>(jsonResponse);

        return rentals;
    }

    public async Task<Rental> PostSurfboardAsync(Rental rental)
    {
        // Convert the Rental object to JSON
        var jsonRequest = JsonConvert.SerializeObject(rental);
        var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

        // Send a POST request to the server
        HttpResponseMessage response = await _httpClient.PostAsync("api/rentals", content);
        response.EnsureSuccessStatusCode();

        // Read the response from the server
        var jsonResponse = await response.Content.ReadAsStringAsync();

        // Deserialize the JSON response to a Rental object
        var postedRental = JsonConvert.DeserializeObject<Rental>(jsonResponse);

        return postedRental;
    }
}
