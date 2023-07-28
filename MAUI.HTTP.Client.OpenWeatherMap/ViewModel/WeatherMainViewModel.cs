using CommunityToolkit.Mvvm.ComponentModel;

using MAUI.HTTP.Client.OpenWeatherMap.Model;
using MAUI.HTTP.Client.OpenWeatherMap.Service;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MAUI.HTTP.Client.OpenWeatherMap.ViewModel
{

    public class WeatherMainViewModel : ViewModel
    {
        private readonly IWeatherService weatherService;


        public WeatherMainViewModel(IWeatherService weatherService)
        {
            this.weatherService = weatherService;
        }

        public WeatherMainViewModel()
        { }

        private bool isRefreshing;
        public bool IsRefreshing
        {
            get => isRefreshing;
            set => Set(ref isRefreshing, value);
        }

        public async Task LoadData()
        {
            IsRefreshing = true;

            var location = await Geolocation.GetLocationAsync();
            var forecast = await weatherService.GetForecast(location.Latitude, location.Longitude);

            var itemGroups = new List<ForecastGroup>();


            foreach (var item in forecast.Items)
            {
                if (!itemGroups.Any())
                {
                    itemGroups.Add(new ForecastGroup(new List<ForecastItem>() { item }) { Date = item.DateTime.Date });

                    continue;
                }

                var group = itemGroups.SingleOrDefault(x => x.Date == item.DateTime.Date);

                if (group == null)
                {
                    itemGroups.Add(new ForecastGroup(new List<ForecastItem>() { item }) { Date = item.DateTime.Date });

                    continue;
                }

                group.Items.Add(item);
            }

            Days = new ObservableCollection<ForecastGroup>(itemGroups);
            City = forecast.City;

            //Falk
            IsRefreshing = false;

        }


        private string city;
        public string City
        {
            get => city;
            set => Set(ref city, value);
        }

        private ObservableCollection<ForecastGroup> days;
        public ObservableCollection<ForecastGroup> Days
        {
            get => days;
            set => Set(ref days, value);
        }

        public ICommand Refresh => new Command(async () =>
        {
            await LoadData();
        });

    }
}
