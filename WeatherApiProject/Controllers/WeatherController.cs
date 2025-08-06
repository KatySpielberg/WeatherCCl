using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using WeatherApiProject.Models;

namespace WeatherApiProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherController : ControllerBase
    {
        private readonly HttpClient _httpClient;
        private const string ApiKey = "39f8ecaf506c4f76b3f55139222906";

        public WeatherController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // GET api/weather/current?city=London
        [HttpGet("current")]
        public async Task<IActionResult> GetCurrentWeather([FromQuery] string city)
        {
            var url = $"https://api.weatherapi.com/v1/forecast.json?key={ApiKey}&q={city}&days=1&aqi=yes&alerts=yes";

            var response = await _httpClient.GetAsync(url);
            if (!response.IsSuccessStatusCode)
                return BadRequest("API call failed");

            var content = await response.Content.ReadAsStringAsync();
            var weather = JsonSerializer.Deserialize<WeatherResponse>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return Ok($"The weather in {weather.Location.Name} is: temp{weather.Current.Temp_C} condition {weather.Current.Condition.Text}");
        }

        // GET api/weather/forecast?city=London&days=3
        [HttpGet("forecast")]
        public async Task<IActionResult> GetForecast([FromQuery] string city, [FromQuery] int days = 1)
        {
            var url = $"https://api.weatherapi.com/v1/forecast.json?key={ApiKey}&q={city}&days={days}&aqi=yes&alerts=yes";
            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
                return BadRequest("API call failed");

            var content = await response.Content.ReadAsStringAsync();
            return Content(content, "application/json");
        }
    }
}