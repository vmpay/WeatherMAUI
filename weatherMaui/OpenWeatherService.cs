using System;
using System.Diagnostics;
using System.Text.Json;

namespace weatherMaui
{
	public class OpenWeatherService : IOpenWeatherService
	{
        HttpClient _client;

        public OpenWeatherService()
		{
            _client = new HttpClient();
		}

        public async Task<WeatherResponse> RefreshDataAsync()
        {

            Uri uri = new("https://api.openweathermap.org/data/2.5/find?q=Warsaw&appid=token&units=metric");
            try
            {
                HttpResponseMessage response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    WeatherResponse weatherResponse = WeatherResponse.FromJson(content);
                    Debug.WriteLine(@"\tSUCCESS {0}", weatherResponse.ToString());
                    return weatherResponse;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
            throw new NotImplementedException();
        }
    }
}

