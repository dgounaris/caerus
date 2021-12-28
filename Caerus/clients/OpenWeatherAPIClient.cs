using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Caerus
{
    public class OpenWeatherApiClient
    {
        private readonly HttpClient _httpClient = new HttpClient
        {
            BaseAddress = new Uri("https://api.openweathermap.org/")
        };

        private static readonly string _appKey = Environment.GetEnvironmentVariable("OpenWeatherApiKey") ??
                                                 Environment.GetEnvironmentVariable("OpenWeatherApiKey", EnvironmentVariableTarget.User) ??
                                                 Environment.GetEnvironmentVariable("OpenWeatherApiKey", EnvironmentVariableTarget.Machine) ?? "";

        public async Task<WeatherResponseDto> GetCurrentWeatherAsync(string city)
        {
           var response = await _httpClient.GetAsync($"data/2.5/weather?q={city}&units=metric&appid={_appKey}");
           if (response.StatusCode == HttpStatusCode.NotFound)
           {
               Console.WriteLine($"Weather not found for city {city}");
           }
           var weather = await response.Content.ReadFromJsonAsync<WeatherResponseDto>();
           if (weather is null)
           {
               Console.WriteLine($"Error reading weather json for {city}");
           }
           return weather!;
        }

        public async Task<ForecastResponseDto> GetForecastAsync(string city)
        {
            var response = await _httpClient.GetAsync($"data/2.5/forecast?q={city}&units=metric&appid={_appKey}");
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                Console.WriteLine($"Weather not found for city {city}");
            }
            var weather = await response.Content.ReadFromJsonAsync<ForecastResponseDto>();
            if (weather is null)
            {
                Console.WriteLine($"Error reading weather json for {city}");
            }
            return weather!;
        }
    }
}