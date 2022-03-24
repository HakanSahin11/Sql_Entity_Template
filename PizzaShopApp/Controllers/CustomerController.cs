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
    public class CustomerController : ControllerBase
    {
        private readonly CustomerCRUD _customerCrud;
        public CustomerController(CustomerCRUD customerCrud)
        {
            _customerCrud = customerCrud;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _customerCrud.GetAllCustomers());
        }

        [HttpGet("{id}")]
        public IActionResult GetCustomer(string id)
        {
            int intId;
            if (int.TryParse(id, out intId) == false)
                return Ok("Error, Id Cannot be converted to Int");
            
            return Ok(_customerCrud.GetCustomerById(intId));
        }



        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] JsonElement user)
        {

            var str = user.GetRawText();
            if (string.IsNullOrEmpty(str))
                return Ok("Empty");

            var newUser = JsonConvert.DeserializeObject<CustomersModel>(str);
            var result = _customerCrud.CreateCustomer(newUser);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] JsonElement customer)
        {
            var str = customer.GetRawText();
            if (string.IsNullOrEmpty(str))
                return Ok("Empty");
            var updatedCustomer = JsonConvert.DeserializeObject<CustomersModel>(str);
            return Ok(_customerCrud.UpdateCustomer(updatedCustomer));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            try
            {
                return Ok(_customerCrud.DeleteCustomer(id));
            }
            catch
            {
                return Ok("Error");
            }
        }


    }
}
