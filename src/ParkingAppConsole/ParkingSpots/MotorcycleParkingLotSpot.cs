public class MotorcycleParkingLotSpot : ParkingLotSpot
{
    public MotorcycleParkingLotSpot()
    {
        AvailableSpotsLeft = Capacity;
    }
    
    protected override int Capacity => 1;

    protected override bool CanParkBase(Vehicle vehicle)
    {
        return vehicle is Motorcycle;
    }
}