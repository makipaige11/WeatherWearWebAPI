using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace WeatherWear.ClassLib
{
    public class WeatherUndergroundCaller
    {
        public WeatherUndergroundCaller()
        {
            //this is the constructor, it is called when the object is created
        }

        public async Task<string> CallForecast(string stateAccronym, string city)
        {
            try
            {
                string path = $"{Constants.WeatherUndergroundForcast}/{stateAccronym}/{city}.json";

                using (HttpClient client = new HttpClient())
                {
                    using (HttpResponseMessage response = await client.GetAsync(path))  //we are actually making the call here
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            using (HttpContent content = response.Content)
                            {
                                // ... Read the string.
                                string result = await content.ReadAsStringAsync();

                                //return the string
                                return result;
                            }
                        }
                        else
                        {
                            return $"Error {response.ReasonPhrase}";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }

        public async Task<string> CallGeoLookUp(int zip)
        {
            try
            {
                string path = $"{Constants.WeatherUndergroundGeolookup}{zip}.json";

                using (HttpClient client = new HttpClient())
                {
                    using (HttpResponseMessage response = await client.GetAsync(path))  //we are actually making the call here
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            using (HttpContent content = response.Content)
                            {
                                // ... Read the string.
                                string result = await content.ReadAsStringAsync();

                                //return the string
                                return result;
                            }
                        }
                        else
                        {
                            return $"Error {response.ReasonPhrase}";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }
    }
}