using mvc_surfboard.Models;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

public class WebApiService
{
    private readonly HttpClient _httpClient;

    public WebApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri("https://localhost:7165/"); // Set your Web API base address herea
    }

    public async Task<List<Surfboard>> GetSurfboardsAsync()
    {
        HttpResponseMessage response = await _httpClient.GetAsync("api/surfboards");
        response.EnsureSuccessStatusCode();

        string surfboardJson = await response.Content.ReadAsStringAsync();
        List<Surfboard> surfboards = JsonSerializer.Deserialize<List<Surfboard>>(surfboardJson);

        return surfboards;
    }
    public async Task<List<Rental>> GetRentalsAsync()
    {
        HttpResponseMessage response = await _httpClient.GetAsync("api/rentals");
        response.EnsureSuccessStatusCode();

        string rentalJson = await response.Content.ReadAsStringAsync();
        List<Rental> rentals = JsonSerializer.Deserialize<List<Rental>>(rentalJson);

        return rentals;
    }
}
