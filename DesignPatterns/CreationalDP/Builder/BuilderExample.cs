namespace DesignPatterns.CreationalDP.Builder
{
    // The complex object (Product) to be built.
    public class House
    {
        public string Basement { get; set; }
        public string Structure { get; set; }
        public string Roof { get; set; }
        public string Interior { get; set; }

        public override string ToString()
        {
            return $"Basement: {Basement}, Structure: {Structure}, Roof: {Roof}, Interior: {Interior}";
        }
    }

    // The Builder interface defines the steps for building the product.
    public interface IHouseBuilder
    {
        void BuildBasement();
        void BuildStructure();
        void BuildRoof();
        void BuildInterior();
        House GetHouse();
    }

    // Concrete Builder 1: Builds an Igloo House.
    public class IglooHouseBuilder : IHouseBuilder
    {
        private House house = new House();

        public void BuildBasement() { house.Basement = "Ice Basement"; }
        public void BuildStructure() { house.Structure = "Ice Blocks Structure"; }
        public void BuildRoof() { house.Roof = "Ice Roof"; }
        public void BuildInterior() { house.Interior = "Ice Interior"; }
        public House GetHouse() { return house; }
    }

    // Concrete Builder 2: Builds a Wooden House.
    public class WoodenHouseBuilder : IHouseBuilder
    {
        private House house = new House();

        public void BuildBasement() { house.Basement = "Concrete Basement"; }
        public void BuildStructure() { house.Structure = "Wood and Brick Structure"; }
        public void BuildRoof() { house.Roof = "Wooden Roof"; }
        public void BuildInterior() { house.Interior = "Modern Interior"; }
        public House GetHouse() { return house; }
    }

    // The Director class defines the order in which to call construction steps.
    public class HouseDirector
    {
        public void Construct(IHouseBuilder builder)
        {
            builder.BuildBasement();
            builder.BuildStructure();
            builder.BuildRoof();
            builder.BuildInterior();
        }
    }

    public class BuilderExample
    {
        private static void BuildIglooHouse()
        {
            IHouseBuilder builder = new IglooHouseBuilder();
            HouseDirector director = new HouseDirector();
            director.Construct(builder);
            House iglooHouse = builder.GetHouse();
            Console.WriteLine("Igloo House built:\n" + iglooHouse);
        }


        private static void BuildWoodenHouse()
        {
            IHouseBuilder builder = new WoodenHouseBuilder();
            HouseDirector director = new HouseDirector();
            director.Construct(builder);
            House woodenHouse = builder.GetHouse();
            Console.WriteLine("Wooden House built:\n" + woodenHouse);
        }

        public static void BuilderExampleMain()
        {
            bool flag = true;
            while (flag)
            {
                // Client code with a simple menu.
                Console.WriteLine("--------------------------------------------------------\n" +
                                  "Builder Pattern Example\n" +
                                  "Select the House you want to build:\n" +
                                  "0: Exit\n" +
                                  "1: Build Igloo House\n" +
                                  "2: Build Wooden House\n");

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

                if (!validInput)
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
                    case 0:
                        flag = false;
                        break;
                    case 1:
                        BuildIglooHouse();
                        break;
                    case 2:
                        BuildWoodenHouse();
                        break;
                }
            }
        }
    }
}
