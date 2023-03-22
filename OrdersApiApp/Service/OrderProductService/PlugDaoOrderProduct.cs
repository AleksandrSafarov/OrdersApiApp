using OrdersApiApp.Model.Entity;

namespace OrdersApiApp.Service.OrderProductService
{
    // Имплементация-заглушка 
    public class PlugDaoOrderProduct : IDaoOrderProduct
    {
        public static List<OrderProduct> orderProducts= new List<OrderProduct>(); // иммитация хранилища

        public Task<OrderProduct> AddOrderProduct(OrderProduct ordprod)
        {
            ordprod.Id = orderProducts.Count;
            orderProducts.Add(ordprod);
            return Task.Run(() => ordprod);  // костыль для асинхронности
        }

        public Task<bool> DeleteOrderProduct(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<OrderProduct>> GetAllOrderProducts()
        {
            return Task.Run(() => orderProducts);
        }

        public Task<OrderProduct> GetOrderProductById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<OrderProduct> UpdateOrderProduct(OrderProduct ordprod)
        {
            throw new NotImplementedException();
        }
    }
}
