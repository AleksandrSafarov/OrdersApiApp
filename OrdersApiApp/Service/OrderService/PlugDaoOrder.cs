using OrdersApiApp.Model.Entity;

namespace OrdersApiApp.Service.OrderService
{
    // Имплементация-заглушка 
    public class PlugDaoOrder : IDaoOrder
    {
        public static List<Order> orders= new List<Order>(); // иммитация хранилища

        public Task<Order> AddOrder(Order order)
        {
            order.Id = orders.Count;
            orders.Add(order);
            return Task.Run(() => order);  // костыль для асинхронности
        }

        public Task<bool> DeleteOrder(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Order>> GetAllOrders()
        {
            return Task.Run(() => orders);
        }

        public Task<Order> GetOrderById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Order> UpdateOrder(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
