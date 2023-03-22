using OrdersApiApp.Model.Entity;

namespace OrdersApiApp.Service.OrderProductService
{
    // DAO (data-access-object) интерфейс для работы с клиентом
    public interface IDaoOrderProduct
    {
        // вариант синхронный
        //List<Client> GetAllClients();
        //Client GetClientById(int id);
        //Client AddClient(Client client);
        //Client UpdateClient(Client client);
        //bool DeleteClient(int id);

        Task<List<OrderProduct>> GetAllOrderProducts();
        Task<OrderProduct> GetOrderProductById(int id);
        Task<OrderProduct> AddOrderProduct(OrderProduct ordprod);
        Task<OrderProduct> UpdateOrderProduct(OrderProduct ordprod);
        Task<bool> DeleteOrderProduct(int id);
    }
}
