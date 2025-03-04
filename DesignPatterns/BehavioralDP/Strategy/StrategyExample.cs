namespace DesignPatterns.BehavioralDP.Strategy
{
    // The strategy interface declares a method for calculating the discounted price.
    public interface IDiscountStrategy
    {
        decimal CalculateDiscountedPrice(decimal originalPrice);
    }

    // Concrete strategy: No discount applied.
    public class NoDiscountStrategy : IDiscountStrategy
    {
        public decimal CalculateDiscountedPrice(decimal originalPrice)
        {
            return originalPrice;
        }
    }

    // Concrete strategy: Applies a percentage-based discount.
    public class PercentageDiscountStrategy : IDiscountStrategy
    {
        private readonly decimal _percentage;

        public PercentageDiscountStrategy(decimal percentage)
        {
            _percentage = percentage;
        }

        public decimal CalculateDiscountedPrice(decimal originalPrice)
        {
            return originalPrice - (originalPrice * _percentage / 100);
        }
    }

    // Concrete strategy: Applies a fixed discount amount.
    public class FixedDiscountStrategy : IDiscountStrategy
    {
        private readonly decimal _discountAmount;

        public FixedDiscountStrategy(decimal discountAmount)
        {
            _discountAmount = discountAmount;
        }

        public decimal CalculateDiscountedPrice(decimal originalPrice)
        {
            return originalPrice - _discountAmount;
        }
    }

    // Context class: The shopping cart which uses a discount strategy.
    public class ShoppingCart
    {
        public decimal TotalPrice { get; set; }
        public IDiscountStrategy DiscountStrategy { get; set; }

        public ShoppingCart(decimal totalPrice, IDiscountStrategy discountStrategy)
        {
            TotalPrice = totalPrice;
            DiscountStrategy = discountStrategy;
        }

        public decimal GetFinalPrice()
        {
            return DiscountStrategy.CalculateDiscountedPrice(TotalPrice);
        }
    }

    public class StrategyExample
    {
        public static void StrategyExampleMain()
        {
            bool exit = false;

            while (!exit)
            {
                try
                {
                    // Prompt user for the original price.
                    Console.Write("Enter the original price (or type 0 to exit): ");
                    if (!decimal.TryParse(Console.ReadLine(), out decimal originalPrice))
                    {
                        Console.WriteLine("Invalid price. Please try again.\n");
                        continue;
                    }

                    if (originalPrice == 0)
                    {
                        exit = true;
                        continue;
                    }

                    // Display discount options.
                    Console.WriteLine("\nSelect a discount strategy:");
                    Console.WriteLine("1: No Discount");
                    Console.WriteLine("2: Percentage Discount");
                    Console.WriteLine("3: Fixed Discount");
                    Console.Write("Enter your choice (1, 2, or 3): ");
                    string discountChoice = Console.ReadLine();

                    IDiscountStrategy discountStrategy;

                    switch (discountChoice)
                    {
                        case "1":
                            discountStrategy = new NoDiscountStrategy();
                            break;
                        case "2":
                            Console.Write("Enter discount percentage (e.g., 15 for 15%): ");
                            if (!decimal.TryParse(Console.ReadLine(), out decimal percentage))
                            {
                                Console.WriteLine("Invalid percentage. Defaulting to No Discount.\n");
                                discountStrategy = new NoDiscountStrategy();
                            }
                            else
                            {
                                discountStrategy = new PercentageDiscountStrategy(percentage);
                            }
                            break;
                        case "3":
                            Console.Write("Enter fixed discount amount: ");
                            if (!decimal.TryParse(Console.ReadLine(), out decimal fixedAmount))
                            {
                                Console.WriteLine("Invalid amount. Defaulting to No Discount.\n");
                                discountStrategy = new NoDiscountStrategy();
                            }
                            else
                            {
                                discountStrategy = new FixedDiscountStrategy(fixedAmount);
                            }
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Defaulting to No Discount.\n");
                            discountStrategy = new NoDiscountStrategy();
                            break;
                    }

                    // Create the shopping cart and calculate the final price.
                    ShoppingCart cart = new ShoppingCart(originalPrice, discountStrategy);
                    Console.WriteLine($"\nFinal Price after discount: {cart.GetFinalPrice():C}\n");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}\n");
                }
            }

            Console.WriteLine("Exiting the program. Goodbye!");
        }
    }
}