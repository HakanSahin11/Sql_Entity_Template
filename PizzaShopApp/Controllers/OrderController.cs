using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PizzaShopApp.CRUD;
using PizzaShopApp.Models;
using System.Text.Json;
using System.Text.Json.Serialization;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace PizzaShopApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly OrderCRUD _orderCrud;
        private readonly OrderlineCRUD _orderlineCrud;
        private readonly PizzaCrud _pizzaCrud;
        private readonly CustomerCRUD _customerCrud;
        public OrderController(OrderCRUD orderCrud, OrderlineCRUD orderlineCrud, PizzaCrud pizzaCrud, CustomerCRUD customerCrud)
        {
            _orderCrud = orderCrud;
            _orderlineCrud = orderlineCrud;
            _pizzaCrud = pizzaCrud;
            _customerCrud = customerCrud;
        }

        /*
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _orderCrud.GetAllOrders());
        }
        */
        [HttpGet]
        public async Task<IActionResult> GetFakturas()
        {
            var fakturas = Task.Run(() => _orderCrud.GetFaktura(0));       
            var result =  JsonSerializer.Serialize(await fakturas);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Getfaktura(string id)
        {
            int intId;
            if (int.TryParse(id, out intId) == false)
                return Ok("Error, Id Cannot be converted to Int");
            var faktura = await Task.Run(() => _orderCrud.GetFaktura(intId));

            return Ok( JsonSerializer.Serialize(faktura.FirstOrDefault()));
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] JsonElement OrderJson)
        {
            /*
            var username = "TestUser";
            var pizzaList = new List<string>();
            pizzaList.Add("Tropisk Pizza");
            pizzaList.Add("Kebab Pizza");
            */

            if (string.IsNullOrEmpty(OrderJson.GetRawText()))
                return Ok("Empty");

            var orderModel = JsonConvert.DeserializeObject<GetOrderModel>(OrderJson.GetRawText());

            var total_Amount = 0;
            foreach (var item in orderModel.Pizza_Name)
            {
                total_Amount += _pizzaCrud.GetPizza(item).Price;
            }
            var customer = _customerCrud.GetCustomer(orderModel.Username);
            var order = new OrderModel
            {
                CustomerId = customer.Id,
                Customer = customer,
                Time_Of_Order = DateTime.Now,
                Total_Price = total_Amount
            };
            var orderResult = _orderCrud.CreateOrder(order);
            if (orderResult == null)
                return Ok("false");

            foreach (var item in orderModel.Pizza_Name)
            {
                var orderline = new OrderlineModel();
                orderline.Order = orderResult;
                orderline.OrderId = orderResult.Id;

                var pizzaForeach = _pizzaCrud.GetPizza(item);
                orderline.Pizza = pizzaForeach;
                orderline.PizzaId = pizzaForeach.Id;
                _orderlineCrud.CreateOrderline(orderline);
            }




            //var GetOrderModel = new GetOrderModel { Pizza_Name = pizzaList, Username = "TestUser1" };

            //var order = new OrderModel();
            //order.Customer = _customerCrud.GetCustomer(GetOrderModel.Username);
            //order.Time_Of_Order = DateTime.Now;

            //var total_Amount = 0;
            //foreach (var item in GetOrderModel.Pizza_Name)
            //{
            //    total_Amount += _pizzaCrud.GetPizza(item).Price;
            //}

            //order.Total_Price = total_Amount;
            //_orderCrud.CreateOrder(order);

            //var savedOrder = _orderCrud.GetNewest();
            //foreach (var item in GetOrderModel.Pizza_Name)
            //{
            //    var pizza = _pizzaCrud.GetPizza(item);
            //    var orderline = new OrderlineModel();
            //    orderline.PizzaId = pizza.Id;
            //    orderline.Pizza = pizza;
            //    orderline.Order = savedOrder;
            //    _orderlineCrud.CreateOrderline(orderline);

            //}



            //var result = _orderCrud.CreateOrder(newPizza);
            return Ok();
        }

    }
}
