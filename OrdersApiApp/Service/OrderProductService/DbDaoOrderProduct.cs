using Microsoft.EntityFrameworkCore;
using OrdersApiApp.Model;
using OrdersApiApp.Model.Entity;

namespace OrdersApiApp.Service.OrderProductService
{
    // имплементация dao, работающая с БД
    public class DbDaoOrderProduct : IDaoOrderProduct
    {
        private readonly ApplicationDbContext db;   // entity manager для работы с данными

        public DbDaoOrderProduct(ApplicationDbContext db)
        {
            // db прилетает через инъекцию зависимостей
            this.db = db;
        }

        // добавление нового клиента
        public async Task<OrderProduct> AddOrderProduct(OrderProduct ordprod)
        {
            await db.OrderProducts.AddAsync(ordprod);
            db.SaveChanges();
            return ordprod;

        }

        public async Task<bool> DeleteOrderProduct(int id)
        {
            await db.OrderProducts.Where(op => op.Id == id).ExecuteDeleteAsync();
            db.SaveChanges() ;
            return true;
        }

        // получение всех клиентов
        public async Task<List<OrderProduct>> GetAllOrderProducts()
        {
            return await db.OrderProducts.ToListAsync();
        }

        public async Task<OrderProduct> GetOrderProductById(int id)
        {
            return await db.OrderProducts.FirstOrDefaultAsync(op => op.Id == id);
        }

        public async Task<OrderProduct> UpdateOrderProduct(OrderProduct ordprod)
        {
            var entity = await db.OrderProducts.FirstOrDefaultAsync(op => op.Id == ordprod.Id);
            if (entity != null)
            {
                entity.OrderId = ordprod.OrderId;
                entity.ProductId = ordprod.ProductId;
                entity.Count = ordprod.Count;
                db.SaveChanges();
            }
            return ordprod;
        }
    }
}
