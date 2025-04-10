namespace Lab3;

public class Taxi : IPassengerTransport
{
    private double _revenue;
    private double _ratePerKm;
    private double _distance;

    public string TransportName => "Taxi";
    public double RatePerKm => _ratePerKm;
    public Taxi()
    {
        _ratePerKm = 20.0;
        _distance = 0;
        _revenue = 0;
        Console.WriteLine($"{TransportName} created");
    }

    public bool StartRoute(string[] args)
    {
        Reset();
        Console.WriteLine("Enter the distance traveled in kilometers:");
        foreach (string arg in args)
        {
            if (double.TryParse(arg, out double distance))
            {
                _distance = distance;
                Console.WriteLine($"Distance recorded: {_distance} km");
                break;
            }
            Console.WriteLine("Invalid input. Try again.");             
        }
        Console.WriteLine($"The route is over. Revenue: {GetRevenuePerRoute()} rubles");
        return true;       
    }

    public int GetRevenuePerRoute()
    {
        _revenue = _distance * _ratePerKm;
        return (int)_revenue;
    }

    public void Reset()
    {
        _distance = 0;
        _revenue = 0;
    }
}