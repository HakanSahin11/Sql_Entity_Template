using PizzaShopApp.Models;

namespace PizzaShopApp.CRUD
{
    public class CustomerCRUD
    {
        private readonly PizzaShopContext _db;
        public CustomerCRUD(PizzaShopContext pizzaShopContext)
        {
            _db = pizzaShopContext;
        }

        public Task<List<CustomersModel>> GetAllCustomers() =>
            Task.Run(() => _db.Customer.Where(x => true).ToList());

        public CustomersModel GetCustomer(string username)
        {
            return _db.Customer.FirstOrDefault(x => x.Username == username);
        }

        public CustomersModel GetCustomerById(int Id)
        {
            return _db.Customer.FirstOrDefault(x => x.Id == Id);
        }

        public bool CreateCustomer(CustomersModel newCustomer)
        {
            try
            {
                if (newCustomer == null || GetCustomer(newCustomer.Username) != null)
                {
                    return false;
                }
                _db.Customer.Add(newCustomer);
                _db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool UpdateCustomer(CustomersModel updatedCustomer)
        {
            var user = _db.Customer.FirstOrDefault(x => x.Username == updatedCustomer.Username);
            if (user != null)
            {
                user.Username = updatedCustomer.Username;
                user.Firstname = updatedCustomer.Firstname;
                user.Lastname = updatedCustomer.Lastname;
                _db.SaveChanges();
                return true;
            }
            return false;
        }

        public bool DeleteCustomer(int id)
        {
            var user = _db.Customer.FirstOrDefault(x => x.Id == id);
            if (user != null)
            {
                _db.Remove(user);
                _db.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
