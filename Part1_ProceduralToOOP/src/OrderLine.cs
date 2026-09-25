public class OrderLine
{
    public Product Product { get; }
    public int Quantity { get; }

    public OrderLine(Product product, int quantity)
    {
        Product = product;
        Quantity = quantity;
    }

    public double CalculateSubtotal()
    {
        return Product.Price * Quantity;
    }
}