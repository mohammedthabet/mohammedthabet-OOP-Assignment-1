public class Order
{
    public int Id { get; }
    public string Date { get; }
    public Customer Customer { get; }
    public bool IsPaid { get; private set; }

    private readonly List<OrderLine> _lines = new();
    public IReadOnlyList<OrderLine> Lines => _lines;

    public Order(int id, string date, Customer customer)
    {
        Id = id;
        Date = date;
        Customer = customer;
        IsPaid = false;
    }

    public void AddLine(Product product, int quantity)
    {
        if (IsPaid)
        {
            throw new InvalidOperationException(
                "Cannot add lines to a paid order.");
        }

        product.ReduceStock(quantity);

        var line = new OrderLine(product, quantity);

        _lines.Add(line);
    }

    public void MarkAsPaid()
    {
        if (_lines.Count == 0)
        {
            throw new InvalidOperationException(
                "Cannot pay an empty order.");
        }

        IsPaid = true;
    }

    public double CalculateTotal()
    {
        double total = 0;

        foreach (var line in _lines)
        {
            total += line.CalculateSubtotal();
        }

        if (Customer.IsVip)
        {
            total *= 0.90;
        }

        return total;
    }
}