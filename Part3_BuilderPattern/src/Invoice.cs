public class Invoice
{
    public int InvoiceId { get; }

    public string CustomerName { get; }
    public string CustomerEmail { get; }
    public string? CustomerPhone { get; }

    public Address BillingAddress { get; }
    public Address ShippingAddress { get; }

    public OrderInfo Order { get; }


    public Invoice(
        int invoiceId,
        string customerName,
        string customerEmail,
        string? customerPhone,
        Address billingAddress,
        Address shippingAddress,
        OrderInfo order)
    {
        InvoiceId = invoiceId;

        CustomerName = customerName;
        CustomerEmail = customerEmail;
        CustomerPhone = customerPhone;

        BillingAddress = billingAddress;
        ShippingAddress = shippingAddress;

        Order = order;
    }
}