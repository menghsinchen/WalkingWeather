using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WalkingWeatherWpf.Model;

namespace WalkingWeatherWpf.ViewModel
{
    public static class AccuWeatherHelper
    {
        private const string BASE_URL = "http://dataservice.accuweather.com/";

        private static readonly string API_KEY = SecretHelper.ReadIniValue("AccuWeather", "ApiKey");

        public static List<City> GetCities(string query)
        {
            List<City> cities = new List<City>();
            string url = $"{BASE_URL}locations/v1/cities/autocomplete?apikey={API_KEY}&q={query}";
            using(HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = client.GetAsync(url).Result;
                string json = response.Content.ReadAsStringAsync().Result;
                cities = JsonConvert.DeserializeObject<List<City>>(json);
            }
            return cities;
        }

        public static CurrentConditions GetCurrentConditions(string locationKey)
        {
            CurrentConditions currentConditions = new CurrentConditions();
            string url = $"{BASE_URL}currentconditions/v1/{locationKey}?apikey={API_KEY}";
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = client.GetAsync(url).Result;
                string json = response.Content.ReadAsStringAsync().Result;
                currentConditions = JsonConvert.DeserializeObject<List<CurrentConditions>>(json).FirstOrDefault();
            }
            return currentConditions;
        }
    }
}
