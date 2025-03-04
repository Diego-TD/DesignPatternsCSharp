namespace DesignPatterns.BehavioralDP.Observer
{
    // Subject class that maintains a list of observers and notifies them on state changes.
    public class WeatherStation
    {
        private List<IObserver> observers = new List<IObserver>();
        private double _temperature;

        public double Temperature
        {
            get { return _temperature; }
            set 
            { 
                _temperature = value;
                Console.WriteLine($"\nWeatherStation: New Temperature is {_temperature}°C");
                NotifyObservers();
            }
        }

        public void RegisterObserver(IObserver observer)
        {
            if (!observers.Contains(observer))
            {
                observers.Add(observer);
                Console.WriteLine($"{observer.GetType().Name} has been registered.");
            }
            else
            {
                Console.WriteLine($"{observer.GetType().Name} is already registered.");
            }
        }

        public void UnregisterObserver(IObserver observer)
        {
            if (observers.Remove(observer))
            {
                Console.WriteLine($"{observer.GetType().Name} has been unregistered.");
            }
            else
            {
                Console.WriteLine($"{observer.GetType().Name} was not registered.");
            }
        }

        public void NotifyObservers()
        {
            foreach (var observer in observers)
            {
                observer.Update(_temperature);
            }
        }
    }

    // Observer interface
    public interface IObserver
    {
        void Update(double temperature);
    }

    // Concrete Observer: Mobile Display
    public class MobileDisplay : IObserver
    {
        public void Update(double temperature)
        {
            Console.WriteLine($"MobileDisplay: Temperature updated to {temperature}°C");
        }
    }

    // Concrete Observer: Window Display
    public class WindowDisplay : IObserver
    {
        public void Update(double temperature)
        {
            Console.WriteLine($"WindowDisplay: Temperature updated to {temperature}°C");
        }
    }

    public class ObserverExample
    {
        public static void ObserverExampleMain()
        {
            Console.WriteLine("Observer Pattern Example: Weather Station\n");

            // Create the subject
            WeatherStation weatherStation = new WeatherStation();
            // Create observer instances
            MobileDisplay mobileDisplay = new MobileDisplay();
            WindowDisplay windowDisplay = new WindowDisplay();

            // Initially register both observers
            weatherStation.RegisterObserver(mobileDisplay);
            weatherStation.RegisterObserver(windowDisplay);

            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("\n--- Menu ---");
                Console.WriteLine("1: Update Temperature");
                Console.WriteLine("2: Register Mobile Display");
                Console.WriteLine("3: Unregister Mobile Display");
                Console.WriteLine("4: Register Window Display");
                Console.WriteLine("5: Unregister Window Display");
                Console.WriteLine("0: Exit");
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();
                
                switch (choice)
                {
                    case "1":
                        Console.Write("Enter new temperature: ");
                        if (double.TryParse(Console.ReadLine(), out double newTemp))
                        {
                            weatherStation.Temperature = newTemp;
                        }
                        else
                        {
                            Console.WriteLine("Invalid temperature input.");
                        }
                        break;
                    case "2":
                        weatherStation.RegisterObserver(mobileDisplay);
                        break;
                    case "3":
                        weatherStation.UnregisterObserver(mobileDisplay);
                        break;
                    case "4":
                        weatherStation.RegisterObserver(windowDisplay);
                        break;
                    case "5":
                        weatherStation.UnregisterObserver(windowDisplay);
                        break;
                    case "0":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice, please try again.");
                        break;
                }
            }
        }
    }
}