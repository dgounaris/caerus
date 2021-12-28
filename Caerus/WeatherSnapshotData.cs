using System;

namespace Caerus
{
    public record WeatherSnapshotData(
        string City,
        string Country,
        string Description,
        double Temp,
        double FeelsLike,
        int Humidity,
        int Clouds,
        DateTime Datetime
    );
}