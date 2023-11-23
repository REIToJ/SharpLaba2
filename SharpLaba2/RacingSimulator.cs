using System;

// Racing Simulator

public class RacingSimulator
{
    public Race CreateRace(double distance, string raceType)
    {
        switch (raceType.ToLower())
        {
            case "ground":
                return new GroundRace(distance);
            case "air":
                return new AirRace(distance);
            case "mixed":
                return new MixedRace(distance);
            default:
                throw new ArgumentException("Invalid race type.");
        }
    }
    public void RegisterVehicle(Race race, IVehicle vehicle)
    {
        try
        {
            race.RegisterVehicle(vehicle);
            Console.WriteLine($"Vehicle {vehicle.GetType().Name} registered for the race.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
    public void StartRace(Race race)
    {
        try
        {
            race.StartRace();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
