using System;
using System.Collections.Generic;
using System.Text;
using Unosquare.Course.REST.CoreLib.Interfaces;
using System.Linq;
using Unosquare.Course.REST.CoreLib.Models;

namespace Unosquare.Course.REST.CoreLib.Repository
{
    public class WheaterRepository
    {
        public IEnumerable<IModel> GetWheaterInfo()
        {
            
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new Models.WeatherInfo
            {
                date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            }).ToList();
        }


        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
    }
}
