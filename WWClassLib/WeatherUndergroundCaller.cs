using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace WWClassLib
{
    public class WeatherUndergroundCaller
    {
        public WeatherUndergroundCaller()
        {
            //this is the constructor, it is called when the object is created
        }

        public async Task<WWClassLib.Models.Forecast.RootObject> GetForecast(string stateAccronym, string city)
        {
            try
            {
                string path = $"{Constants.WeatherUndergroundForcast}/{stateAccronym}/{city}.json";

                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json"));
                    using (HttpResponseMessage response = await client.GetAsync(path))  //we are actually making the call here
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            using (HttpContent content = response.Content)
                            {
                                // ... Read the string.
                                //string result = await content.ReadAsStringAsync();

                                //instead of reading the string, let's convert the JSON into objects and return those
                                var result = await content.ReadAsAsync<WWClassLib.Models.Forecast.RootObject>();

                                return result;
                            }
                        }
                        else
                        {
                            Debug.WriteLine($"Error {response.ReasonPhrase}");
                            return null;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error {ex.Message}");
                Debug.WriteLine($"StackTrace {ex.StackTrace}");
                return null;
            }
        }

        public async Task<WWClassLib.Models.GeoLookup.RootObject> GetGeoLookUp(int zip)
        {
            try
            {
                string path = $"{Constants.WeatherUndergroundGeolookup}{zip}.json";

                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json"));

                    using (HttpResponseMessage response = await client.GetAsync(path))  //we are actually making the call here
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            using (HttpContent content = response.Content)
                            {
                                // ... Read the string.
                                //string result = await content.ReadAsStringAsync();

                                //instead of reading the string, let's convert the JSON into objects and return those
                                var result = await content.ReadAsAsync<WWClassLib.Models.GeoLookup.RootObject>();

                                return result;
                            }
                        }
                        else
                        {
                            Debug.WriteLine($"Error {response.ReasonPhrase}");
                            return null;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error {ex.Message}");
                Debug.WriteLine($"StackTrace {ex.StackTrace}");
                return null;
            }
        }
    }
}