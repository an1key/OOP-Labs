namespace Lab8_2;

// Класс для Марса (Singleton)
public sealed class Mars : CelestialBody
{
    private static readonly Mars instance = new Mars();

    private Mars() : base("Mars", 6.39e23, 3389.5, 227.9)
    {
    }

    public static Mars Instance => instance;
}