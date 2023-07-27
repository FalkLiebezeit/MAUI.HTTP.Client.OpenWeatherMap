using CommunityToolkit.Mvvm.ComponentModel;


namespace MAUI.HTTP.Client.OpenWeatherMap.ViewModel
{
    

    public partial class AboutViewModel : ObservableObject
    {

        [ObservableProperty] private string apiVersion;
        [ObservableProperty] private string appName;

        public AboutViewModel()
        {
            appName = "Weatherforecast";

            apiVersion = "0.1";

        }
    }
}

 






