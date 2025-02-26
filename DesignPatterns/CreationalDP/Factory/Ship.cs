namespace DesignPatterns.CreationalDP.Factory;

public class Ship : ITransport
{
    public Ship()
    {
        
    }
    
    public void Deliver()
    {
        Console.WriteLine("Delivered by Ship");
    }
}