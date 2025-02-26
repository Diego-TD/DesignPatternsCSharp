namespace DesignPatterns.CreationalDP.Factory;

public class Truck : ITransport
{
    public Truck()
    {
        
    }

    public void Deliver()
    {
        Console.WriteLine("Delivered by Truck");
    }
}