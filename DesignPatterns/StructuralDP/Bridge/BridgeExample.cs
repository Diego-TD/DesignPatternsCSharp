namespace DesignPatterns.StructuralDP.Bridge
{
    // Implementor interface
    public interface IDevice
    {
        void TurnOn();
        void TurnOff();
        void SetVolume(int volume);
    }

    // Concrete Implementor: TV
    public class TV : IDevice
    {
        public void TurnOn()
        {
            Console.WriteLine("TV is turned on.");
        }

        public void TurnOff()
        {
            Console.WriteLine("TV is turned off.");
        }

        public void SetVolume(int volume)
        {
            Console.WriteLine($"TV volume set to {volume}.");
        }
    }

    // Concrete Implementor: Radio
    public class Radio : IDevice
    {
        public void TurnOn()
        {
            Console.WriteLine("Radio is turned on.");
        }

        public void TurnOff()
        {
            Console.WriteLine("Radio is turned off.");
        }

        public void SetVolume(int volume)
        {
            Console.WriteLine($"Radio volume set to {volume}.");
        }
    }

    // Abstraction
    public abstract class RemoteControl
    {
        protected IDevice _device;

        protected RemoteControl(IDevice device)
        {
            _device = device;
        }

        public virtual void TurnOn()
        {
            _device.TurnOn();
        }

        public virtual void TurnOff()
        {
            _device.TurnOff();
        }

        // Abstract method to set a channel, which is independent of the device
        public abstract void SetChannel(int channel);
    }

    // Refined Abstraction
    public class AdvancedRemoteControl : RemoteControl
    {
        public AdvancedRemoteControl(IDevice device) : base(device)
        {
        }

        // SetChannel is implemented in the abstraction as it's not supported by IDevice
        public override void SetChannel(int channel)
        {
            Console.WriteLine($"Channel set to {channel}.");
        }

        // Additional functionality provided by the refined abstraction
        public void AdjustVolume(int volume)
        {
            _device.SetVolume(volume);
        }
    }

    public class BridgeExample
    {
        public static void BridgeExampleMain()
        {
            Console.WriteLine("Bridge Pattern Example: Remote Control for Devices\n");

            // Using a TV device with an advanced remote control
            IDevice tv = new TV();
            RemoteControl remoteForTV = new AdvancedRemoteControl(tv);
            remoteForTV.TurnOn();
            remoteForTV.SetChannel(5);
            ((AdvancedRemoteControl)remoteForTV).AdjustVolume(10);
            remoteForTV.TurnOff();

            Console.WriteLine();

            // Using a Radio device with an advanced remote control
            IDevice radio = new Radio();
            RemoteControl remoteForRadio = new AdvancedRemoteControl(radio);
            remoteForRadio.TurnOn();
            remoteForRadio.SetChannel(3);
            ((AdvancedRemoteControl)remoteForRadio).AdjustVolume(5);
            remoteForRadio.TurnOff();
        }
    }
}