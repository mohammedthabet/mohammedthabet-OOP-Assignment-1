public class Product
{
    public int Id { get; }
    public string Name { get; }
    public double Price { get; }
    public int Stock { get; private set; }

    public Product(int id, string name, double price, int stock)
    {
        Id = id;
        Name = name;
        Price = price;
        Stock = stock;
    }

    public void ReduceStock(int quantity)
    {
        if (quantity <= 0)
        {
            throw new ArgumentException("Quantity must be greater than zero.");
        }

        if (quantity > Stock)
        {
            throw new InvalidOperationException("Not enough stock.");
        }

        Stock -= quantity;
    }
}