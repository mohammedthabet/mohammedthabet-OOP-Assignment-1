# OOP Assignment 1

This repository contains the solutions for OOP Assignment 1.

The assignment focuses on object-oriented design, encapsulation, object
relationships, the Builder Pattern, and the Two Pointers problem-solving
technique.

---

## Repository Structure

```text
Part1_ProceduralToOOP/
├── Critique.md
└── src/

Part2_HotelReservationSystem/
└── src/

Part3_BuilderPattern/
├── BuilderCritique.md
└── src/

Part4_LeetCode/
└── 1679_MaxNumberOfKSumPairs/
    ├── Solution.cs
    └── accepted_screenshot.png
```

---

## Part 1 - Procedural to OOP Refactoring

The original procedural order-management design was refactored into an
object-oriented model.

### Main Classes

- `Customer`
- `Product`
- `Order`
- `OrderLine`
- `OrderSystem`

### Design Decisions

Related data is grouped into objects instead of parallel arrays.

Object references are used instead of index-based relationships. For
example, an `Order` references its `Customer`, and an `OrderLine`
references its `Product`.

Business rules are placed close to the objects that own the relevant
state:

- `Product` controls stock changes.
- `Order` controls order lines, payment state, and total calculation.
- `OrderSystem` coordinates customers, products, and orders.

Collections are exposed through `IReadOnlyList<T>` to prevent external
code from directly modifying the internal lists.

Additional discussion of the procedural design and the OOP improvements
is available in `Part1_ProceduralToOOP/Critique.md`.

---

## Part 2 - Hotel Reservation System

This part implements a small hotel reservation domain using encapsulation
and object relationships.

### Main Classes

- `Guest`
- `Room`
- `Reservation`
- `HotelManager`
- `ReservationStatus`

### Design Decisions

`Guest` maintains reservation history while preventing external code from
directly modifying the internal reservation collection.

`Room` owns its nightly rate and maintenance state and exposes controlled
methods for changing them.

`Reservation` controls its lifecycle using the following states:

```text
Pending
   ↓
Confirmed
   ↓
CheckedIn
   ↓
CheckedOut
```

A reservation can also be cancelled when allowed by its current state.

`HotelManager` coordinates guests, rooms, and reservations and prevents
overlapping active reservations for the same room.

---

## Part 3 - Builder Pattern

This part explores the Builder Pattern for constructing a complex
`Invoice`.

The implementation progresses from the problems of a large constructor
to a fluent builder and then to composed builders.

### Main Types

- `Invoice`
- `InvoiceBuilder`
- `Address`
- `AddressBuilder`
- `OrderInfo`
- `OrderBuilder`

### Design Decisions

The Builder Pattern replaces a long positional constructor with readable
named construction steps.

The final design uses composed builders:

```text
AddressBuilder ──> Address ─────┐
                               │
AddressBuilder ──> Address ─────┼──> InvoiceBuilder ──> Invoice
                               │
OrderBuilder ────> OrderInfo ───┘
```

Each builder is responsible for constructing and validating its own
concept.

This improves:

- readability;
- separation of responsibilities;
- independent validation;
- reuse of smaller objects and builders.

The design trade-offs are discussed in
`Part3_BuilderPattern/BuilderCritique.md`.

---

## Part 4 - LeetCode Two Pointers

Problem:

**1679 - Max Number of K-Sum Pairs**

The solution uses the required Two Pointers approach.

### Approach

1. Sort the array.
2. Place one pointer at the beginning and one at the end.
3. Compare their sum with `k`.
4. If the sum equals `k`, count the pair and move both pointers.
5. If the sum is smaller than `k`, move the left pointer.
6. If the sum is greater than `k`, move the right pointer.

### Complexity

- Sorting: `O(n log n)`
- Two-pointer scan: `O(n)`
- Overall time complexity: `O(n log n)`

The accepted LeetCode submission screenshot is included in the problem
folder.

---

## Requirements

- .NET SDK 10.0
- C# 14 compatible environment

To check the installed .NET SDK:

```powershell
dotnet --version
```

---

## Build and Run

Each console application can be built and run independently from the
repository root.

### Part 1

```powershell
dotnet build Part1_ProceduralToOOP/src
dotnet run --project Part1_ProceduralToOOP/src
```

### Part 2

```powershell
dotnet build Part2_HotelReservationSystem/src
dotnet run --project Part2_HotelReservationSystem/src
```

### Part 3

```powershell
dotnet build Part3_BuilderPattern/src
dotnet run --project Part3_BuilderPattern/src
```

Part 4 contains the LeetCode solution and does not require a local console
project.

---

## Key Concepts Demonstrated

- Classes and objects
- Encapsulation
- Properties and controlled mutation
- Object relationships
- Collections and `IReadOnlyList<T>`
- Business-rule validation
- Reservation state transitions
- Builder Pattern
- Fluent APIs
- Composed builders
- Two Pointers