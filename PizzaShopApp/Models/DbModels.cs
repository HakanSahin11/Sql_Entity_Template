using Microsoft.EntityFrameworkCore;
using System;

namespace PizzaShopApp.Models
{
    public class PizzaShopContext : DbContext
    {
        public DbSet<CustomersModel> Customer { get; set; }
        public DbSet<OrderModel> Order { get; set; }
        public DbSet<OrderlineModel> Orderline { get; set; }
        public DbSet<PizzaModel> pizza { get; set; }

        public string DbPath { get; }
        public PizzaShopContext(DbContextOptions<PizzaShopContext> options)
            : base(options)
        {
        }
    }
    public class CustomersModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public List<OrderModel> Order {get;set;}
    }
    public class OrderModel
    {
        public int Total_Price { get; set; }
        public DateTime Time_Of_Order { get; set; }
        public int Id { get; set; }
        public int CustomerId { get; set; }

        public List<OrderlineModel> orderlines { get; set; } 

        public CustomersModel Customer { get; set; }
    }
    public class OrderlineModel
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public OrderModel Order { get; set; }
        public int PizzaId { get; set; }
        public PizzaModel Pizza { get; set; }
    }
    public class PizzaModel
    {
        public int Id { get; set; }
        public string Pizza_Name { get; set; }
        public string Ingredient_1 { get; set; }
        public string Ingredient_2 { get; set; }
        public string Ingredient_3 { get; set; }
        public string Ingredient_4 { get; set; }
        public int Price { get; set; }
    }

    public class GetOrderModel
    {
        public List<string> Pizza_Name { get; set; }
        public string Username { get; set; }
    }
    
    public class FakturaModel
    {
        public FakturaModel(int id, string username, DateTime time_of_Order, int total_Price, List<PizzaModel> pizzas)
        {
            Id = id;
            Username = username;
            Time_of_Order = time_of_Order;
            Total_Price = total_Price;
            Pizzas = pizzas;
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public DateTime Time_of_Order { get; set; }
        public int Total_Price { get; set; }
        public List<PizzaModel> Pizzas { get; set; }
    }
}
