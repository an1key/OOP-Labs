namespace Lab8_2;

// Класс для Юпитера (Singleton)
public sealed class Jupiter : CelestialBody
{
    private static readonly Jupiter instance = new Jupiter();

    private Jupiter() : base("Jupiter", 1.898e27, 69911, 778.5)
    {
    }

    public static Jupiter Instance => instance;
}