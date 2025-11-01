
public abstract class ParkingLotSpot
{
    /// <summary>
    /// Configures capacity of parking lot spot type
    /// </summary>
    protected abstract int Capacity { get; }

    // keeps track of taken and available spots provided by concrete parking spot type
    public int AvailableSpotsLeft { get; protected set; }
    public int TakenSpots { get; private set; }

    /// <summary>
    /// Keeps track of parked vehicles.
    /// </summary>
    public List<Vehicle> ParkedVehicles { get; } = [];

    /// <summary>
    /// Validates business rules in order to park concrete vehicle type on given parking spot type
    /// </summary>
    /// <param name="vehicle"></param>
    /// <returns></returns>
    public bool CanPark(Vehicle vehicle)
    {
        return CanParkBase(vehicle) && AvailableSpotsLeft >= vehicle.ReserveSpotsAmount;
    }

    /// <summary>
    /// Validates business rules for specific parking spot type
    /// </summary>
    /// <param name="vehicle"></param>
    /// <returns></returns>
    protected abstract bool CanParkBase(Vehicle vehicle);

    /// <summary>
    /// Updates state of available spots
    /// </summary>
    /// <param name="vehicle"></param>
    private void ReserveSpots(Vehicle vehicle)
    {
        AvailableSpotsLeft -= vehicle.ReserveSpotsAmount;
        TakenSpots += vehicle.ReserveSpotsAmount;
    }

    public void Park(Vehicle vehicle)
    {
        ReserveSpots(vehicle);
        ParkedVehicles.Add(vehicle);
    }
}