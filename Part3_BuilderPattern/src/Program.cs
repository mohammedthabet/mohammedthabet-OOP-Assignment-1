// ======================================================
// Build Billing Address
// ======================================================

var billingAddress = new AddressBuilder()
    .WithStreet("10 Tahrir Street")
    .WithCity("Cairo")
    .WithState("Cairo")
    .WithZipCode("11511")
    .WithCountry("Egypt")
    .Build();


// ======================================================
// Build Shipping Address
// ======================================================

var shippingAddress = new AddressBuilder()
    .WithStreet("25 Corniche Road")
    .WithCity("Alexandria")
    .WithState("Alexandria")
    .WithZipCode("21500")
    .WithCountry("Egypt")
    .Build();


// ======================================================
// Build Order Information
// ======================================================

var order = new OrderBuilder()
    .WithOrderDate(new DateTime(2026, 9, 25))
    .WithPaymentMethod("Credit Card")
    .WithCurrency("EGP")
    .WithSubTotal(5000)
    .WithDiscount(500)
    .WithTax(630)
    .WithTotal(5130)
    .Build();


// ======================================================
// Compose the Final Invoice
// ======================================================

var invoice = new InvoiceBuilder()
    .WithInvoiceId(1001)
    .WithCustomerName("Mona Ali")
    .WithCustomerEmail("mona@example.com")
    .WithCustomerPhone("01012345678")
    .WithBillingAddress(billingAddress)
    .WithShippingAddress(shippingAddress)
    .WithOrder(order)
    .Build();


// ======================================================
// Display Result
// ======================================================

Console.WriteLine("=== INVOICE ===");

Console.WriteLine(
    $"Invoice: #{invoice.InvoiceId}");

Console.WriteLine(
    $"Customer: {invoice.CustomerName}");

Console.WriteLine(
    $"Email: {invoice.CustomerEmail}");

Console.WriteLine(
    $"Billing: {invoice.BillingAddress.City}, " +
    $"{invoice.BillingAddress.Country}");

Console.WriteLine(
    $"Shipping: {invoice.ShippingAddress.City}, " +
    $"{invoice.ShippingAddress.Country}");

Console.WriteLine(
    $"Payment: {invoice.Order.PaymentMethod}");

Console.WriteLine(
    $"Currency: {invoice.Order.Currency}");

Console.WriteLine(
    $"Total: {invoice.Order.TotalAmount:F2}");
    
Console.WriteLine();
