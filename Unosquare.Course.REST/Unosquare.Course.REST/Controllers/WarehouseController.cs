using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Unosquare.Course.REST.Models;
using Unosquare.Course.REST.CoreLib.Repository;
using Unosquare.Course.REST.CoreLib.Services;
using Unosquare.Course.REST.CoreLib.Contracts;

namespace Unosquare.Course.REST.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class WarehouseController : Controller
    {

        IWarehouseService warehouseService;

        public WarehouseController(IWarehouseService warehouseservice)
        {
            warehouseService = warehouseservice;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("warehouses")]
        public IEnumerable<WarehouseInfo> GetWarehouses()
        {

            return warehouseService.getListOfWarehouses("./");
        }

        [HttpGet("info/{codeWarehouse}")]
        public WarehouseInfo getWarehouseInfo([FromRoute] string codeWarehouse)
        {
            return warehouseService.getWarehouseInfo(codeWarehouse,"./");
        }

        [HttpPost("create")]
        public IActionResult addNewWarehouse([FromBody]WarehouseInfo newWarehouseInfo)
        {
            if (newWarehouseInfo == null) return this.BadRequest();
            if (newWarehouseInfo.warehouseCodeName == null || newWarehouseInfo.warehouseName == null) return this.BadRequest();
            try
            {
                //obtener la lista actual de warehouses
                List<WarehouseInfo> dataSaved = warehouseService.getListOfWarehouses("./");
                dataSaved.Add(newWarehouseInfo);

                warehouseService.saveWarehousesInformation(dataSaved);
            }
            catch (System.Exception)
            {

                return this.UnprocessableEntity();
            }
            return this.Ok();
        }
    }
}
