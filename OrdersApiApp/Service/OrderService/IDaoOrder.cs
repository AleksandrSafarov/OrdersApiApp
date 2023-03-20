using OrdersApiApp.Model.Entity;

namespace OrdersApiApp.Service.OrderService
{
    // DAO (data-access-object) интерфейс для работы с клиентом
    public interface IDaoOrder
    {
        // вариант синхронный
        //List<Client> GetAllClients();
        //Client GetClientById(int id);
        //Client AddClient(Client client);
        //Client UpdateClient(Client client);
        //bool DeleteClient(int id);

        Task<List<Order>> GetAllOrders();
        Task<Order> GetOrderById(int id);
        Task<Order> AddOrder(Order order);
        Task<Order> UpdateOrder(Order order);
        Task<bool> DeleteOrder(int id);
    }
}
