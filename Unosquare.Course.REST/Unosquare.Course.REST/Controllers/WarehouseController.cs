using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Unosquare.Course.REST.Models;
using Unosquare.Course.REST.CoreLib.Contracts;
using System.Text.RegularExpressions;

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

        public IEnumerable<WarehouseInfo> Index()
        {
            return warehouseService.getListOfWarehouses("./");
        }

        [HttpGet("view/{codeWarehouse}")]
        public WarehouseInfo getWarehouseInfo([FromRoute] string codeWarehouse)
        {
            return warehouseService.getWarehouseInfo(codeWarehouse,"./");
        }

        [HttpPost("add")]
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

        [HttpGet("search")]
        public IEnumerable<WarehouseInfo> searchWarehouse([FromQuery]string code, [FromQuery] string name )
        {
            List<WarehouseInfo> dataSaved = warehouseService.getListOfWarehouses("./");

            if (name != null && code != null)
            {
                List<WarehouseInfo> filterboth = dataSaved.FindAll(item => ((Regex.IsMatch(item.warehouseName, @"" + name, RegexOptions.Singleline | RegexOptions.IgnoreCase)) && string.Equals(item.warehouseCodeName, code, System.StringComparison.OrdinalIgnoreCase)));
                return filterboth;
            }

            if (name != null)
            {
                List<WarehouseInfo> filterByName = dataSaved.FindAll(item => Regex.IsMatch(item.warehouseName, @""+name, RegexOptions.Singleline | RegexOptions.IgnoreCase));
                return filterByName;
            }

           

            List<WarehouseInfo> filter = dataSaved.FindAll(item => string.Equals(item.warehouseCodeName,code,System.StringComparison.OrdinalIgnoreCase));
            return filter;
        }

        
    }
}
