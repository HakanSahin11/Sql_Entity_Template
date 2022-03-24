using PizzaShopApp.Models;

namespace PizzaShopApp.CRUD
{
    public class OrderlineCRUD
    {
        private readonly PizzaShopContext _db;
        public OrderlineCRUD(PizzaShopContext pizzaShopContext)
        {
            _db = pizzaShopContext;
        }


        public Task<List<OrderlineModel>> GetAllOrderlines() =>
            Task.Run(() => _db.Orderline.Where(x => true).ToList());

        public OrderlineModel GetOrderline(int id)
        {
            return _db.Orderline.FirstOrDefault(x => x.Id == id);
        }

        public bool CreateOrderline(OrderlineModel newOrderline)
        {
            try
            {
                if (newOrderline == null || GetOrderline(newOrderline.Id) != null)
                {
                    return false;
                }
                _db.Orderline.Add(newOrderline);
                _db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool UpdateOrderline(OrderlineModel updatedOrderline)
        {
            var savedOrder = _db.Orderline.FirstOrDefault(x => x.Id == updatedOrderline.Id);
            if (savedOrder != null)
            {
                savedOrder.Order = updatedOrderline.Order;
                savedOrder.Pizza = updatedOrderline.Pizza;
                savedOrder.OrderId = updatedOrderline.Id;
                savedOrder.PizzaId = updatedOrderline.PizzaId;
                _db.SaveChanges();
                return true;
            }
            return false;
        }

        public bool DeleteOrderline(int id)
        {
            var orderline = _db.Orderline.FirstOrDefault(x => x.Id == id);
            if (orderline != null)
            {
                _db.Remove(orderline);
                _db.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
