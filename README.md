# caerus
A cli tool to give weather information for current or upcoming time

## Getting started
- Pack the tool by using `dotnet pack`
- Install the tool by using `dotnet tool install --global --add-source ./Caerus/nupkg Caerus`
- Run the tool by opening powershell/cmd and running `weather <CityName> <HoursOffset>`. HoursOffset is optional, if skipped the current weather is returned.
