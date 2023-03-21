using OrdersApiApp.Model.Entity;

namespace OrdersApiApp.Service.ProductService
{
    // Имплементация-заглушка 
    public class PlugDaoProduct : IDaoProduct
    {
        public static List<Product> products= new List<Product>(); // иммитация хранилища

        public Task<Product> AddProduct(Product product)
        {
            product.Id = products.Count;
            products.Add(product);
            return Task.Run(() => product);  // костыль для асинхронности
        }

        public Task<bool> DeleteProduct(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Product>> GetAllProducts()
        {
            return Task.Run(() => products);
        }

        public Task<Product> GetProductById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Product> UpdateProduct(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
