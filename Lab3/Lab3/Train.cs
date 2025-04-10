namespace Lab3;

public class Train : IPassengerTransport
{
    private int _revenue;
    private int _payPerPassenger;
    private int _discountedPayPerPassenger;
    private int _regularPassengers;
    private int _discountedPassengers;

    public string TransportName => "Train";
    public int RegularPayPerPassenger => _payPerPassenger;
    public int DiscountedPayPerPassenger => _discountedPayPerPassenger;
    public Train()
    {
        _payPerPassenger = 50;
        _discountedPayPerPassenger = 25;
        Reset();
        Console.WriteLine($"{TransportName} created");
    }

    public bool StartRoute(string[] args)
    {
        Reset();
        Queue<int> passList = new Queue<int>();
        foreach (string arg in args)
        {
            if (int.TryParse(arg, out int passengers))
            {
                passList.Enqueue(passengers);
            }
            else
            {
                Console.WriteLine("Invalid input. Try again");
            }
        }

        _regularPassengers = passList.Dequeue();
        _discountedPassengers = passList.Dequeue();
        
        Console.WriteLine($"The route is over. Revenue: {GetRevenuePerRoute()} rubles");
        return true;
    }

    public int GetRevenuePerRoute()
    {
        _revenue = (_regularPassengers * _payPerPassenger) + (_discountedPassengers * _discountedPayPerPassenger);
        return _revenue;
    }

    public void Reset()
    {
        _regularPassengers = 0;
        _discountedPassengers = 0;
        _revenue = 0;
    }
}