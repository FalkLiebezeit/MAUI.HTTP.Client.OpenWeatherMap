using Newtonsoft.Json;
using MAUI.HTTP.Client.OpenWeatherMap.Model;

namespace MAUI.HTTP.Client.OpenWeatherMap.Service
{

    public class OpenWeatherMapWeatherService : IWeatherService
    {
        public async Task<Forecast> GetForecast(double latitude, double longitude)
        {
            var language = System.Globalization.CultureInfo.CurrentUICulture.TwoLetterISOLanguageName;

            //string language = "de";

            string apiKey = "ceb9f975f5dbce2fb1e44e604ec50fbb";

            var uri = $"https://api.openweathermap.org/data/2.5/forecast?lat={latitude}&lon={longitude}&units=metric&lang={language}&appid={apiKey}";

            var httpClient = new HttpClient();

            var result = await httpClient.GetStringAsync(uri);

            var data = JsonConvert.DeserializeObject<WeatherData>(result);

            var forecast = new Forecast()
            {
                City = data.City.Name,

                Items = data.List.Select(x => new ForecastItem()
                {
                    DateTime = ToDateTime(x.Dt),
                    Temperature = x.Main.Temp,
                    WindSpeed = x.Wind.Speed,
                    Description = x.Weather.First().Description,
                    Icon = $"http://openweathermap.org/img/w/{x.Weather.First().Icon}.png"
                }).ToList()
            };

            return forecast;
        }

        private static DateTime ToDateTime(double unixTimeStamp)
        {
            DateTime dateTime = new(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);

            dateTime = dateTime.AddSeconds(unixTimeStamp).ToLocalTime();

            return dateTime;
        }
    }
}
