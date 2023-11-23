using System;

// Vehicle Abstractions

public interface IVehicle
{
    double Speed { get; }
    double CalculateTravelTime(double distance);
}

public abstract class Vehicle : IVehicle
{
    public double Speed { get; protected set; }

    public abstract double CalculateTravelTime(double distance);
}

public abstract class GroundVehicle : Vehicle
{
    public double TravelTimeToRest { get; protected set; }

    public abstract double GetRestDuration(int stopNumber);
}

public abstract class AirVehicle : Vehicle
{
    public abstract double AccelerationCoefficient(double distance);
}

// Vehicle Types

public class BabaYagasMortar : AirVehicle
{
    public BabaYagasMortar()
    {
        Speed = 15; 
    }

    public override double CalculateTravelTime(double distance)
    {
        return distance / Speed;
    }

    public override double AccelerationCoefficient(double distance)
    {
        // Quadratic acceleration 
        return distance * distance / 1000;
    }
}

public class Broomstick : AirVehicle
{
    public Broomstick()
    {
        Speed = 20; 
    }

    public override double CalculateTravelTime(double distance)
    {
        return distance / Speed;
    }

    public override double AccelerationCoefficient(double distance)
    {
        // Linear acceleration 
        return distance / 100;
    }
}

public class FlyingCarpet : AirVehicle
{
    public FlyingCarpet()
    {
        Speed = 18; 
    }

    public override double CalculateTravelTime(double distance)
    {
        return distance / Speed;
    }

    public override double AccelerationCoefficient(double distance)
    {
        // Exponential acceleration 
        return Math.Pow(1.2, distance / 100);
    }
}

public class FlyingShip : AirVehicle
{
    public FlyingShip()
    {
        Speed = 22; 
    }

    public override double CalculateTravelTime(double distance)
    {
        return distance / Speed;
    }

    public override double AccelerationCoefficient(double distance)
    {
        // Logarithmic acceleration 
        return Math.Log(distance + 1, 10);
    }
}

public class BootsWithSprings : GroundVehicle
{
    public BootsWithSprings()
    {
        Speed = 12; 
        TravelTimeToRest = 3; 
    }

    public override double CalculateTravelTime(double distance)
    {
        return distance / Speed;
    }

    public override double GetRestDuration(int stopNumber)
    {
        // Rest duration increases exponentially with the stop number
        return Math.Pow(2, stopNumber - 1) * TravelTimeToRest;
    }
}

public class PumpkinCarriage : GroundVehicle
{
    public PumpkinCarriage()
    {
        Speed = 6; 
        TravelTimeToRest = 2.5; 
    }

    public override double CalculateTravelTime(double distance)
    {
        return distance / Speed;
    }

    public override double GetRestDuration(int stopNumber)
    {
        // Constant rest duration
        return TravelTimeToRest;
    }
}

public class HutOnChickenLegs : GroundVehicle
{
    public HutOnChickenLegs()
    {
        Speed = 5; 
        TravelTimeToRest = 3; 
    }

    public override double CalculateTravelTime(double distance)
    {
        return distance / Speed;
    }

    public override double GetRestDuration(int stopNumber)
    {
        // Rest duration increases linearly with the stop number
        return stopNumber * TravelTimeToRest;
    }
}

public class Centaur : GroundVehicle
{
    public Centaur()
    {
        Speed = 15; 
        TravelTimeToRest = 2; 
    }

    public override double CalculateTravelTime(double distance)
    {
        return distance / Speed;
    }

    public override double GetRestDuration(int stopNumber)
    {
        // Quadratic rest duration
        return stopNumber * stopNumber * TravelTimeToRest;
    }
}
