using MAUI.HTTP.Client.OpenWeatherMap.ViewModel;




namespace MAUI.HTTP.Client.OpenWeatherMap.View;


public partial class WeatherMainPage : ContentPage
{


    public WeatherMainPage()
    {
        //BindingContext = new WeatherMainViewModel();

        InitializeComponent();

        BindingContext = Resolver.Resolve<WeatherMainViewModel>();
    }


    protected override void OnAppearing()
    {
        base.OnAppearing();

        if (BindingContext is WeatherMainViewModel viewModel)
        {

            MainThread.BeginInvokeOnMainThread(async () =>
            {
                await viewModel.LoadData();
            });

        }

    }
}