using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Caerus
{
    public record ForecastResponseDto(
        [property:JsonPropertyName("list")]
        List<ForecastWeatherResponseDto> List,
        [property:JsonPropertyName("city")]
        City City
    );

    public record ForecastWeatherResponseDto(
        [property:JsonPropertyName("weather")]
        List<Weather> Weather,
        [property:JsonPropertyName("main")]
        Main Main,
        [property:JsonPropertyName("clouds")]
        Clouds Clouds,
        [property:JsonPropertyName("dt")]
        long Dt,
        [property:JsonPropertyName("dt_txt")]
        string DtTxt
    );
    
    public record City(
        [property:JsonPropertyName("name")]
        string Name,
        [property:JsonPropertyName("country")]
        string Country
    );
}