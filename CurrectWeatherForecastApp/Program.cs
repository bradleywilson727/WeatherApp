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

            Console.WriteLine("Please enter your zipcode.");
            var zipCode = Console.ReadLine();

            var apiCall = $"https://api.openweathermap.org/data/2.5/weather?zip={zipCode},us&appid={apiKey}&units=imperial";

            Console.WriteLine();

            Console.WriteLine($"It is currently {WeatherMap.GetTemp(apiCall)}°F in your location.");

        }
    }
}
