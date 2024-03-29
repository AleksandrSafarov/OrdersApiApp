using OrdersApiApp.Model;
using OrdersApiApp.Model.Entity;
using OrdersApiApp.Service.ClientService;
using OrdersApiApp.Service.OrderService;
using OrdersApiApp.Service.ProductService;
using OrdersApiApp.Service.OrderProductService;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>();
builder.Services.AddTransient<IDaoClient, DbDaoClient>();
builder.Services.AddTransient<IDaoOrder, DbDaoOrder>();
builder.Services.AddTransient<IDaoProduct, DbDaoProduct>();
builder.Services.AddTransient<IDaoOrderProduct, DbDaoOrderProduct>();

var app = builder.Build();


app.MapGet("/", () => "Hello! It`s OrderApi!");

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


///Product

app.MapGet("/product/all", async (HttpContext context, IDaoProduct dao) =>
{
    return await dao.GetAllProducts();
});

app.MapPost("/product/add", async (HttpContext context, Product product, IDaoProduct dao) =>
{
    return await dao.AddProduct(product);
});

app.MapPost("/product/update", async (HttpContext context, Product product, IDaoProduct dao) =>
{
    return await dao.UpdateProduct(product);
});

app.MapGet("/product/delete/{id}", async (HttpContext context, string id, IDaoProduct dao) =>
{
    int id1 = int.Parse(id);
    return await dao.DeleteProduct(id1);
});

app.MapGet("/product/get/{id}", async (HttpContext context, string id, IDaoProduct dao) =>
{
    int id1 = int.Parse(id);
    return await dao.GetProductById(id1);
});


///OrderProduct

app.MapGet("/orderProduct/all", async (HttpContext context, IDaoOrderProduct dao) =>
{
    return await dao.GetAllOrderProducts();
});

app.MapPost("/orderProduct/add", async (HttpContext context, OrderProduct ordprod, IDaoOrderProduct dao) =>
{
    return await dao.AddOrderProduct(ordprod);
});

app.MapPost("/orderProduct/update", async (HttpContext context, OrderProduct ordprod, IDaoOrderProduct dao) =>
{
    return await dao.UpdateOrderProduct(ordprod);
});

app.MapGet("/orderProduct/delete/{id}", async (HttpContext context, string id, IDaoOrderProduct dao) =>
{
    int id1 = int.Parse(id);
    return await dao.DeleteOrderProduct(id1);
});

app.MapGet("/orderProduct/get/{id}", async (HttpContext context, string id, IDaoOrderProduct dao) =>
{
    int id1 = int.Parse(id);
    return await dao.GetOrderProductById(id1);
});

app.Run();
