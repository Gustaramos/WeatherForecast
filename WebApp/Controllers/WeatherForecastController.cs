using Microsoft.AspNetCore.Mvc;
using WebApp.Dto;
using WebApp.Extensions;

namespace WebApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly HttpClient client = new HttpClient(); 
        

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<WeatherForecast?> Get([FromQuery] string lat, [FromQuery] string lon)
        {
            var API_Key = "43477083eaa008c656ec528f72a5e9bb";
            try
            { 
                using HttpResponseMessage response = await client.GetAsync($"https://api.openweathermap.org/data/2.5/weather?lat={lat}&lon={lon}&appid={API_Key}");
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();

                return responseBody.ParseWeather();    
            }
            catch (Exception ex) 
            {
                return new WeatherForecast();
            }       
        }
    }
}
