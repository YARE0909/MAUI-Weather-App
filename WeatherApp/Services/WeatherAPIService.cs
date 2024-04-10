using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Models.APIModels;

namespace WeatherApp.Services
{
    internal class WeatherAPIService
    {
        private readonly HttpClient _httpClient;

        public WeatherAPIService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(Constants.API_BASE_URL);    
        }

        public async Task<WeatherAPIResponse> GetWeatherInfo(string City)
        {
            if(Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                return null;
            }

            return await _httpClient.GetFromJsonAsync<WeatherAPIResponse>($"forecast.json?key={Constants.API_KEY}&q={City}");
        }
    }
}
