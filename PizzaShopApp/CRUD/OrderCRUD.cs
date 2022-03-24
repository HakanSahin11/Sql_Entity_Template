using Microsoft.EntityFrameworkCore;
using PizzaShopApp.Models;
using System.Linq;

namespace PizzaShopApp.CRUD
{
    public class OrderCRUD
    {
        private readonly PizzaShopContext _db;
        public OrderCRUD(PizzaShopContext pizzaShopContext)
        {
            _db = pizzaShopContext;
        }

        public Task<List<OrderModel>> GetAllOrders() =>
            Task.Run(() => _db.Order.Where(x => true).ToList());

        public OrderModel GetOrder(int id)
        {
            return _db.Order.FirstOrDefault(x => x.Id == id);
        }

        public OrderModel GetNewest()
        {
            return _db.Order.LastOrDefault();
        }

        public OrderModel? CreateOrder(OrderModel newOrder)
        {
            try
            {
                if (newOrder == null || GetOrder(newOrder.Id) != null)
                {
                    return null;
                }
                _db.Order.Add(newOrder);
                _db.SaveChanges();
                return newOrder;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public bool UpdateOrder(OrderModel updatedOrder)
        {
            var savedOrder = _db.Order.FirstOrDefault(x => x.Id == updatedOrder.Id);
            if (savedOrder != null)
            {
                savedOrder.Customer = updatedOrder.Customer;
                savedOrder.Time_Of_Order = updatedOrder.Time_Of_Order;
                savedOrder.Total_Price = updatedOrder.Total_Price;
                _db.SaveChanges();
                return true;
            }
            return false;
        }

        public bool DeleteOrder(int id)
        {
            var order = _db.Order.FirstOrDefault(x => x.Id == id);
            if (order != null)
            {
                _db.Remove(order);
                _db.SaveChanges();
                return true;
            }
            return false;
        }

        public List<OrderModel> GetAllRelations(int orderId)
        {
            if (orderId == 0)
            {
                return _db.Order.Include(z => z.Customer).Include(x => x.orderlines).ThenInclude(y => y.Pizza).ToList();
            }
            return _db.Order.Include(z => z.Customer).Where(a => a.Id == orderId).Include(x => x.orderlines).ThenInclude(y => y.Pizza).ToList();
        }

        public List<FakturaModel> GetFaktura(int orderId)
        {

            var query_order_customr = _db.Order.Include(z => z.Customer);
            IQueryable<OrderModel> query_ordermodel;
            if (orderId != 0)
                query_ordermodel = query_order_customr.Where(a => a.Id == orderId);
            else
                query_ordermodel = query_order_customr;

                var list = query_ordermodel.Include(x => x.orderlines).ThenInclude(y => y.Pizza).Select(p =>
                   new FakturaModel
                   (
                       p.Id,
                       p.Customer.Username,
                       p.Time_Of_Order,
                       p.Total_Price,
                       (List<PizzaModel>)p.orderlines.Select(o => o.Pizza)
                   )).ToList();
                return list;
            #region Old Linq Method
            /*
            var query =(
                from order in _db.Orders
                join customer in _db.Customers on order.Id equals customer.Id 
                join orderline in _db.Orderline on order.Id equals orderline.OrderId into grouping
                from orderlineGrouped in grouping.DefaultIfEmpty()
                join pizzas in _db.pizzas on orderlineGrouped.PizzaId equals pizzas.Id
                select new
                {
                    customerId = customer.Id,
                    username = customer.Username,
                    firstname = customer.Firstname,
                    lastname = customer.Lastname,
                    totalPrice = order.Total_Price,
                    datetime = order.Time_Of_Order,

                    orderId = orderlineGrouped.OrderId,

                    pizzaName = pizzas.Pizza_Name,
                    pizzaPrice = pizzas.Price,
                    ingredient1 = pizzas.Ingredient_1,
                    ingredient2 = pizzas.Ingredient_2,
                    ingredient3 = pizzas.Ingredient_3,
                    ingredient4 = pizzas.Ingredient_4
                }).ToList();
            */

            #endregion
        }
    }
}
