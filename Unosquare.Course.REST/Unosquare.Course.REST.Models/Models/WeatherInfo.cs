using System;
using System.Collections.Generic;
using System.Text;
using Unosquare.Course.REST.Models.Interfaces;

namespace Unosquare.Course.REST.Models
{
    public class WeatherInfo : Interfaces.IModel
    {
        public DateTime date { set; get; }
        public int TemperatureC { set; get; }
        public string Summary { set; get; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);



    }

}
