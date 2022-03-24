using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PizzaShopApp.CRUD;
using PizzaShopApp.Models;
using System.Text.Json;

namespace PizzaShopApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        private readonly PizzaCrud _pizzaCrud;
        public PizzaController(PizzaCrud pizzaCrud)
        {
            _pizzaCrud = pizzaCrud;
        }

        [HttpGet]
        public async Task<IActionResult> GetSomething()
        {
            return Ok(await _pizzaCrud.GetAllPizzas());
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] JsonElement pizza)
        {
            if (string.IsNullOrEmpty(pizza.GetRawText()))
                return Ok("Empty");

            var newPizza = JsonConvert.DeserializeObject<PizzaModel>(pizza.GetRawText());
            var result = _pizzaCrud.CreatePizza(newPizza);
            return Ok(result);
        }
        public async Task<IActionResult> DeletePizza(int id)
        {
            try
            {
                return Ok(_pizzaCrud.DeletePizza(id));
            }
            catch
            {
                return Ok("Error");
            }

        }
    }
}
