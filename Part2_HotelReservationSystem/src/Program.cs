Console.WriteLine("======================================");
Console.WriteLine("       HOTEL RESERVATION SYSTEM       ");
Console.WriteLine("======================================");
Console.WriteLine();


// ======================================================
// 1. Create the hotel manager
// ======================================================

var hotel = new HotelManager();


// ======================================================
// 2. Create guests
// ======================================================

var mona = new Guest(
    1,
    "Mona Ali",
    "01012345678");

var omar = new Guest(
    2,
    "Omar Hassan",
    "01112345678");

hotel.AddGuest(mona);
hotel.AddGuest(omar);


// ======================================================
// 3. Create rooms
// ======================================================

var room101 = new Room(
    101,
    "Deluxe",
    1500);

var room102 = new Room(
    102,
    "Standard",
    1000);

var room103 = new Room(
    103,
    "Suite",
    2500);

hotel.AddRoom(room101);
hotel.AddRoom(room102);
hotel.AddRoom(room103);


// ======================================================
// 4. Create reservations
// ======================================================

var reservation1001 = hotel.CreateReservation(
    1001,
    1,
    101,
    new DateTime(2026, 10, 10),
    new DateTime(2026, 10, 15));

var reservation1002 = hotel.CreateReservation(
    1002,
    2,
    102,
    new DateTime(2026, 11, 10),
    new DateTime(2026, 11, 15));


// ======================================================
// 5. Display reservation details
// ======================================================

Console.WriteLine("=== RESERVATION DETAILS ===");

Console.WriteLine(
    $"Reservation #{reservation1001.ReservationId}");

Console.WriteLine(
    $"Guest: {mona.FullName}");

Console.WriteLine(
    $"Room: {reservation1001.Room.RoomNumber} " +
    $"({reservation1001.Room.RoomType})");

Console.WriteLine(
    $"Check-in: {reservation1001.CheckInDate:yyyy-MM-dd}");

Console.WriteLine(
    $"Check-out: {reservation1001.CheckOutDate:yyyy-MM-dd}");

Console.WriteLine(
    $"Status: {reservation1001.Status}");

Console.WriteLine(
    $"Total Cost: {reservation1001.CalculateTotalCost():F2}");


// ======================================================
// 6. Demonstrate reservation lifecycle
// ======================================================

Console.WriteLine();
Console.WriteLine("=== RESERVATION LIFECYCLE ===");

Console.WriteLine(
    $"Initial Status: {reservation1001.Status}");

reservation1001.Confirm();

Console.WriteLine(
    $"After Confirm: {reservation1001.Status}");

reservation1001.CheckIn();

Console.WriteLine(
    $"After Check-In: {reservation1001.Status}");

reservation1001.CheckOut();

Console.WriteLine(
    $"After Check-Out: {reservation1001.Status}");


// ======================================================
// 7. Guest reservation history
// ======================================================

Console.WriteLine();
Console.WriteLine("=== GUEST RESERVATION HISTORY ===");

Console.WriteLine(
    $"{mona.FullName}: {mona.Reservations.Count} reservation(s)");

foreach (var reservation in mona.Reservations)
{
    Console.WriteLine(
        $"Reservation #{reservation.ReservationId} - " +
        $"Room {reservation.Room.RoomNumber} - " +
        $"{reservation.Status}");
}


// ======================================================
// 8. Room maintenance demonstration
// ======================================================

room103.PutUnderMaintenance();

Console.WriteLine();
Console.WriteLine("=== ROOM MAINTENANCE ===");

Console.WriteLine(
    $"Room {room103.RoomNumber}: " +
    $"{(room103.IsUnderMaintenance ? "Under Maintenance" : "In Service")}");


// ======================================================
// 9. Reports
// ======================================================

hotel.PrintRoomAvailability();

hotel.PrintActiveReservationsSummary();