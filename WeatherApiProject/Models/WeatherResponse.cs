namespace WeatherApiProject.Models
{
    public class WeatherResponse
    {
        public Current Current { get; set; }
        public Location Location { get; set; }
    }

    public class Current
    {
        public double Temp_C { get; set; }
        public Condition Condition { get; set; }
    }

    public class Condition
    {
        public string Text { get; set; }
        public string Icon { get; set; }
    }

    public class Location
    {
        public string Name { get; set; }
    }
}
