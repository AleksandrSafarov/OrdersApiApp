using OrdersApiApp.Model;
using OrdersApiApp.Model.Entity;
using OrdersApiApp.Service.ClientService;
using OrdersApiApp.Service.OrderService;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>();
builder.Services.AddTransient<IDaoClient, DbDaoClient>();
builder.Services.AddTransient<IDaoOrder, DbDaoOrder>();

var app = builder.Build();


app.MapGet("/", () => "Hello World!");

///Client

app.MapGet("/client/all", async (HttpContext context, IDaoClient dao) =>
{
    return await dao.GetAllClients();
});

app.MapPost("/client/add", async (HttpContext context, Client client, IDaoClient dao) =>
{
    return await dao.AddClient(client);
});

app.MapPost("/client/update", async (HttpContext context, Client client, IDaoClient dao) =>
{
    return await dao.UpdateClient(client);
});

app.MapGet("/client/delete/{id}", async (HttpContext context, string id, IDaoClient dao) =>
{
    int id1 = int.Parse(id);
    return await dao.DeleteClient(id1);
});

app.MapGet("/client/get/{id}", async (HttpContext context, string id, IDaoClient dao) =>
 {
     int id1 = int.Parse(id);
     return await dao.GetClientById(id1);
 });


///Order

app.MapGet("/order/all", async (HttpContext context, IDaoOrder dao) =>
{
    return await dao.GetAllOrders();
});

app.MapPost("/order/add", async (HttpContext context, Order order, IDaoOrder dao) =>
{
    return await dao.AddOrder(order);
});

app.MapPost("/order/update", async (HttpContext context, Order order, IDaoOrder dao) =>
{
    return await dao.UpdateOrder(order);
});

app.MapGet("/order/delete/{id}", async (HttpContext context, string id, IDaoOrder dao) =>
{
    int id1 = int.Parse(id);
    return await dao.DeleteOrder(id1);
});

app.MapGet("/order/get/{id}", async (HttpContext context, string id, IDaoOrder dao) =>
{
    int id1 = int.Parse(id);
    return await dao.GetOrderById(id1);
});

app.Run();
