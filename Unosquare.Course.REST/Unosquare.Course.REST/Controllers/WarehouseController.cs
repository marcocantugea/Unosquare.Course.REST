using Microsoft.AspNetCore.Mvc;

namespace Unosquare.Course.REST.Controllers
{
    [ApiController]
    [Route("warehouse")]
    public class WarehouseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetWarehouses()
        {

            return this.Ok();
        }
    }
}
