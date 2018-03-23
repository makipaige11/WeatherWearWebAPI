using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherWear.ClassLib
{
    public static class Constants
    {
        public static string WEATHER_UNDERGROUND_KEY = "ad6fae97afface29";

        public static string WeatherUndergroundBaseAddress = "http://api.wunderground.com/api/";

        //http://api.wunderground.com/api/ad6fae97afface29/forecast/q/CA/San_Francisco.json
        public static string WeatherUndergroundForcast = $"{WeatherUndergroundBaseAddress}{WEATHER_UNDERGROUND_KEY}/forecast/q/";

        //http://api.wunderground.com/api/ad6fae97afface29/geolookup/q/94107.json
        public static string WeatherUndergroundGeolookup = $"{WeatherUndergroundBaseAddress}{WEATHER_UNDERGROUND_KEY}/geolookup/q/";
    }
}