using MAUI.HTTP.Client.OpenWeatherMap.ViewModel;

namespace MAUI.HTTP.Client.OpenWeatherMap.View;

public partial class MainPage : ContentPage
{

    
    int count = 0;

    private MainViewModel vm = new MainViewModel();

    public MainPage()
    {
        InitializeComponent();

        BindingContext = vm;
    }

    private void OnCounterClicked(object sender, EventArgs e)
    {
        count++;

        if (count == 1)
            CounterBtn.Text = $"Clicked {count} time";
        else
            CounterBtn.Text = $"Clicked {count} times";

        SemanticScreenReader.Announce(CounterBtn.Text);
    }

    


}