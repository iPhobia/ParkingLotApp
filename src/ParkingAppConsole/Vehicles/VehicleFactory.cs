public static class VehicleFactory
{
    public static Vehicle CreateVehicle(string vehicleType) => vehicleType switch
    {
        "car" => new Car(),
        "van" => new Van(),
        "motorcycle" => new Motorcycle(),
        _ => UnknownVehicle.Instance,
    };
}