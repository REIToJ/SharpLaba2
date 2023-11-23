class Program
{
    static void Main()
    {
        RacingSimulator simulator = new RacingSimulator();

        Console.WriteLine("Welcome to the Racing Simulator!");

        Console.Write("Enter the distance for the race: ");
        double distance = double.Parse(Console.ReadLine());

        Console.Write("Enter the race type (ground/air/mixed): ");
        string raceType = Console.ReadLine();

        Race race = simulator.CreateRace(distance, raceType);

        Console.WriteLine("Available Vehicle Types:");
        List<string> availableVehicleTypes = DisplayAvailableVehicleTypes();

        while (true)
        {
            string userInput = Console.ReadLine();

            if (userInput.ToLower() == "done")
                break;

            if (int.TryParse(userInput, out int vehicleNumber) && vehicleNumber >= 1 && vehicleNumber <= availableVehicleTypes.Count)
            {
                string selectedVehicleType = availableVehicleTypes[vehicleNumber - 1];
                IVehicle vehicle = CreateVehicle(selectedVehicleType);

                simulator.RegisterVehicle(race, vehicle);
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number or 'done'.");
            }
        }

        Console.WriteLine("Press any key to start the race...");
        Console.ReadKey();

        simulator.StartRace(race);

        Console.ReadLine();
    }

    static List<string> DisplayAvailableVehicleTypes()
    {
        List<string> vehicleTypes = new List<string>
        {
            "BabaYagasMortar",
            "Broomstick",
            "BootsWithSprings",
            "PumpkinCarriage",
            "FlyingCarpet",
            "HutOnChickenLegs",
            "Centaur",
            "FlyingShip"
        };

        for (int i = 0; i < vehicleTypes.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {vehicleTypes[i]}");
        }

        return vehicleTypes;
    }

    static IVehicle CreateVehicle(string vehicleType)
    {
        switch (vehicleType.ToLower())
        {
            case "babayagasmortar":
                return new BabaYagasMortar();
            case "broomstick":
                return new Broomstick();
            case "bootswithsprings":
                return new BootsWithSprings();
            case "pumpkincarriage":
                return new PumpkinCarriage();
            case "flyingcarpet":
                return new FlyingCarpet();
            case "hutonchickenlegs":
                return new HutOnChickenLegs();
            case "centaur":
                return new Centaur();
            case "flyingship":
                return new FlyingShip();
            default:
                throw new ArgumentException("Invalid vehicle type.");
        }
    }
}
