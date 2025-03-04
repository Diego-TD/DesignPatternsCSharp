namespace DesignPatterns.StructuralDP.Proxy
{
    // Subject interface: defines operations for both RealImage and ProxyImage.
    public interface IImage
    {
        void Display();
    }

    // Real subject: the actual object that does the heavy lifting (loading and displaying the image).
    public class RealImage : IImage
    {
        private string _filename;

        public RealImage(string filename)
        {
            _filename = filename;
            LoadFromDisk();
        }

        private void LoadFromDisk()
        {
            Console.WriteLine($"Loading image '{_filename}' from disk...");
        }

        public void Display()
        {
            Console.WriteLine($"Displaying image '{_filename}'.");
        }
    }

    // Proxy class: controls access to the RealImage and adds lazy loading.
    public class ProxyImage : IImage
    {
        private string _filename;
        private RealImage _realImage;

        public ProxyImage(string filename)
        {
            _filename = filename;
        }

        public void Display()
        {
            // Load the real image only when it's needed.
            if (_realImage == null)
            {
                _realImage = new RealImage(_filename);
            }
            _realImage.Display();
        }
    }

    public class ProxyExample
    {
        public static void ProxyExampleMain()
        {
            Console.WriteLine("Proxy Pattern Example: Image Viewer\n");

            // Create the proxy with the image filename.
            IImage image = new ProxyImage("test_image.jpg");

            Console.WriteLine("Proxy image created. The real image has not been loaded yet.\n");

            // When Display() is called for the first time, the real image is loaded.
            Console.WriteLine("First call to Display():");
            image.Display();
            Console.WriteLine();

            // Subsequent calls do not trigger loading from disk.
            Console.WriteLine("Second call to Display():");
            image.Display();

            Console.WriteLine("-----------------------------------------------");
        }
    }
}