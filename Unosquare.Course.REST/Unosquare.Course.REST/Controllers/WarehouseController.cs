using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Unosquare.Course.REST.CoreLib.Models;
using Unosquare.Course.REST.CoreLib.Repository;

namespace Unosquare.Course.REST.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class WarehouseController : Controller
    {

        private WarehouseRepository warehouserepo = null;

  
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("warehouses")]
        public IEnumerable<WarehouseInfo> GetWarehouses()
        {
            WarehouseRepository warehouserepo = new WarehouseRepository();

            return warehouserepo.getListOfWarehouses("./");
        }
    }
}
