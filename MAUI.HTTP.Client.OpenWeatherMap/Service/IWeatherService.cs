using MAUI.HTTP.Client.OpenWeatherMap.Model;

namespace MAUI.HTTP.Client.OpenWeatherMap.Service
{
    public interface IWeatherService
    {
        Task<Forecast> GetForecast(double latitude, double longitude);
    }

}
