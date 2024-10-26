namespace Lab3;

public class Bus : IPassengerTransport
{
    private int _revenue;
    private int _payPerPassenger;

    public int PayPerPassenger => _payPerPassenger;

    private int _currentPassengers;
    public Bus()
    {
        this._payPerPassenger = 35;
        this._revenue = 0;
        this._currentPassengers = 0;
        Console.WriteLine("Bus created");
    }

    public bool StartRoute()
    {
        _currentPassengers = 0;
        Console.WriteLine("You started the route. Enter the number of passengers boarded or type 'end' to finish the route");
        string input = Console.ReadLine();
        while (input != "end")
        {
            Console.WriteLine("The bus stopped on the station. Enter the number of passengers boarded or type 'end' to finish the route");
            try
            {
                _currentPassengers += int.Parse(input);
                Console.WriteLine("Current count of passengers: " + _currentPassengers);
            }
            catch (FormatException e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
            finally
            {
                input = Console.ReadLine();
            }
        }
        Console.WriteLine("The route is over. Revenue: " + GetRevenuePerRoute() + " rubles");
        return true;

    }

    public int GetRevenuePerRoute()
    {
        _revenue = _currentPassengers * _payPerPassenger;
        return _revenue;
    }
}