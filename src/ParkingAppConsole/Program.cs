Console.WriteLine("--------------------------------------------------");
Console.WriteLine("Welcome to Parking Lot simulator");
Console.WriteLine("Please, enter amount of regular parking spots from 0 to 5 inclusively...");
var regularSpotsAmount = ReadAndValidateInput();
Console.WriteLine("Please, enter amount of motorcycle parking spots from 0 to 5 inclusively...");
var motorcycleSpotsAmount = ReadAndValidateInput();
Console.WriteLine("Please, enter amount of large parking spots from 0 to 5 inclusively...");
var largeSpotsAmount = ReadAndValidateInput();

var parkingLotManager = CreateParkingLotManager(regularSpotsAmount, motorcycleSpotsAmount, largeSpotsAmount);

RunManager(parkingLotManager);

void RunManager(ParkingLotManager parkingLotManager)
{
    Console.WriteLine("--------------------------------------------------");
    Console.WriteLine("Configuration is finished. Choose any action to continue...");
    Console.WriteLine("--------------------------------------------------");

    while (true)
    {
        Console.WriteLine("Type 'showstate' to display parking lot state information");
        Console.WriteLine("Type 'park' to park a vehicle");
        Console.WriteLine("Type 'showlot' to show taken spots amount by vehicle type");
        Console.WriteLine("Enter command...");
        string? input = Console.ReadLine()?.Trim().ToLower();

        switch (input)
        {
            case "showstate":
                DisplayParkingLotState(parkingLotManager);
                break;

            case "park":
                HandleParking(parkingLotManager);
                break;

            case "showlot":
                DisplayParkingSpotsTakenByVehicle(parkingLotManager);
                break;

            default:
                Console.WriteLine("Unknown command. Try 'showstate' or 'park' or 'showlot'");
                break;
        }

        Console.WriteLine("Enter 'q' to exit app, or press Enter to continue");
        if (Console.ReadLine() == "q")
            break;
    }
}

void DisplayParkingSpotsTakenByVehicle(ParkingLotManager parkingLotManager)
{
    Console.WriteLine("--------------------------------------------------");
    while (true)
    {
        Console.WriteLine("Enter your vehicle type: 'car', 'motorcycle' or 'van'...");
        var input = Console.ReadLine()?.Trim().ToLower();

        var vehicle = VehicleFactory.CreateVehicle(input);
        var spotsTakenAmount = parkingLotManager.GetTakenSpotsAmountBy(vehicle);
        
        Console.WriteLine($"{spotsTakenAmount} Spots taken by {input} vehicles");

        Console.WriteLine("Enter 'q' to quit, or press Enter to continue");
        if (Console.ReadLine() == "q")
        {
            Console.WriteLine("Exiting to main menu...");
            break;
        }
    }
    Console.WriteLine("--------------------------------------------------");
}

void DisplayParkingLotState(ParkingLotManager parkingLotManager)
{
    Console.WriteLine("--------------------------------------------------");
    Console.WriteLine("Parking lot state:");
    Console.WriteLine($"Parking lot is full: {parkingLotManager.ParkingLotIsFull}");
    Console.WriteLine($"Parking lot is empty: {parkingLotManager.ParkingLotIsEmpty}");
    Console.WriteLine($"Available spots left: {parkingLotManager.AvailableParkingSpotsLeft}");
    Console.WriteLine($"Total parking spots: {parkingLotManager.TotalParkingSpotsAmount}");
    Console.WriteLine($"Parking lot spots taken: ");
    foreach (var s in parkingLotManager.GetTakenParkingLotSpots)
    {
        Console.WriteLine($"{s.Key}: {s.Value}");
    }
    Console.WriteLine("--------------------------------------------------");
}

void HandleParking(ParkingLotManager parkingLotManager)
{
    Console.WriteLine("--------------------------------------------------");
    while (true)
    {
        Console.WriteLine("Enter your vehicle type: 'car', 'motorcycle' or 'van'...");
        var input = Console.ReadLine()?.Trim().ToLower();

        var vehicle = VehicleFactory.CreateVehicle(input);
        var isSuccess = parkingLotManager.ParkVehicle(vehicle);

        if (isSuccess)
        {
            Console.WriteLine("Your car was parked successfully");
        }
        else
        {
            Console.WriteLine("Couldn't park your can unfortunately");
        }

        Console.WriteLine("Enter 'q' to quit, or press Enter to continue");
        if (Console.ReadLine() == "q")
        {
            Console.WriteLine("Exiting to main menu...");
            break;
        }
    }
    Console.WriteLine("--------------------------------------------------");
}

ParkingLotManager CreateParkingLotManager(int regularSpotsAmount, int motorcycleSpotsAmount, int largeSpotsAmount)
{
    var parkingLotSpots = new List<ParkingLotSpot>();

    parkingLotSpots.AddRange(Enumerable.Range(1, regularSpotsAmount).Select(_ => new RegularParkingLotSpot()));
    parkingLotSpots.AddRange(Enumerable.Range(1, motorcycleSpotsAmount).Select(_ => new MotorcycleParkingLotSpot()));
    parkingLotSpots.AddRange(Enumerable.Range(1, largeSpotsAmount).Select(_ => new LargeParkingLotSpot()));

    return new ParkingLotManager(parkingLotSpots);
}

int ReadAndValidateInput()
{
    while (true)
    {
        var input = Console.ReadLine();

        if (int.TryParse(input, out int num))
        {
            if (num >= 0 && num <= 5)
            {
                return num;
            }

            Console.WriteLine("Please enter a number from 0 to 5 inclusively");
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid integer.");
        }
    }
}