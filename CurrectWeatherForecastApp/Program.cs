using System;
using System.IO;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace CurrectWeatherForecastApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var key = File.ReadAllText("appsettings.json");
            var apiKey = JObject.Parse(key).GetValue("DefaultKey").ToString();

            var client = new HttpClient();
            var weatherURL = $"https://api.openweathermap.org/data/2.5/weather?zip=35040,us&appid={apiKey}&units=imperial";
            var weatherResult = client.GetStringAsync(weatherURL).Result;
            var weatherDisplay = JObject.Parse(weatherResult)["main"].ToString();

            Console.WriteLine(weatherDisplay);
        }
    }
}
