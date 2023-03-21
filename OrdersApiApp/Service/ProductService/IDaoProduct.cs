using OrdersApiApp.Model.Entity;

namespace OrdersApiApp.Service.ProductService
{
    // DAO (data-access-object) интерфейс для работы с клиентом
    public interface IDaoProduct
    {
        // вариант синхронный
        //List<Client> GetAllClients();
        //Client GetClientById(int id);
        //Client AddClient(Client client);
        //Client UpdateClient(Client client);
        //bool DeleteClient(int id);

        Task<List<Product>> GetAllProducts();
        Task<Product> GetProductById(int id);
        Task<Product> AddProduct(Product product);
        Task<Product> UpdateProduct(Product product);
        Task<bool> DeleteProduct(int id);
    }
}
