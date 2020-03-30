using AutoMapper;

namespace SimpleDotNetCoreApi.Queries.WeatherForecast
{
    public partial class GetWeatherForecast
    {
        public class Mapping : Profile
        {
            public Mapping()
            {
                CreateMap<WeatherForecast, WeatherForecastResponse>();
            }
        }
    }
}
