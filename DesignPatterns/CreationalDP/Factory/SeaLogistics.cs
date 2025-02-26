namespace DesignPatterns.CreationalDP.Factory;

public class SeaLogistics : Logistics
{
    public override ITransport CreateTransport()
    {
        return new Ship();
    }
}