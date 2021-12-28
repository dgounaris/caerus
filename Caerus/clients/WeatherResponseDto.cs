using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Caerus
{
    public record WeatherResponseDto(
        [property:JsonPropertyName("weather")]
        List<Weather> Weather,
        [property:JsonPropertyName("main")]
        Main Main,
        [property:JsonPropertyName("clouds")]
        Clouds Clouds,
        [property:JsonPropertyName("name")]
        string Name,
        [property:JsonPropertyName("sys")]
        Sys Sys,
        [property:JsonPropertyName("dt")]
        long Dt
    );

    public record Weather(
        [property:JsonPropertyName("main")]
        string Main,
        [property:JsonPropertyName("description")]
        string Description
    );

    public record Main(
        [property:JsonPropertyName("temp")]
        double Temp,
        [property:JsonPropertyName("feels_like")]
        double FeelsLike,
        [property:JsonPropertyName("humidity")]
        int Humidity
    );

    public record Clouds(
        [property:JsonPropertyName("all")]
        int All
    );

    public record Sys(
        [property:JsonPropertyName("country")]
        string Country
    );
}