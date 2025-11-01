public class RegularParkingLotSpot : ParkingLotSpot
{
    public RegularParkingLotSpot()
    {
        AvailableSpotsLeft = Capacity;
    }
    
    protected override int Capacity => 1;

    protected override bool CanParkBase(Vehicle vehicle)
    {
        return vehicle is Car or Motorcycle;
    }
}