// ============================================================
// Part 1 - Procedural to OOP
// Program.cs
// ============================================================


// ------------------------------------------------------------
// 1. CREATE THE ORDER SYSTEM
// ------------------------------------------------------------

var system = new OrderSystem();


// ------------------------------------------------------------
// 2. SEED CUSTOMERS
// ------------------------------------------------------------

var mona = new Customer(
    1,
    "Mona Ali",
    "mona@example.com",
    "Cairo",
    true);

var omar = new Customer(
    2,
    "Omar Hassan",
    "omar@example.com",
    "Alexandria",
    false);

var sara = new Customer(
    3,
    "Sara Nabil",
    "sara@example.com",
    "Giza",
    false);

system.AddCustomer(mona);
system.AddCustomer(omar);
system.AddCustomer(sara);


// ------------------------------------------------------------
// 3. SEED PRODUCTS
// ------------------------------------------------------------

var usbCable = new Product(
    101,
    "USB Cable",
    50.00,
    100);

var wirelessMouse = new Product(
    102,
    "Wireless Mouse",
    250.00,
    40);

var mechanicalKeyboard = new Product(
    103,
    "Mechanical Keyboard",
    1200.00,
    15);

var laptopStand = new Product(
    104,
    "Laptop Stand",
    400.00,
    25);

system.AddProduct(usbCable);
system.AddProduct(wirelessMouse);
system.AddProduct(mechanicalKeyboard);
system.AddProduct(laptopStand);


// ------------------------------------------------------------
// 4. SEED DEMO ORDERS
// ------------------------------------------------------------

// Order #1001 - Mona
var order1001 = system.CreateOrder(
    1001,
    1,
    "2026-09-15");

order1001.AddLine(usbCable, 2);
order1001.AddLine(wirelessMouse, 1);
order1001.MarkAsPaid();


// Order #1002 - Omar
var order1002 = system.CreateOrder(
    1002,
    2,
    "2026-09-15");

order1002.AddLine(mechanicalKeyboard, 1);
order1002.AddLine(laptopStand, 1);


// Order #1003 - Sara
var order1003 = system.CreateOrder(
    1003,
    3,
    "2026-09-16");

order1003.AddLine(usbCable, 5);
order1003.MarkAsPaid();


// ------------------------------------------------------------
// 5. SHOW DEMO
// ------------------------------------------------------------

Console.WriteLine("Procedural Order System - OOP Version");
Console.WriteLine("Seed sample data, show a demo, then open the menu.");

PrintCustomers(system);
Console.WriteLine();

PrintProducts(system);
Console.WriteLine();

PrintAllOrders(system);

Console.WriteLine();
Console.WriteLine(
    $"Paid sales total after demo: {system.CalculatePaidSalesTotal():F2}");


// ------------------------------------------------------------
// 6. MAIN MENU
// ------------------------------------------------------------

