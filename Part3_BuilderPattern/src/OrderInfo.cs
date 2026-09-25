public class OrderInfo
{
    public DateTime OrderDate { get; }
    public string PaymentMethod { get; }
    public string Currency { get; }

    public double SubTotal { get; }
    public double DiscountAmount { get; }
    public double TaxAmount { get; }
    public double TotalAmount { get; }

    public OrderInfo(
        DateTime orderDate,
        string paymentMethod,
        string currency,
        double subTotal,
        double discountAmount,
        double taxAmount,
        double totalAmount)
    {
        OrderDate = orderDate;
        PaymentMethod = paymentMethod;
        Currency = currency;

        SubTotal = subTotal;
        DiscountAmount = discountAmount;
        TaxAmount = taxAmount;
        TotalAmount = totalAmount;
    }
}