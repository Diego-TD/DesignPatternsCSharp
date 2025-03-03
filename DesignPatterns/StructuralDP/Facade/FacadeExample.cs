using System;

namespace DesignPatterns.StructuralDP.Facade
{
    // Subsystem A with its own interface
    public class SubsystemA
    {
        public string OperationA1()
        {
            return "SubsystemA: Initialization complete.";
        }

        public string OperationA2()
        {
            return "SubsystemA: Action executed.";
        }
    }

    // Subsystem B with its own interface
    public class SubsystemB
    {
        public string OperationB1()
        {
            return "SubsystemB: Preparation complete.";
        }

        public string OperationB2()
        {
            return "SubsystemB: Action executed.";
        }
    }

    // Facade class that simplifies the interaction with the subsystems
    public class FacadeExample
    {
        private readonly SubsystemA _subsystemA;
        private readonly SubsystemB _subsystemB;

        public FacadeExample(SubsystemA subsystemA, SubsystemB subsystemB)
        {
            _subsystemA = subsystemA;
            _subsystemB = subsystemB;
        }

        // This method provides a simplified interface to the client,
        // orchestrating the calls to the subsystems.
        public void Operation()
        {
            Console.WriteLine("Facade initializes subsystems:");
            Console.WriteLine(_subsystemA.OperationA1());
            Console.WriteLine(_subsystemB.OperationB1());

            Console.WriteLine("\nFacade orders subsystems to perform the action:");
            Console.WriteLine(_subsystemA.OperationA2());
            Console.WriteLine(_subsystemB.OperationB2());
        }
    }

    // Client code that uses the Facade to interact with the subsystems
    public class FacadeClient
    {
        public static void FacadeMain()
        {
            // Create instances of the subsystems.
            SubsystemA subsystemA = new SubsystemA();
            SubsystemB subsystemB = new SubsystemB();

            // Create the Facade with the subsystem instances.
            FacadeExample facade = new FacadeExample(subsystemA, subsystemB);

            // The client uses the Facade's simple interface.
            facade.Operation();
        }
    }
}