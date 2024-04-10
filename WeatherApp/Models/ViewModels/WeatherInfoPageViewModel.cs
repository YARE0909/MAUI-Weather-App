using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Services;

namespace WeatherApp.Models.ViewModels
{
    internal partial class WeatherInfoPageViewModel : ObservableObject
    {
        private readonly WeatherAPIService _weatherAPIService;

        public WeatherInfoPageViewModel()
        {
            _weatherAPIService = new WeatherAPIService();
        }

        [ObservableProperty]
        private string city;

        [ObservableProperty]
        private float temperature;

        [ObservableProperty]
        private string weatherDescription;

        [ObservableProperty]
        private string location;

        [ObservableProperty]
        private int humidity;

        [ObservableProperty]
        private int cloudCoverLevel;

        [ObservableProperty]
        private string isDay;

        [ObservableProperty]
        private string error;

        [RelayCommand]
        private async Task FetchWeatherInfo() 
        {
            if (City == null || City == "")
            {
                Error = "Please provide a city";

            }else
            {
                Error = "";
                var weatherApiResponse = await _weatherAPIService.GetWeatherInfo(City);

                if(weatherApiResponse != null)
                    {
                        Temperature = weatherApiResponse.current.temp_c;
                        WeatherDescription = weatherApiResponse.current.condition.text;
                        Location = weatherApiResponse.location.name;
                        Humidity = weatherApiResponse.current.humidity;
                        CloudCoverLevel = weatherApiResponse.current.cloud;
                        IsDay = weatherApiResponse.current.is_day == 1 ? "YES": "NO";
                    }
            }
        }
    }
}
