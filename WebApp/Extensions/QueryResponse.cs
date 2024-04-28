using Newtonsoft.Json.Linq;
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
            return weatherForecast;
        }

    }
}
