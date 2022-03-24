using PizzaShopApp.Models;

namespace PizzaShopApp.CRUD
{
    public class PizzaCrud
    {
        private readonly PizzaShopContext _db;
        public PizzaCrud(PizzaShopContext pizzaShopContext)
        {
            _db = pizzaShopContext;
        }


        public Task<List<PizzaModel>> GetAllPizzas() =>
            Task.Run(() => _db.pizza.Where(x => true).ToList());

        public PizzaModel GetPizza(string name)
        {
            return _db.pizza.FirstOrDefault(x => x.Pizza_Name == name);
        }

        public bool CreatePizza(PizzaModel newPizza)
        {
            try
            {
                if (newPizza == null || GetPizza(newPizza.Pizza_Name) != null)
                {
                    return false;
                }
                _db.pizza.Add(newPizza);
                _db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool UpdatePizza(PizzaModel updatedPizza)
        {
            var savedPizza = _db.pizza.FirstOrDefault(x => x.Id == updatedPizza.Id);
            if (savedPizza != null)
            {
                savedPizza.Pizza_Name = updatedPizza.Pizza_Name;
                savedPizza.Price = updatedPizza.Price;
                savedPizza.Ingredient_1 = updatedPizza.Ingredient_1;
                savedPizza.Ingredient_2 = updatedPizza.Ingredient_2;
                savedPizza.Ingredient_3 = updatedPizza.Ingredient_3;
                savedPizza.Ingredient_4 = updatedPizza.Ingredient_4;
                _db.SaveChanges();
                return true;
            }
            return false;
        }

        public bool DeletePizza(int id)
        {
            var pizza = _db.pizza.FirstOrDefault(x => x.Id == id);
            if (pizza != null)
            {
                _db.Remove(pizza);
                _db.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
