using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WWClassLib;
using WWClassLib.Engine;

namespace WeatherWear.ConsoleApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            RunThis(args).GetAwaiter().GetResult();
        }

        private static async Task RunThis(string[] args)
        {
            Console.WriteLine("Wondering what you should wear today?");
            bool correctInput = false;
            while (!correctInput)
            {
                Console.WriteLine("Please enter your 5 digit zip code");

                string zipInput = Console.ReadLine();
                if (zipInput.Length == 5)
                {
                    int zip;
                    if (int.TryParse(zipInput, out zip))
                    {
                        //If we get here, then the zip is five digits - YAY!
                        Console.WriteLine($"Yay! We got your 5 digit zip code ({zip}), now we can do something with it!");

                        //we need to switch this boolean to true so that the error message doesn't show up
                        correctInput = true;

                        Console.WriteLine($"Looking for your zip code... {zip}");
                        WeatherUndergroundCaller wug = new WeatherUndergroundCaller();
                        var geolookupRootObject = await wug.GetGeoLookUp(zip);

                        //now that we have the result of the first call, we can parse it and get the two digit city acronym and the name of the city
                        string city = geolookupRootObject.location.city;
                        string stateAcronym = geolookupRootObject.location.state;
                        Console.WriteLine($"Found your location! {city}, {stateAcronym}");

                        //now let's get the weather forcast for that city
                        var forcastRootObject = await wug.GetForecast(stateAcronym, city);

                        Console.WriteLine($"Found your Weather Forecast!");
                        Console.WriteLine($"Current Weather Conditions: {forcastRootObject.forecast.simpleforecast.forecastday[0].conditions}");
                        Console.WriteLine($"Current High: {forcastRootObject.forecast.simpleforecast.forecastday[0].high.fahrenheit} F");
                        Console.WriteLine($"Current Low: {forcastRootObject.forecast.simpleforecast.forecastday[0].low.fahrenheit} F");
                        Console.WriteLine($"Current Average Wind: {forcastRootObject.forecast.simpleforecast.forecastday[0].avewind.mph} mph");
                        Console.WriteLine($"Current Average Humidity: {forcastRootObject.forecast.simpleforecast.forecastday[0].avehumidity}");

                        //when we have this result, we can parse it to get the weather details so that we can generate our clothing prediction

                        WeatherToOutfitEngine w2oe = new WeatherToOutfitEngine();
                        w2oe.RunEngine(forcastRootObject);
                        Console.WriteLine($"Hmmmm... We are thinking you should wear: {w2oe.Bottom}");


                        //then we send the results of the second weather call along with our prediction back to the caller
                    }
                    else
                    {
                        //couldn't parse the input
                        correctInput = false;
                    }
                }
                else
                {
                    //length was not 5
                    correctInput = false;
                }

                if (!correctInput)
                {
                    Console.WriteLine("Let's try that again.... please enter a 5 digit zip code");
                }
            }

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}