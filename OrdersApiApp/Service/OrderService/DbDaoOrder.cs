using Microsoft.EntityFrameworkCore;
using OrdersApiApp.Model;
using OrdersApiApp.Model.Entity;

namespace OrdersApiApp.Service.OrderService
{
    // имплементация dao, работающая с БД
    public class DbDaoOrder : IDaoOrder
    {
        private readonly ApplicationDbContext db;   // entity manager для работы с данными

        public DbDaoOrder(ApplicationDbContext db)
        {
            // db прилетает через инъекцию зависимостей
            this.db = db;
        }

        // добавление нового клиента
        public async Task<Order> AddOrder(Order order)
        {
            await db.Orders.AddAsync(order);
            db.SaveChanges();
            return order;

        }

        public async Task<bool> DeleteOrder(int id)
        {
            await db.Orders.Where(c => c.Id == id).ExecuteDeleteAsync();
            db.SaveChanges() ;
            return true;
        }

        // получение всех клиентов
        public async Task<List<Order>> GetAllOrders()
        {
            return await db.Orders.ToListAsync();
        }

        public async Task<Order> GetOrderById(int id)
        {
            return await db.Orders.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Order> UpdateOrder(Order order)
        {
            var entity = await db.Orders.FirstOrDefaultAsync(o => o.Id == order.Id);
            if (entity != null)
            {
                entity.Description = order.Description;
                db.SaveChanges();
            }
            return order;
        }
    }
}
