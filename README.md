# caerus
A cli tool to give weather information for current or upcoming time

## Getting started
- Get an API key from OpenWeatherMap and pass it to an environment variable named `OpenWeatherApiKey`. The scope of the env var does not matter.
- Pack the tool by using `dotnet pack`
- Install the tool by using `dotnet tool install --global --add-source ./Caerus/nupkg Caerus`
- Run the tool by opening powershell/cmd and running `weather <CityName> <HoursOffset>`. HoursOffset is optional, if skipped the current weather is returned.
