namespace MAUI.HTTP.Client.OpenWeatherMap;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

        
        Bootstrapper.Init();

        MainPage = new AppShell();
	}
}
