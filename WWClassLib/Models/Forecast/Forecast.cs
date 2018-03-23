using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WWClassLib.Models.Forecast
{
    public class Avewind
    {
        public int degrees { get; set; }
        public string dir { get; set; }
        public int kph { get; set; }
        public int mph { get; set; }
    }

    public class Date
    {
        public string ampm { get; set; }
        public int day { get; set; }
        public string epoch { get; set; }
        public int hour { get; set; }
        public string isdst { get; set; }
        public string min { get; set; }
        public int month { get; set; }
        public string monthname { get; set; }
        public string pretty { get; set; }
        public int sec { get; set; }
        public string tz_long { get; set; }
        public string tz_short { get; set; }
        public string weekday { get; set; }
        public string weekday_short { get; set; }
        public int yday { get; set; }
        public int year { get; set; }
    }

    public class Features
    {
        public int forecast { get; set; }
    }

    public class Forecast
    {
        public Simpleforecast simpleforecast { get; set; }
        public TxtForecast txt_forecast { get; set; }
    }

    public class Forecastday
    {
        public string fcttext { get; set; }
        public string fcttext_metric { get; set; }
        public string icon { get; set; }
        public string icon_url { get; set; }
        public int period { get; set; }
        public string pop { get; set; }
        public string title { get; set; }
    }

    public class Forecastday2
    {
        public int avehumidity { get; set; }
        public Avewind avewind { get; set; }
        public string conditions { get; set; }
        public Date date { get; set; }
        public High high { get; set; }
        public string icon { get; set; }
        public string icon_url { get; set; }
        public Low low { get; set; }
        public int maxhumidity { get; set; }
        public Maxwind maxwind { get; set; }
        public int minhumidity { get; set; }
        public int period { get; set; }
        public int pop { get; set; }
        public QpfAllday qpf_allday { get; set; }
        public QpfDay qpf_day { get; set; }
        public QpfNight qpf_night { get; set; }
        public string skyicon { get; set; }
        public SnowAllday snow_allday { get; set; }
        public SnowDay snow_day { get; set; }
        public SnowNight snow_night { get; set; }
    }

    public class High
    {
        public string celsius { get; set; }
        public string fahrenheit { get; set; }
    }

    public class Low
    {
        public string celsius { get; set; }
        public string fahrenheit { get; set; }
    }

    public class Maxwind
    {
        public int degrees { get; set; }
        public string dir { get; set; }
        public int kph { get; set; }
        public int mph { get; set; }
    }

    public class QpfAllday
    {
        public double? @in { get; set; }
        public double? mm { get; set; }
    }

    public class QpfDay
    {
        public double? @in { get; set; }
        public double? mm { get; set; }
    }

    public class QpfNight
    {
        public double? @in { get; set; }
        public double? mm { get; set; }
    }

    public class Response
    {
        public Features features { get; set; }
        public string termsofService { get; set; }
        public string version { get; set; }
    }

    public class RootObject
    {
        public Forecast forecast { get; set; }
        public Response response { get; set; }
    }

    public class Simpleforecast
    {
        public List<Forecastday2> forecastday { get; set; }
    }

    public class SnowAllday
    {
        public double? @in { get; set; }
        public double? cm { get; set; }
    }

    public class SnowDay
    {
        public double? @in { get; set; }
        public double? cm { get; set; }
    }

    public class SnowNight
    {
        public double? @in { get; set; }
        public double? cm { get; set; }
    }

    public class TxtForecast
    {
        public string date { get; set; }
        public List<Forecastday> forecastday { get; set; }
    }
}