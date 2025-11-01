public class UnknownVehicle : Vehicle
{
    private static readonly UnknownVehicle _instance = new();
    private UnknownVehicle()
    {}

    public static UnknownVehicle Instance = _instance;

    public override int ReserveSpotsAmount => 0;
}