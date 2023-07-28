using MAUI.HTTP.Client.OpenWeatherMap.View;


namespace MAUI.HTTP.Client.OpenWeatherMap;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
        
		Routing.RegisterRoute("weathermainPage", typeof(WeatherMainPage));
        Routing.RegisterRoute("aboutpage", typeof(AboutPage));
		 
    }
}
