# Part 3 - Builder Pattern Critique

## Task 3.1 - Problems with the Large Constructor

A constructor with around twenty parameters is difficult to read and
maintain at the call site.

Many parameters have the same type, especially strings and numeric values.
This makes it possible to accidentally pass values in the wrong order
without producing a compiler error.

Optional properties make the problem worse because the constructor grows
as new properties are added.

The problem is deeper than constructor length. The properties represent
different concepts such as customer information, billing and shipping
addresses, and order/payment information.

This suggests that the data should not remain one large flat structure.

## Task 3.2 - Single Fluent Builder

The single fluent builder improves readability by replacing positional
constructor arguments with named methods.

For example:

- WithCustomerName(...)
- WithBillingAddress(...)
- WithPaymentMethod(...)
- WithCurrency(...)

The Build() method also provides one place to verify that mandatory
information has been provided before creating the Invoice.

However, the single builder still knows too much about several different
groups of data.

It is responsible for customer information, addresses, order information,
payment information, amounts, and validation.

## Task 3.3 - Composed Builders

The composed design separates construction responsibilities.

AddressBuilder is responsible for constructing and validating an Address.

The same AddressBuilder can be reused for both billing and shipping
addresses.

OrderBuilder is responsible for constructing and validating OrderInfo.

InvoiceBuilder no longer needs to understand the internal fields of an
address or order. It only composes already constructed objects into the
final Invoice.

This improves Single Responsibility because each builder focuses on one
concept.

It also improves independent validation because AddressBuilder can reject
an incomplete address without InvoiceBuilder knowing which address fields
are required.

Reuse improves because the same Address and AddressBuilder abstractions
can be used wherever an address is needed.

The call site is more explicit because values such as subtotal, discount,
tax, and total are provided through named methods instead of several
adjacent numeric parameters.

## Trade-off

The composed design introduces more classes and therefore more structural
complexity.

For a very small object, this additional structure may not be justified.

For an object with many properties that naturally belong to separate
conceptual groups, the additional classes are justified because they
improve readability, validation, reuse, and maintainability.