using Microsoft.EntityFrameworkCore;
using OrdersApiApp.Model;
using OrdersApiApp.Model.Entity;

namespace OrdersApiApp.Service.ProductService
{
    // имплементация dao, работающая с БД
    public class DbDaoProduct : IDaoProduct
    {
        private readonly ApplicationDbContext db;   // entity manager для работы с данными

        public DbDaoProduct(ApplicationDbContext db)
        {
            // db прилетает через инъекцию зависимостей
            this.db = db;
        }

        // добавление нового клиента
        public async Task<Product> AddProduct(Product product)
        {
            await db.Products.AddAsync(product);
            db.SaveChanges();
            return product;

        }

        public async Task<bool> DeleteProduct(int id)
        {
            await db.Products.Where(c => c.Id == id).ExecuteDeleteAsync();
            db.SaveChanges() ;
            return true;
        }

        // получение всех клиентов
        public async Task<List<Product>> GetAllProducts()
        {
            return await db.Products.ToListAsync();
        }

        public async Task<Product> GetProductById(int id)
        {
            return await db.Products.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Product> UpdateProduct(Product product)
        {
            var entity = await db.Products.FirstOrDefaultAsync(p => p.Id == product.Id);
            if (entity != null)
            {
                entity.Name = product.Name;
                entity.Number = product.Number;
                db.SaveChanges();
            }
            return product;
        }
    }
}
