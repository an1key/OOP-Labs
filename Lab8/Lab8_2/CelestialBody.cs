namespace Lab8_2;

public abstract class CelestialBody : IRevolveAroundSun, IRotatable
{
    public string Name { get; protected set; }
    public double Mass { get; protected set; } // в кг
    public double Radius { get; protected set; } // в км
    public double DistanceFromSun { get; protected set; } // в млн км

    protected CelestialBody(string name, double mass, double radius, double distanceFromSun)
    {
        Name = name;
        Mass = mass;
        Radius = radius;
        DistanceFromSun = distanceFromSun;
    }
    
    public void Rotate()
    {
        Console.WriteLine($"{Name} is rotating around its axis.");
    }

    public void Revolve()
    {
        Console.WriteLine($"{Name} is revolving around the Sun.");
    }
}