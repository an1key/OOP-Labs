using System;
using System.Collections.Generic;
using Lab3;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Passenger Transport Revenue Calculator!");
        Console.WriteLine("Choose a transport type:");

       
        var transports = new List<IPassengerTransport>
        {
            new Bus(),
            new Taxi(),
            new Train()
        };


        for (int i = 0; i < transports.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {transports[i].TransportName}");
        }

        Console.Write("Enter your choice (1, 2, or 3): ");
        string choice = Console.ReadLine();

        if (int.TryParse(choice, out int transportIndex) &&
            transportIndex >= 1 &&
            transportIndex <= transports.Count)
        {
            var selectedTransport = transports[transportIndex - 1];
            Console.WriteLine($"You selected: {selectedTransport.TransportName}");
            Console.WriteLine();
            
            
            if (selectedTransport.StartRoute([]))
            {
                Console.WriteLine($"The route for {selectedTransport.TransportName} has been completed.");
                Console.WriteLine($"Total revenue: {selectedTransport.GetRevenuePerRoute()} rubles.");
            }
            else
            {
                Console.WriteLine("The route was not completed successfully.");
            }
        }
        else
        {
            Console.WriteLine("Invalid choice. Please restart the program and select a valid transport type.");
        }

        Console.WriteLine("Thank you for using the Passenger Transport Revenue Calculator!");
    }
}