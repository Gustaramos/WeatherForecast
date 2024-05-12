using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Globalization;
using WebApp.Dto;


namespace WebApp.Extensions
{
    public static class QueryResponse
    {
        public static WeatherForecast ParseWeather(this string jsonResponse)
        {
            var weatherForecast = new WeatherForecast();
            var jsonData = JObject.Parse(jsonResponse);
            if (jsonData.SelectToken("name") != null)
            {
                weatherForecast.Name = jsonData.SelectToken("name")?.ToString() ?? string.Empty;
            }

            if (jsonData.SelectToken("dt") != null)
            {
                var dateFromSeconds = long.Parse(jsonData.SelectToken("dt")?.ToString() ?? string.Empty, CultureInfo.InvariantCulture);
                weatherForecast.Dt = DateTimeOffset.FromUnixTimeSeconds(dateFromSeconds).DateTime;
            }

            if (jsonData.SelectToken("main") != null)
            {
                var tempToString = $"{jsonData.SelectToken("main")?.SelectToken("temp") ?? string.Empty}";

                if (!string.IsNullOrEmpty(tempToString))
                {
                    weatherForecast.Main.Temp = double.Parse(tempToString);
                }

                var feeslLikeToString = $"{jsonData.SelectToken("main")?.SelectToken("feels_like") ?? string.Empty}";

                if (!string.IsNullOrEmpty(feeslLikeToString))
                {
                    weatherForecast.Main.FeelsLike = double.Parse(feeslLikeToString);   
                }

                var tempMin = $"{jsonData.SelectToken("main")?.SelectToken("temp_min") ?? string.Empty}";


                if (!string.IsNullOrEmpty(tempMin))
                {
                    weatherForecast.Main.TempMin = double.Parse(tempMin);
                }

                var tempMax = $"{jsonData.SelectToken("main")?.SelectToken("temp_max") ?? string.Empty}";

                if (!string.IsNullOrEmpty(tempMax))
                {
                    weatherForecast.Main.TempMax = double.Parse(tempMax);
                }

                var pressure = $"{jsonData.SelectToken("main")?.SelectToken("pressure") ?? string.Empty}";
                
                if(!string.IsNullOrEmpty(pressure))
                {
                    weatherForecast.Main.Pressure = double.Parse(pressure);
                }

                var humidity = $"{jsonData.SelectToken("main")?.SelectToken("humidity") ?? string.Empty}";
                
                if(!string.IsNullOrEmpty(humidity))
                {
                    weatherForecast.Main.Humidity = double.Parse(humidity);
                }
            }


            var weatherList = jsonData.SelectToken("weather");

            if (weatherList != null)
            {
                foreach (var item in weatherList)
                {
                    var weather = new Weather();

                    var idToStringt = $"{item.SelectToken("id") ?? string.Empty}";

                    if (!string.IsNullOrEmpty(idToStringt))
                    {
                        weather.Id = int.Parse(idToStringt);
                    }

                    if (!string.IsNullOrEmpty($"{item.SelectToken("main")}"))
                    {
                        weather.Main = $"{item.SelectToken("main")}";
                    }

                    if (!string.IsNullOrEmpty($"{item.SelectToken("description")}"))
                    {
                        weather.Description = $"{item.SelectToken("description")}";
                    }

                    if (!string.IsNullOrEmpty($"{item.SelectToken("icon")}"))
                    {
                        weather.Icon = $"{item.SelectToken("icon")}";
                    }

                    weatherForecast.Weathers.Add(weather);
                }
            }

            return weatherForecast;
        }

    }
}
