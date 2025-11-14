<<<<<<< HEAD
namespace StyleMateAPI
=======
namespace StyleMate.API
>>>>>>> 856aa784dc6d940e6820f47978450581557e3a84
{
    public class WeatherForecast
    {
        public DateOnly Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string? Summary { get; set; }
    }
}
