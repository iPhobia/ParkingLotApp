public class ParkingLotManager
{
    private List<ParkingLotSpot> ParkingLotSpots { get; }

    public ParkingLotManager(List<ParkingLotSpot> parkingLotSpots)
    {
        ParkingLotSpots = parkingLotSpots;
    }

    public int AvailableParkingSpotsLeft => ParkingLotSpots.Sum(x => x.AvailableSpotsLeft);
    public int TotalParkingSpotsAmount => ParkingLotSpots.Select(x => x.AvailableSpotsLeft + x.TakenSpots).Sum();
    public bool ParkingLotIsFull => ParkingLotSpots.All(x => x.AvailableSpotsLeft == 0);
    public bool ParkingLotIsEmpty => ParkingLotSpots.All(x => x.TakenSpots == 0);
    public Dictionary<string, int> GetTakenParkingLotSpots => ParkingLotSpots.Where(x => x.AvailableSpotsLeft == 0)
        .GroupBy(x => x.GetType().Name)
        .ToDictionary(g => g.Key, g => g.Count());

    /// <summary>
    /// Performs parking logic
    /// </summary>
    /// <param name="vehicle"></param>
    /// <returns></returns>
    public bool ParkVehicle(Vehicle vehicle)
    {
        if (vehicle is UnknownVehicle)
            return false;

        var availableParkingLotSpot = ParkingLotSpots.FirstOrDefault(x => x.CanPark(vehicle));

        if (availableParkingLotSpot is not null)
        {
            availableParkingLotSpot.Park(vehicle);
            return true;
        }
        else
        {
            return false;
        }
    }

    /// <summary>
    /// Calculates amount of taken spots by given vehicle type
    /// </summary>
    /// <param name="vehicle"></param>
    /// <returns></returns>
    public int GetTakenSpotsAmountBy(Vehicle vehicle)
    {
        if (vehicle is UnknownVehicle)
            return 0;
            
        return ParkingLotSpots.SelectMany(x => x.ParkedVehicles)
            .Where(x => x.GetType() == vehicle.GetType())
            .Sum(x => x.ReserveSpotsAmount);
    }
}