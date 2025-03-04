namespace DesignPatterns.BehavioralDP.Command
{
    // Command interface declaring a method for executing a command.
    public interface ICommand
    {
        void Execute();
    }

    // Receiver class: knows how to perform the operation.
    public class Light
    {
        public void TurnOn()
        {
            Console.WriteLine("Light is turned ON.");
        }

        public void TurnOff()
        {
            Console.WriteLine("Light is turned OFF.");
        }
    }

    // Concrete Command to turn on the light.
    public class LightOnCommand : ICommand
    {
        private readonly Light _light;

        public LightOnCommand(Light light)
        {
            _light = light;
        }

        public void Execute()
        {
            _light.TurnOn();
        }
    }

    // Concrete Command to turn off the light.
    public class LightOffCommand : ICommand
    {
        private readonly Light _light;

        public LightOffCommand(Light light)
        {
            _light = light;
        }

        public void Execute()
        {
            _light.TurnOff();
        }
    }

    // Invoker class: asks the command to carry out the request.
    public class RemoteControl
    {
        private ICommand _command;

        // Allows setting of the command to be executed.
        public void SetCommand(ICommand command)
        {
            _command = command;
        }

        // Executes the command.
        public void PressButton()
        {
            _command?.Execute();
        }
    }

    public class CommandExample
    {
        public static void CommandExampleMain()
        {
            // Create the receiver.
            Light livingRoomLight = new Light();

            // Create command objects for turning the light on and off.
            ICommand lightOnCommand = new LightOnCommand(livingRoomLight);
            ICommand lightOffCommand = new LightOffCommand(livingRoomLight);

            // Create the invoker.
            RemoteControl remoteControl = new RemoteControl();

            // Simulate turning the light on.
            Console.WriteLine("Remote control: Turning the light ON.");
            remoteControl.SetCommand(lightOnCommand);
            remoteControl.PressButton();

            // Simulate turning the light off.
            Console.WriteLine("Remote control: Turning the light OFF.");
            remoteControl.SetCommand(lightOffCommand);
            remoteControl.PressButton();
            
            Console.WriteLine("\n-----------------------------------------\n");
        }
    }
}