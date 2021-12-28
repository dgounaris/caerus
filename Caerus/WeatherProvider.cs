using System;
using System.Linq;
using System.Threading.Tasks;

namespace Caerus
{
    public class WeatherProvider
    {
        private OpenWeatherApiClient _weatherClient = new();
        
        public async Task<WeatherSnapshotData> GetCurrentWeatherAsync(string city)
        {
            var currentWeather = await _weatherClient.GetCurrentWeatherAsync(city!);
            return new WeatherSnapshotData(
                currentWeather.Name,
            currentWeather.Sys.Country,
            currentWeather.Weather.First().Description,
            currentWeather.Main.Temp,
            currentWeather.Main.FeelsLike,
            currentWeather.Main.Humidity,
            currentWeather.Clouds.All,
            DateTimeOffset.FromUnixTimeSeconds(currentWeather.Dt).DateTime
            );
        }
    }
}