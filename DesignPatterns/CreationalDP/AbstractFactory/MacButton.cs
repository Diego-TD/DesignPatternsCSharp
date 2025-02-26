namespace DesignPatterns.CreationalDP.AbstractFactory;

public class MacButton : IButton
{
    public void Paint()
    {
        Console.WriteLine("Painting using Mac button");
    }
}