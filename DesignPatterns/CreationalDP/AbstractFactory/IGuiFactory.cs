namespace DesignPatterns.CreationalDP.AbstractFactory;

public interface IGuiFactory
{
    public IButton CreateButton();
    public ICheckbox CreateCheckbox();
}