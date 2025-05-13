namespace Lab8_2;

class Program
{
    static void Main(string[] args)
    {
        // Получение экземпляров планет
        Earth earth = Earth.Instance;
        Mars mars = Mars.Instance;
        Jupiter jupiter = Jupiter.Instance;

        // Вывод информации о планетах
        Console.WriteLine($"Planet: {earth.Name}, Mass: {earth.Mass} kg, Radius: {earth.Radius} km, Distance from Sun: {earth.DistanceFromSun} million km");
        Console.WriteLine($"Planet: {mars.Name}, Mass: {mars.Mass} kg, Radius: {mars.Radius} km, Distance from Sun: {mars.DistanceFromSun} million km");
        Console.WriteLine($"Planet: {jupiter.Name}, Mass: {jupiter.Mass} kg, Radius: {jupiter.Radius} km, Distance from Sun: {jupiter.DistanceFromSun} million km");

        // Демонстрация поведения
        earth.Rotate();
        mars.Revolve();
        jupiter.Rotate();

        // Проверка Singleton
        Console.WriteLine(earth == Earth.Instance ? "Earth is a Singleton." : "Earth is NOT a Singleton.");
        Console.WriteLine(mars == Mars.Instance ? "Mars is a Singleton." : "Mars is NOT a Singleton.");
        Console.WriteLine(jupiter == Jupiter.Instance ? "Jupiter is a Singleton." : "Jupiter is NOT a Singleton.");
    }
}