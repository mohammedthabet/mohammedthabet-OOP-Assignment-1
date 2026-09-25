public class OrderBuilder
{
    private DateTime _orderDate;
    private string? _paymentMethod;
    private string? _currency;

    private double _subTotal;
    private double _discountAmount;
    private double _taxAmount;
    private double _totalAmount;


    public OrderBuilder WithOrderDate(DateTime orderDate)
    {
        _orderDate = orderDate;
        return this;
    }

    public OrderBuilder WithPaymentMethod(string paymentMethod)
    {
        _paymentMethod = paymentMethod;
        return this;
    }

    public OrderBuilder WithCurrency(string currency)
    {
        _currency = currency;
        return this;
    }

    public OrderBuilder WithSubTotal(double subTotal)
    {
        _subTotal = subTotal;
        return this;
    }

    public OrderBuilder WithDiscount(double discountAmount)
    {
        _discountAmount = discountAmount;
        return this;
    }

    public OrderBuilder WithTax(double taxAmount)
    {
        _taxAmount = taxAmount;
        return this;
    }

    public OrderBuilder WithTotal(double totalAmount)
    {
        _totalAmount = totalAmount;
        return this;
    }


    public OrderInfo Build()
    {
        if (_orderDate == default)
        {
            throw new InvalidOperationException(
                "Order date is required.");
        }

        if (string.IsNullOrWhiteSpace(_paymentMethod))
        {
            throw new InvalidOperationException(
                "Payment method is required.");
        }

        if (string.IsNullOrWhiteSpace(_currency))
        {
            throw new InvalidOperationException(
                "Currency is required.");
        }

        if (_subTotal < 0 ||
            _discountAmount < 0 ||
            _taxAmount < 0 ||
            _totalAmount < 0)
        {
            throw new InvalidOperationException(
                "Amounts cannot be negative.");
        }

        return new OrderInfo(
            _orderDate,
            _paymentMethod,
            _currency,
            _subTotal,
            _discountAmount,
            _taxAmount,
            _totalAmount);
    }
}