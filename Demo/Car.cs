using System.Diagnostics;

public class Car
{
    public Engine Engine;

    public float CurrentSpeed; // in m/s
    public float DistanceTraveled; // in Meters
    public string Name;

    public Car(Engine engine, string name)
    {
        Engine = engine;
        Name = name;
    }

    // drives the car over 1 second
    public void Drive()
    {
        var newSpeed = CurrentSpeed + Engine.Acceleration;
        if (newSpeed > Engine.MaxSpeed)
            newSpeed = Engine.MaxSpeed;

        // average velocity
        DistanceTraveled += (CurrentSpeed + (newSpeed - CurrentSpeed) / 2f);
        CurrentSpeed = newSpeed;
    }
}