using System;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace CurrectWeatherForecastApp
{
    public class WeatherMap
    {
        public static double GetTemp(string apiCall)
        {
            var client = new HttpClient();
            var response = client.GetStringAsync(apiCall).Result;
            var temp = double.Parse(JObject.Parse(response)["main"]["temp"].ToString());

            return temp;
        }
    }
}
