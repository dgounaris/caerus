// See https://aka.ms/new-console-template for more information

using System;
using System.Linq;
using Caerus;

var weatherClient = new WeatherProvider();
var forecastClient = new ForecastProvider();

var city = args.FirstOrDefault();

if (city is null)
{
    Console.WriteLine("City name:");
    city = Console.ReadLine();
}

double forecastOffset;
WeatherSnapshotData weatherSnapshot;

if (args.Length == 2)
{
    forecastOffset = Double.Parse(args[1]);
    var currentTime = DateTime.UtcNow;
    weatherSnapshot = await forecastClient.GetForecastAsync(city!, currentTime.AddHours(forecastOffset));
}
else
{
    weatherSnapshot = await weatherClient.GetCurrentWeatherAsync(city!);
}

Console.WriteLine($"Time: {weatherSnapshot.Datetime}");
Console.WriteLine($"City: {weatherSnapshot.City}");
Console.WriteLine($"Country: {weatherSnapshot.Country}");
Console.WriteLine($"Description: {weatherSnapshot.Description}");
Console.WriteLine($"Temperature: {weatherSnapshot.Temp}");
Console.WriteLine($"Feels Like: {weatherSnapshot.FeelsLike}");
Console.WriteLine($"Humidity: {weatherSnapshot.Humidity}");
Console.WriteLine($"Clouds: {weatherSnapshot.Clouds}");
