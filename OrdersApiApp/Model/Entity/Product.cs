namespace OrdersApiApp.Model.Entity
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Number { get; set; }
        public ICollection<OrderProduct>? OrderProduct { get; set; }
        public Product(int id, string name, int number)
        {
            Id = id;
            Name = name;
            Number = number;
        }

        public override string ToString()
        {
            return $"{Id} - {Name}";
        }
    }
}
