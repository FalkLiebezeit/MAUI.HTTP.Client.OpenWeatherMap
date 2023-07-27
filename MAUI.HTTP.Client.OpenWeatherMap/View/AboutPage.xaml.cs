using MAUI.HTTP.Client.OpenWeatherMap.ViewModel;




namespace MAUI.HTTP.Client.OpenWeatherMap.View;


public partial class AboutPage : ContentPage
{
    public AboutPage()
    {
        BindingContext = new AboutViewModel();

        InitializeComponent();
    }
}