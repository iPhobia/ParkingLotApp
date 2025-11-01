public class LargeParkingLotSpot : ParkingLotSpot
{
    public LargeParkingLotSpot()
    {
        AvailableSpotsLeft = Capacity;
    }

    protected override int Capacity => 3;

    protected override bool CanParkBase(Vehicle vehicle)
    {
        return vehicle is Van or Motorcycle or Car;
    }
}