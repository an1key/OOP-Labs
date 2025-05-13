namespace Lab8_2;

public sealed class Earth : CelestialBody
{
    private static readonly Earth instance = new Earth();

    private Earth() : base("Earth", 5.972e24, 6371, 149.6)
    {
    }

    public static Earth Instance => instance;
}
