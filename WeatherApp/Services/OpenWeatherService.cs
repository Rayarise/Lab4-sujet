using OpenWeatherAPI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Converter;
using WeatherApp.Models;
using WeatherApp.ViewModels;

namespace WeatherApp
{
    class OpenWeatherService : ITemperatureService
    {
        private OpenWeatherProcessor owp;
        public TemperatureModel LastTemp;


        public OpenWeatherService(string apiKey)
        {
            owp = OpenWeatherProcessor.Instance;

            owp.ApiKey = apiKey;


        }
        public async Task<TemperatureModel> GetTempAsync()
        {


            var currentweather = await owp.GetCurrentWeatherAsync();
            TemperatureModel temperature = new TemperatureModel();

            DateTime start = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            temperature.DateTime = start.AddSeconds(currentweather.DateTime).ToLocalTime();

            temperature.Temperature = currentweather.Main.Temperature;

            TemperatureConverter.FahrenheitInCelsius(temperature.Temperature);

            temperature.Temperature = Math.Round(temperature.Temperature, 0);

            LastTemp = temperature;


            return temperature;

        }

      
    }
}
