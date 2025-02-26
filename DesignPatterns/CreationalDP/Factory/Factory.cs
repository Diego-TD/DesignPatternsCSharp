namespace DesignPatterns.CreationalDP.Factory;

public class Factory
{
    public static void RoadLogisticsExample()
    {
        Logistics logistics = new RoadLogistics();
        logistics.CreateTransport().Deliver();
    }
    
    public static void SeaLogisticsExample()
    {
        Logistics logistics = new SeaLogistics();
        logistics.CreateTransport().Deliver();
    }

    public static void FactoryExample()
    {   
        bool flag = true;
        while (flag)
        {
            // client code
            Console.WriteLine("--------------------------------------------------------\n" +
                              "Factory Example\n" +
                              "Select the type of transport you want to use:\n" +
                              "0: Exit\n" +
                              "1: Truck\n" +
                              "2: Ship\n");
     

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
                case 1: RoadLogisticsExample(); break;
                case 2: SeaLogisticsExample(); break;
            }
        }
    }
}