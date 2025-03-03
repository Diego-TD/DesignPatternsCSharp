namespace DesignPatterns.StructuralDP;

public class AdapterExample
{
    // The target interface expected by the new system
    public interface IPaymentProcessor
    {
        void ProcessPayment(decimal amount);
    }

    // A legacy payment gateway with a different interface
    public class LegacyPaymentGateway
    {
        // Legacy system accepts a payment amount as a double
        public void SendPayment(double amountInDouble)
        {
            Console.WriteLine($"LegacyPaymentGateway: Processing payment of {amountInDouble:C} using the legacy system.");
        }
    }

    // The Adapter class converts calls from IPaymentProcessor to LegacyPaymentGateway
    public class PaymentProcessorAdapter : IPaymentProcessor
    {
        private readonly LegacyPaymentGateway _legacyPaymentGateway;

        public PaymentProcessorAdapter(LegacyPaymentGateway legacyPaymentGateway)
        {
            _legacyPaymentGateway = legacyPaymentGateway;
        }

        public void ProcessPayment(decimal amount)
        {
            // Convert the decimal amount to double, as expected by the legacy system
            double amountDouble = (double)amount;
            Console.WriteLine("PaymentProcessorAdapter: Converting payment request for the legacy system.");
            _legacyPaymentGateway.SendPayment(amountDouble);
        }
    }
        
    public static void AdapterExampleMain()
    {
        Console.WriteLine("Real World Adapter Pattern Example: Payment Processing");

        // Instantiate the legacy payment gateway
        LegacyPaymentGateway legacyGateway = new LegacyPaymentGateway();
        // Use the adapter to bridge the new interface with the legacy system
        IPaymentProcessor paymentProcessor = new PaymentProcessorAdapter(legacyGateway);

        // Simulate processing a payment using the new interface
        decimal paymentAmount = 100.50m;
        Console.WriteLine($"Client: Requesting payment processing for {paymentAmount:C}");
        paymentProcessor.ProcessPayment(paymentAmount);
    }    
}

