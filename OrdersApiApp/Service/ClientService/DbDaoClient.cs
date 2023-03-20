using Microsoft.EntityFrameworkCore;
using OrdersApiApp.Model;
using OrdersApiApp.Model.Entity;

namespace OrdersApiApp.Service.ClientService
{
    // имплементация dao, работающая с БД
    public class DbDaoClient : IDaoClient
    {
        private readonly ApplicationDbContext db;   // entity manager для работы с данными

        public DbDaoClient(ApplicationDbContext db)
        {
            // db прилетает через инъекцию зависимостей
            this.db = db;
        }

        // добавление нового клиента
        public async Task<Client> AddClient(Client client)
        {
            await db.Clients.AddAsync(client);
            db.SaveChanges();
            return client;

        }

        public async Task<bool> DeleteClient(int id)
        {
            await db.Clients.Where(c => c.Id == id).ExecuteDeleteAsync();
            db.SaveChanges() ;
            return true;
        }

        // получение всех клиентов
        public async Task<List<Client>> GetAllClients()
        {
            return await db.Clients.ToListAsync();
        }

        public async Task<Client> GetClientById(int id)
        {
            return await db.Clients.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Client> UpdateClient(Client client)
        {
            var entity = await db.Clients.FirstOrDefaultAsync(c => c.Id == client.Id);
            if (entity != null)
            {
                entity.Name = client.Name;
                db.SaveChanges();
            }
            return client;
        }
    }
}
