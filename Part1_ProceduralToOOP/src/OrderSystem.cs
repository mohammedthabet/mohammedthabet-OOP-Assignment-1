public class OrderSystem
{
    private readonly List<Customer> _customers = new();
    private readonly List<Product> _products = new();
    private readonly List<Order> _orders = new();

    public IReadOnlyList<Customer> Customers => _customers;
    public IReadOnlyList<Product> Products => _products;
    public IReadOnlyList<Order> Orders => _orders;

    public void AddCustomer(Customer customer)
    {
        _customers.Add(customer);
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public Customer? FindCustomer(int id)
    {
        foreach (var customer in _customers)
        {
            if (customer.Id == id)
            {
                return customer;
            }
        }

        return null;
    }

    public Product? FindProduct(int id)
    {
        foreach (var product in _products)
        {
            if (product.Id == id)
            {
                return product;
            }
        }

        return null;
    }

    public Order? FindOrder(int id)
    {
        foreach (var order in _orders)
        {
            if (order.Id == id)
            {
                return order;
            }
        }

        return null;
    }

    public Order CreateOrder(int orderId, int customerId, string date)
    {
        if (FindOrder(orderId) != null)
        {
            throw new InvalidOperationException(
                $"Order id {orderId} already exists.");
        }

        Customer? customer = FindCustomer(customerId);

        if (customer == null)
        {
            throw new InvalidOperationException(
                $"Customer id {customerId} not found.");
        }

        var order = new Order(orderId, date, customer);

        _orders.Add(order);

        return order;
    }

    public double CalculatePaidSalesTotal()
    {
        double total = 0;

        foreach (var order in _orders)
        {
            if (order.IsPaid)
            {
                total += order.CalculateTotal();
            }
        }

        return total;
    }
}