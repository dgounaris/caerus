using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Caerus
{
    public class ForecastProvider
    {
        private readonly OpenWeatherApiClient _weatherClient = new();

        public async Task<WeatherSnapshotData> GetForecastAsync(string city, DateTime time)
        {
            var forecast = await _weatherClient.GetForecastAsync(city);
            forecast.List.Sort((a, b) => a.Dt.CompareTo(b.Dt));
            var closestSnapshotIndex = forecast.List
                .Select(x => DateTimeOffset.FromUnixTimeSeconds(x.Dt).DateTime).ToList()
                .BinarySearch(time, new CompareForecastDatetimes());
            if (closestSnapshotIndex < 0)
            {
                Console.WriteLine($"Forecast for datetime {time} is not available, returning closest available.");
            }
            if (closestSnapshotIndex < 0 && time < DateTimeOffset.FromUnixTimeSeconds(forecast.List[0].Dt).DateTime)
            {
                closestSnapshotIndex = 0;
            }
            else if (closestSnapshotIndex < 0 && time > DateTimeOffset.FromUnixTimeSeconds(forecast.List[^1].Dt).DateTime)
            {
                closestSnapshotIndex = forecast.List.Count - 1;
            }

            var selectedItem = forecast.List[closestSnapshotIndex];
            return new WeatherSnapshotData(
                forecast.City.Name,
                forecast.City.Country,
                selectedItem.Weather.First().Description,
                selectedItem.Main.Temp,
                selectedItem.Main.FeelsLike,
                selectedItem.Main.Humidity,
                selectedItem.Clouds.All,
                DateTimeOffset.FromUnixTimeSeconds(selectedItem.Dt).DateTime
            );
        }
    }
    
    class CompareForecastDatetimes : IComparer<DateTime>
    {

        public int Compare(DateTime x, DateTime y)
        {
            if (x < y && x.AddMinutes(90) >= y && y.AddMinutes(-90) <= x)
            {
                return 0;
            }
            if (x > y && x.AddMinutes(-90) < y && y.AddMinutes(90) > x)
            {
                return 0;
            }

            return x.CompareTo(y);
        }

    }
}