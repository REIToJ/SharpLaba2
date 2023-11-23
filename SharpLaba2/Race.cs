using System;
using System.Collections.Generic;
using System.Linq;

// Race Abstractions

public abstract class Race
{
    public double Distance { get; }
    public List<IVehicle> RegisteredVehicles { get; } = new List<IVehicle>();

    protected Race(double distance)
    {
        Distance = distance;
    }

    public abstract void RegisterVehicle(IVehicle vehicle);
    public abstract void StartRace();
}

public class GroundRace : Race
{
    public GroundRace(double distance) : base(distance) { }

    public override void RegisterVehicle(IVehicle vehicle)
    {
        if (vehicle is GroundVehicle)
            RegisteredVehicles.Add(vehicle);
        else
            throw new Exception("Invalid vehicle type for ground race.");
    }

    public override void StartRace()
    {
        Console.WriteLine($"{GetType().Name} Started!");
        Console.WriteLine($"Distance: {Distance} units");

        // Calculate travel times for each vehicle
        Dictionary<IVehicle, double> travelTimes = new Dictionary<IVehicle, double>();
        foreach (var vehicle in RegisteredVehicles)
        {
            double travelTime = RaceUtils.CalculateRaceTravelTime(vehicle, Distance);
            travelTimes.Add(vehicle, travelTime);

            Console.WriteLine($"{vehicle.GetType().Name}: {travelTime} time units");
        }

        // Determine the winner
        IVehicle winner = travelTimes.OrderBy(pair => pair.Value).First().Key;
        Console.WriteLine($"Winner: {winner.GetType().Name}");
    }
}

public class AirRace : Race
{
    public AirRace(double distance) : base(distance) { }

    public override void RegisterVehicle(IVehicle vehicle)
    {
        if (vehicle is AirVehicle)
            RegisteredVehicles.Add(vehicle);
        else
            throw new Exception("Invalid vehicle type for air race.");
    }

    public override void StartRace()
    {
        Console.WriteLine($"{GetType().Name} Started!");
        Console.WriteLine($"Distance: {Distance} units");

        // Calculate travel times for each vehicle
        Dictionary<IVehicle, double> travelTimes = new Dictionary<IVehicle, double>();
        foreach (var vehicle in RegisteredVehicles)
        {
            double travelTime = RaceUtils.CalculateRaceTravelTime(vehicle, Distance);
            travelTimes.Add(vehicle, travelTime);

            Console.WriteLine($"{vehicle.GetType().Name}: {travelTime} time units");
        }

        // Determine the winner
        IVehicle winner = travelTimes.OrderBy(pair => pair.Value).First().Key;
        Console.WriteLine($"Winner: {winner.GetType().Name}");
    }
}

public class MixedRace : Race
{
    public MixedRace(double distance) : base(distance) { }

    public override void RegisterVehicle(IVehicle vehicle)
    {
        RegisteredVehicles.Add(vehicle);
    }

    public override void StartRace()
    {
        Console.WriteLine($"{GetType().Name} Started!");
        Console.WriteLine($"Distance: {Distance} units");

        // Calculate travel times for each vehicle
        Dictionary<IVehicle, double> travelTimes = new Dictionary<IVehicle, double>();
        foreach (var vehicle in RegisteredVehicles)
        {
            double travelTime = RaceUtils.CalculateRaceTravelTime(vehicle, Distance);
            travelTimes.Add(vehicle, travelTime);

            Console.WriteLine($"{vehicle.GetType().Name}: {travelTime} time units");
        }

        // Determine the winner
        IVehicle winner = travelTimes.OrderBy(pair => pair.Value).First().Key;
        Console.WriteLine($"Winner: {winner.GetType().Name}");
    }
}

public static class RaceUtils
{
    public static double CalculateRaceTravelTime(IVehicle vehicle, double distance)
    {
        double currentDistance = 0;
        double totalTime = 0;
        int stopNumber = 1;

        while (currentDistance < distance)
        {
            double remainingDistance = distance - currentDistance;
            double travelTime = vehicle.CalculateTravelTime(remainingDistance);
            totalTime += travelTime;

            // Check if the vehicle needs to rest (only for ground vehicles)
            if (vehicle is GroundVehicle)
            {
                double restDuration = (vehicle as GroundVehicle).GetRestDuration(stopNumber);
                totalTime += restDuration;
            }

            currentDistance += vehicle.Speed * travelTime;
            stopNumber++;
        }

        return totalTime;
    }
}
