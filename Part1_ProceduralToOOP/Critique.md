# Part 1 - Procedural Design Critique

The original C++ program satisfies its current functional requirements,
but its procedural design becomes increasingly difficult to maintain and extend as the system grows.

## 1. Parallel Arrays

Customer data is stored in separate arrays such as customer IDs, names,
emails, cities, and VIP flags.

The same pattern is used for products and orders.

These arrays depend on matching indexes. For example, customer data at
index 0 across several arrays must always represent the same customer.

This is fragile because adding, removing, or modifying data incorrectly in
one array can make the arrays inconsistent.

### OOP Improvement

Related data is grouped into objects:

- `Customer` owns customer data.
- `Product` owns product data.
- `Order` owns order data.
- `OrderLine` represents one product and quantity inside an order.


## 2. Index-Based Relationships

The procedural version connects related data using indexes.

For example, an order may store the index of its customer instead of
directly referring to a customer object.

This makes relationships harder to understand and creates dependency on the
internal positions of items inside arrays.

### OOP Improvement

The OOP version uses object references.

An `Order` directly references its `Customer`, and an `OrderLine` directly
references its `Product`.

This makes relationships explicit and easier to follow.


## 3. Global State

The procedural program stores customers, products, orders, counts, and other
state in globally accessible arrays and variables.

Because many functions can access and modify the same global state, it is
harder to understand which part of the program owns or controls the data.

As the program grows, changes in one function can unintentionally affect
other parts of the system.

### OOP Improvement

State is owned by objects.

`OrderSystem` owns the collections of customers, products, and orders.
Individual objects own their own state.


## 4. Scattered Business Rules

Business rules are spread across procedural functions.

Examples include:

- stock must be sufficient before adding an order line;
- quantity must be greater than zero;
- paid orders cannot be modified;
- empty orders cannot be paid;
- VIP customers receive a discount.

When rules are scattered across functions, it becomes easier to forget a
validation when another part of the program performs the same operation.

### OOP Improvement

Rules are moved closer to the objects that own the relevant state.

- `Product` validates and changes stock.
- `Order` controls its lines, payment state, and total calculation.
- `OrderSystem` coordinates customers, products, and orders.


## 5. Responsibilities Are Mixed

In the procedural version, functions often work directly with several
different groups of arrays and are responsible for locating data, validating
rules, modifying state, and sometimes displaying results.

This increases coupling and makes individual operations harder to reason
about and change.

### OOP Improvement

Responsibilities are divided between objects.

`Product` handles product state.
`OrderLine` represents one order line.
`Order` manages an individual order.
`OrderSystem` coordinates the overall collection of objects.
`Program.cs` handles console input and output.


## Summary - Procedural → OOP

Parallel customer arrays
↓
Customer

Parallel product arrays
↓
Product

Order arrays + order functions
↓
Order

Line arrays
↓
OrderLine

Indexes
↓
Object References

Global State
↓
Objects own State

Scattered Rules
↓
Objects enforce Rules