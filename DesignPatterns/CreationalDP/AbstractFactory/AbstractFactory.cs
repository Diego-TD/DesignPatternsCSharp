namespace DesignPatterns.CreationalDP.AbstractFactory;

public class AbstractFactory
{   
    private static void WindowsExample()
    {
        IGuiFactory factory = new WinFactory();
        factory.CreateButton().Paint();
        factory.CreateCheckbox().Select();
    }
    
    private static void MacExample()
    {
        IGuiFactory factory = new MacFactory();
        factory.CreateButton().Paint();
        factory.CreateCheckbox().Select();
    }
    
    public static void AbstractFactoryExample()
    {   
        bool flag = true;
        while (flag)
        {
            // client code
            Console.WriteLine("--------------------------------------------------------\n" +
                              "Abstract Factory Example\n" +
                              "Select the OS you want to use:\n" +
                              "0: Exit\n" +
                              "1: Windows\n" +
                              "2: Mac OS\n");
     

            bool validInput = false;
            var userInput = 0;
            try
            {
                userInput = Convert.ToInt32(Console.ReadLine());
                validInput = true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Please enter a number between 0 and 2.\n" + e.Message + "\nPlease try again.");
            }

            if (validInput == false)
            {
                continue;
            }

            if (userInput < 0 || userInput > 2)
            {
                Console.WriteLine("Please enter a number between 0 and 2.\n");
                continue;
            }

            switch (userInput)
            {
                case 0: flag = false; break;
                case 1: WindowsExample(); break;
                case 2: MacExample(); break;
            }
        }
    }}