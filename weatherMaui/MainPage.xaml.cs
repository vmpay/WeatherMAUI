namespace weatherMaui;

public partial class MainPage : ContentPage
{
	IOpenWeatherService _openWeatherService;

	public MainPage()
	{
		InitializeComponent();
        _openWeatherService = new OpenWeatherService();
		OnRefreshClicked(null, null);
    }

	private async void OnRefreshClicked(object sender, EventArgs e)
	{
		LoadingIndicator.IsRunning = true;
		RefreshBtn.IsVisible = false;

		WeatherResponse response = await _openWeatherService.RefreshDataAsync();

		List forecast = response.List[0];
		TempLabel.Text = String.Format("{0}°", forecast.Main.Temp.ToString());
		TypeLabel.Text = forecast.Weather[0].Main;
		AmpLabel.Text = String.Format("H:{0}°  L:{1}°", forecast.Main.TempMin, forecast.Main.TempMax);

        LoadingIndicator.IsRunning = false;
		RefreshBtn.IsVisible = true;
    }
}
