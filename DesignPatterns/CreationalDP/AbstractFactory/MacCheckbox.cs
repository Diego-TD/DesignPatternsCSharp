namespace DesignPatterns.CreationalDP.AbstractFactory;

public class MacCheckbox : ICheckbox
{
    public void Select()
    {
        Console.WriteLine("Select using Mac checkbox");
    }
}