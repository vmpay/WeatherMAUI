using System;
namespace weatherMaui
{
	public interface IOpenWeatherService
	{
		Task<WeatherResponse> RefreshDataAsync();
	}
}

