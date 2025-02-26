namespace DesignPatterns.CreationalDP.AbstractFactory;

public class WinButton : IButton
{
    public void Paint()
    {
        Console.WriteLine("Painting using Windows Button");
    }
}