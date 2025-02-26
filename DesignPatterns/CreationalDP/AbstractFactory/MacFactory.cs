namespace DesignPatterns.CreationalDP.AbstractFactory;

public class MacFactory : IGuiFactory
{
    public IButton CreateButton()
    {
        return new MacButton();
    }

    public ICheckbox CreateCheckbox()
    {
        return new MacCheckbox();
    }
}