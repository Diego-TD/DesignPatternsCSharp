using System.Net.Mail;

namespace DesignPatterns.CreationalDP.Factory;

public interface ITransport
{
    public void Deliver();
}