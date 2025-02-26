namespace DesignPatterns.CreationalDP.Factory;

public abstract class Logistics
{
    public abstract ITransport CreateTransport();
}