while (true)
{
    Console.WriteLine();
    Console.WriteLine("---------- MENU ----------");
    Console.WriteLine("1) Print customers");
    Console.WriteLine("2) Print products");
    Console.WriteLine("3) Print all orders");
    Console.WriteLine("4) Print one order by id");
    Console.WriteLine("5) Create order");
    Console.WriteLine("6) Add line to order");
    Console.WriteLine("7) Mark order paid");
    Console.WriteLine("8) Show paid sales total");
    Console.WriteLine("0) Exit");
    Console.Write("Choice: ");

    string? choice = Console.ReadLine();

    switch (choice)
    {
        // ----------------------------------------------------
        // 0. EXIT
        // ----------------------------------------------------

        case "0":
            return;


        // ----------------------------------------------------
        // 1. PRINT CUSTOMERS
        // ----------------------------------------------------

        case "1":
            PrintCustomers(system);
            break;


        // ----------------------------------------------------
        // 2. PRINT PRODUCTS
        // ----------------------------------------------------

        case "2":
            PrintProducts(system);
            break;


        // ----------------------------------------------------
        // 3. PRINT ALL ORDERS
        // ----------------------------------------------------

        case "3":
            PrintAllOrders(system);
            break;


        // ----------------------------------------------------
        // 4. PRINT ONE ORDER
        // ----------------------------------------------------

        case "4":
        {
            Console.Write("Order id: ");

            if (!int.TryParse(Console.ReadLine(), out int orderId))
            {
                Console.WriteLine("ERROR: invalid order id.");
                break;
            }

            Order? order = system.FindOrder(orderId);

            if (order == null)
            {
                Console.WriteLine(
                    $"ERROR: order id {orderId} not found.");
                break;
            }

            PrintOrder(order);
            break;
        }


        // ----------------------------------------------------
        // 5. CREATE ORDER
        // ----------------------------------------------------

        case "5":
        {
            Console.Write("Order id: ");

            if (!int.TryParse(Console.ReadLine(), out int orderId))
            {
                Console.WriteLine("ERROR: invalid order id.");
                break;
            }

            Console.Write("Customer id: ");

            if (!int.TryParse(Console.ReadLine(), out int customerId))
            {
                Console.WriteLine("ERROR: invalid customer id.");
                break;
            }

            Console.Write("Date: ");
            string date = Console.ReadLine() ?? "";

            try
            {
                system.CreateOrder(
                    orderId,
                    customerId,
                    date);

                Console.WriteLine(
                    $"Order #{orderId} created successfully.");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"ERROR: {ex.Message}");
            }

            break;
        }


        // ----------------------------------------------------
        // 6. ADD LINE TO ORDER
        // ----------------------------------------------------

        case "6":
        {
            Console.Write("Order id: ");

            if (!int.TryParse(Console.ReadLine(), out int orderId))
            {
                Console.WriteLine("ERROR: invalid order id.");
                break;
            }

            Order? order = system.FindOrder(orderId);

            if (order == null)
            {
                Console.WriteLine(
                    $"ERROR: order id {orderId} not found.");
                break;
            }

            Console.Write("Product id: ");

            if (!int.TryParse(Console.ReadLine(), out int productId))
            {
                Console.WriteLine("ERROR: invalid product id.");
                break;
            }

            Product? product = system.FindProduct(productId);

            if (product == null)
            {
                Console.WriteLine(
                    $"ERROR: product id {productId} not found.");
                break;
            }

            Console.Write("Quantity: ");

            if (!int.TryParse(Console.ReadLine(), out int quantity))
            {
                Console.WriteLine("ERROR: invalid quantity.");
                break;
            }

            try
            {
                order.AddLine(product, quantity);

                Console.WriteLine(
                    "Line added successfully.");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"ERROR: {ex.Message}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"ERROR: {ex.Message}");
            }

            break;
        }


        // ----------------------------------------------------
        // 7. MARK ORDER PAID
        // ----------------------------------------------------

        case "7":
        {
            Console.Write("Order id: ");

            if (!int.TryParse(Console.ReadLine(), out int orderId))
            {
                Console.WriteLine("ERROR: invalid order id.");
                break;
            }

            Order? order = system.FindOrder(orderId);

            if (order == null)
            {
                Console.WriteLine(
                    $"ERROR: order id {orderId} not found.");
                break;
            }

            try
            {
                order.MarkAsPaid();

                Console.WriteLine(
                    $"Order #{orderId} marked as paid.");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"ERROR: {ex.Message}");
            }

            break;
        }


        // ----------------------------------------------------
        // 8. SHOW PAID SALES TOTAL
        // ----------------------------------------------------

        case "8":
            Console.WriteLine(
                $"Paid sales total: {system.CalculatePaidSalesTotal():F2}");
            break;


        // ----------------------------------------------------
        // INVALID MENU CHOICE
        // ----------------------------------------------------

        default:
            Console.WriteLine("ERROR: invalid choice.");
            break;
    }
}


// ============================================================
// HELPER FUNCTIONS
// ============================================================


// ------------------------------------------------------------
// PRINT CUSTOMERS
// ------------------------------------------------------------

static void PrintCustomers(OrderSystem system)
{
    Console.WriteLine();
    Console.WriteLine(
        $"=== CUSTOMERS ({system.Customers.Count}) ===");

    foreach (var customer in system.Customers)
    {
        string vipText =
            customer.IsVip ? "yes" : "no";

        Console.WriteLine(
            $"#{customer.Id}  " +
            $"{customer.Name}  " +
            $"<{customer.Email}>  " +
            $"{customer.City}  " +
            $"vip={vipText}");
    }
}


// ------------------------------------------------------------
// PRINT PRODUCTS
// ------------------------------------------------------------

static void PrintProducts(OrderSystem system)
{
    Console.WriteLine();
    Console.WriteLine(
        $"=== PRODUCTS ({system.Products.Count}) ===");

    foreach (var product in system.Products)
    {
        Console.WriteLine(
            $"#{product.Id}  " +
            $"{product.Name}  " +
            $"price={product.Price:F2}  " +
            $"stock={product.Stock}");
    }
}


// ------------------------------------------------------------
// PRINT ALL ORDERS
// ------------------------------------------------------------

static void PrintAllOrders(OrderSystem system)
{
    Console.WriteLine();
    Console.WriteLine(
        $"=== ALL ORDERS ({system.Orders.Count}) ===");

    foreach (var order in system.Orders)
    {
        PrintOrder(order);
    }
}


// ------------------------------------------------------------
// PRINT ONE ORDER
// ------------------------------------------------------------

static void PrintOrder(Order order)
{
    Console.WriteLine();

    Console.WriteLine(
        $"=== ORDER #{order.Id} ===");

    Console.WriteLine(
        $"Date: {order.Date}");

    Console.WriteLine(
        $"Customer: {order.Customer.Name} " +
        $"(#{order.Customer.Id})");

    string paidText =
        order.IsPaid ? "yes" : "no";

    Console.WriteLine(
        $"Paid: {paidText}");

    Console.WriteLine("Lines:");

    foreach (var line in order.Lines)
    {
        Console.WriteLine(
            $"  - {line.Product.Name}  " +
            $"x{line.Quantity}  " +
            $"@{line.Product.Price:F2}  " +
            $"= {line.CalculateSubtotal():F2}");
    }

    Console.WriteLine(
        $"TOTAL: {order.CalculateTotal():F2}");
}