namespace Lab3;

public class Bus : IPassengerTransport
{
    private int _revenue;
    private int _payPerPassenger;
    private int _currentPassengers;

    public string TransportName => "Bus";
    public int PayPerPassenger => _payPerPassenger;
    public int CurrentPassengers => _currentPassengers;

    public Bus()
    {
        _payPerPassenger = 35;
        _revenue = 0;
        _currentPassengers = 0;
        Console.WriteLine($"{TransportName} created");
    }

    public bool StartRoute()
    {
        Reset(); // Сбрасываем перед новым маршрутом
        Console.WriteLine("You started the route. Enter the number of passengers boarded or type 'end' to finish the route:");

        string input;
        while ((input = Console.ReadLine()) != "end")
        {
            Console.WriteLine("The bus stopped on the station. Enter the number of passengers boarded or type 'end' to finish the route:");
            if (int.TryParse(input, out int newPassengers))
            {
                _currentPassengers += newPassengers;
                Console.WriteLine($"Current count of passengers: {_currentPassengers}");
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number or 'end'.");
            }
        }

        Console.WriteLine($"The route is over. Revenue: {GetRevenuePerRoute()} rubles");
        return true;
    }

    public int GetRevenuePerRoute()
    {
        _revenue = _currentPassengers * _payPerPassenger;
        return _revenue;
    }

    public void Reset()
    {
        _currentPassengers = 0;
        _revenue = 0;
    }
}