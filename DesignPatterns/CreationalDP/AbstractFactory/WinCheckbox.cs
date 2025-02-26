namespace DesignPatterns.CreationalDP.AbstractFactory;

public class WinCheckbox : ICheckbox
{
    public void Select()
    {
        Console.WriteLine("Select using Windows checkbox");
    }
}