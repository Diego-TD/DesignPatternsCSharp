namespace DesignPatterns.CreationalDP.AbstractFactory;

public class WinFactory : IGuiFactory
{
    public IButton CreateButton()
    {
        return new WinButton();
    }

    public ICheckbox CreateCheckbox()
    {
        return new WinCheckbox();
    }
}