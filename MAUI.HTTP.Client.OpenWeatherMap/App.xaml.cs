namespace MAUI.HTTP.Client.OpenWeatherMap;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

        // Falk
        //  Bootstrapper.Init();

        MainPage = new AppShell();
	}
}
