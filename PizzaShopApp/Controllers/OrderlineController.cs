using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaShopApp.CRUD;

namespace PizzaShopApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderlineController : ControllerBase
    {
        private readonly OrderlineCRUD _orderline;
        public OrderlineController(OrderlineCRUD orderline)
        {
            _orderline = orderline;
        }

        [HttpGet]
        public async Task<IActionResult> GetSomething()
        {
            return Ok(await _orderline.GetAllOrderlines());
        }

    }
}
