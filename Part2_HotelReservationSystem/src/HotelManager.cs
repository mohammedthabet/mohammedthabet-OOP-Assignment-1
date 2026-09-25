public class HotelManager
{
    private readonly List<Guest> _guests = new();
    private readonly List<Room> _rooms = new();
    private readonly List<Reservation> _reservations = new();

    public IReadOnlyList<Guest> Guests => _guests;
    public IReadOnlyList<Room> Rooms => _rooms;
    public IReadOnlyList<Reservation> Reservations => _reservations;

    public void AddGuest(Guest guest)
    {
        _guests.Add(guest);
    }

    public void AddRoom(Room room)
    {
        _rooms.Add(room);
    }

    public Guest? FindGuest(int guestId)
    {
        foreach (var guest in _guests)
        {
            if (guest.GuestId == guestId)
            {
                return guest;
            }
        }

        return null;
    }

    public Room? FindRoom(int roomNumber)
    {
        foreach (var room in _rooms)
        {
            if (room.RoomNumber == roomNumber)
            {
                return room;
            }
        }

        return null;
    }

    public Reservation? FindReservation(int reservationId)
    {
        foreach (var reservation in _reservations)
        {
            if (reservation.ReservationId == reservationId)
            {
                return reservation;
            }
        }

        return null;
    }
    public Reservation CreateReservation(
        int reservationId,
        int guestId,
        int roomNumber,
        DateTime checkInDate,
        DateTime checkOutDate)
    {
        if (FindReservation(reservationId) != null)
        {
            throw new InvalidOperationException(
                $"Reservation id {reservationId} already exists.");
        }

        Guest? guest = FindGuest(guestId);

        if (guest == null)
        {
            throw new InvalidOperationException(
                $"Guest id {guestId} not found.");
        }

        Room? room = FindRoom(roomNumber);

        if (room == null)
        {
            throw new InvalidOperationException(
                $"Room {roomNumber} not found.");
        }
foreach (var existingReservation in _reservations)
{
    bool sameRoom =
        existingReservation.Room.RoomNumber == roomNumber;

    bool activeReservation =
    existingReservation.Status == ReservationStatus.Pending ||
    existingReservation.Status == ReservationStatus.Confirmed ||
    existingReservation.Status == ReservationStatus.CheckedIn;

    bool datesOverlap =
        checkInDate < existingReservation.CheckOutDate &&
        checkOutDate > existingReservation.CheckInDate;

    if (sameRoom && activeReservation && datesOverlap)
    {
        throw new InvalidOperationException(
            $"Room {roomNumber} is already reserved for these dates.");
    }
}
        var reservation = new Reservation(
            reservationId,
            checkInDate,
            checkOutDate,
            room);

        _reservations.Add(reservation);

        guest.AddReservation(reservation);

        return reservation;
    }
public void PrintRoomAvailability()
{
    Console.WriteLine();
    Console.WriteLine("=== ROOM AVAILABILITY ===");

    foreach (var room in _rooms)
    {
        bool hasActiveReservation = false;

        foreach (var reservation in _reservations)
        {
            bool sameRoom =
                reservation.Room.RoomNumber == room.RoomNumber;

            bool active =
                reservation.Status == ReservationStatus.Pending ||
                reservation.Status == ReservationStatus.Confirmed ||
                reservation.Status == ReservationStatus.CheckedIn;

            if (sameRoom && active)
            {
                hasActiveReservation = true;
                break;
            }
        }

        string availability;

        if (room.IsUnderMaintenance)
        {
            availability = "Under Maintenance";
        }
        else if (hasActiveReservation)
        {
            availability = "Reserved";
        }
        else
        {
            availability = "Available";
        }

        Console.WriteLine(
            $"Room {room.RoomNumber} - {room.RoomType} - {availability}");
    }
}
public void PrintActiveReservationsSummary()
{
    Console.WriteLine();
    Console.WriteLine("=== ACTIVE RESERVATIONS ===");

    foreach (var reservation in _reservations)
    {
        bool active =
            reservation.Status == ReservationStatus.Pending ||
            reservation.Status == ReservationStatus.Confirmed ||
            reservation.Status == ReservationStatus.CheckedIn;

        if (active)
        {
            Console.WriteLine(
                $"Reservation #{reservation.ReservationId} | " +
                $"Room {reservation.Room.RoomNumber} | " +
                $"{reservation.CheckInDate:yyyy-MM-dd} → " +
                $"{reservation.CheckOutDate:yyyy-MM-dd} | " +
                $"{reservation.Status}");
        }
    }
}
}

