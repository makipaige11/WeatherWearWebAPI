using System;
namespace WWClassLib.Engine
{
    public class WeatherToOutfitEngine
    {


        public string Bottom;
        public string Top;
        public string Jacket;
        public string Shoes;
        public string Accessories;
        public string Other;


        public WeatherToOutfitEngine()
        {

        }

        public void ClearOutfitPrediction()
        {
            Bottom = string.Empty;
            Top = string.Empty;
            Jacket = string.Empty;
            Shoes = string.Empty;
            Accessories = string.Empty;
            Other = string.Empty;
        }

        public void RunEngine(WWClassLib.Models.Forecast.RootObject data)
        {
            ClearOutfitPrediction();

            var conditions = data.forecast.simpleforecast.forecastday[0].conditions;
            bool isSunny = conditions.Contains("sun") ? true : false;
            bool isRainy = conditions.Contains("rain") ? true : false;
            bool isSnowy = conditions.Contains("rain") ? true : false;

            int fahrenheit;
            if (int.TryParse(data.forecast.simpleforecast.forecastday[0].high.fahrenheit, out fahrenheit))

                if (isRainy)
                {
                    Shoes = "Wellies";
                }
                else if (isSnowy)
                {
                    Shoes = "Snow Boots";
                }
                else if (isSunny)
                    if (fahrenheit >= 80)
                    {
                        Shoes = "Flip-Flops";
                    }

                    else if (fahrenheit >= 50)

                    {
                        Shoes = "Closed Toed Shoes";
                    }
                    else if (fahrenheit <= 10)
                    {
                        Shoes = "Fuzzy Warm Slippers";

                    }
                    else
                    {
                        Shoes = "Boots or Sneaker";

                        {

                            if (fahrenheit >= 70)
                            {
                                Bottom = "shorts/skirt";
                                Top = "T-shirt";
                            }
                            else if (fahrenheit >= 30)
                            {
                                Bottom = "pants";
                            }

                            else if (fahrenheit < 30)
                            {
                                Bottom = "snow pants";
                            }
                        }
                    }
        }
    }
}
                        