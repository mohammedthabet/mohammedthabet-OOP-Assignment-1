public class Room
{
    private double _nightlyRate;

    public int RoomNumber { get; }
    public string RoomType { get; }

    public double NightlyRate
    {
        get { return _nightlyRate; }
    }

    public bool IsUnderMaintenance { get; private set; }

    public Room(
        int roomNumber,
        string roomType,
        double nightlyRate)
    {
        if (nightlyRate <= 0)
        {
            throw new ArgumentException(
                "Nightly rate must be greater than zero.");
        }

        RoomNumber = roomNumber;
        RoomType = roomType;
        _nightlyRate = nightlyRate;
        IsUnderMaintenance = false;
    }

    public void ChangeNightlyRate(double newRate)
    {
        if (newRate <= 0)
        {
            throw new ArgumentException(
                "Nightly rate must be greater than zero.");
        }

        _nightlyRate = newRate;
    }

    public void PutUnderMaintenance()
    {
        IsUnderMaintenance = true;
    }

    public void ReturnToService()
    {
        IsUnderMaintenance = false;
    }
}