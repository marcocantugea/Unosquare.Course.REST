using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Unosquare.Course.REST.CoreLib.Interfaces;
using Unosquare.Course.REST.CoreLib.Repository;


namespace Unosquare.Course.REST.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<IModel> Get()
        {
            return (new WheaterRepository()).GetWheaterInfo();
        }
    }
}
