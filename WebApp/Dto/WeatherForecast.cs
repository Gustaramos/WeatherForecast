using System.Reflection.Metadata;

namespace WebApp.Dto
{
    public class WeatherForecast
    {
        //public Coordinate Coord { get; set; } = new();
        //public string Base { get; set; } = string.Empty;
        //public Sys Sys { get; set; } = new();
        //public Wind Wind { get; set; } = new();
        //public int Visibility { get; set; }
        //public DateTime Timezone { get; set; }
        //public int Id { get; set; }
        //public int Cod { get; set; }

        public IEnumerable<Weather> Weather { get; set; } = Enumerable.Empty<Weather>();
        public Main Main { get; set; } = new();        
        public DateTime Dt { get; set; }
        public string Name { get; set; } = string.Empty;


    }
    public class Coordinate 
    {
        public double Lon { get; set; }
        public double Lat { get; set; }    
    }

    public class Weather
    {
        public int Id { get; set; }
        public string Main { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Icon { get; set; } = string.Empty;   
    }
    
    public class Main
    {
        public double Temp { get; set; }
        public double FeelsLike {  get; set; }
        public double TempMin { get; set; }
        public double TempMax { get; set; }
        public double Pressure { get; set; }
        public double Humidity { get; set; }
    }

    public class Wind
    {
        public double Speed { get; set; }
        public double Deg {  get; set; }
    }

    public class Sys
    {
        public int Type {  get; set; }
        public int Id {  set; get; }
        public string Country { get; set; } = string.Empty;
        public DateTime Sunrise { get; set; }
        public DateTime Sunset { get; set; }


    }

}
