using DesignPatterns.CreationalDP.AbstractFactory;
using DesignPatterns.CreationalDP.Builder;
using DesignPatterns.CreationalDP.Factory;
using DesignPatterns.StructuralDP;
using DesignPatterns.StructuralDP.Bridge;
using DesignPatterns.StructuralDP.Facade;
using DesignPatterns.StructuralDP.Proxy;

bool flag = true;
while (flag)
{
   Console.WriteLine("Enter a number to select a pattern:\n" +
                     "0: Exit\n"+
                     "\nCreational Design Patterns:\n"+
                     "1: Factory method\n"+ //this
                     "2: Abstract factory method\n"+ //this
                     "3: Builder\n"+ //this
                     "4: Prototype (in progress)\n"+
                     "5: Singleton (in progress)\n"+
                     "\nStructural Design Patterns:\n"+
                     "6: Adapter\n"+ //this
                     "7: Bridge (in progress)\n"+
                     "8: Composite (in progress)\n"+
                     "9: Decorator (in progress)\n"+
                     "10: Facade\n"+ //this
                     "11: Flyweight (in progress)\n"+
                     "12: Proxy\n"+ // this
                     "\nBehavioral Design Patterns:\n"+
                     "13: Chain of responsibility (in progress)\n"+
                     "14: Command\n"+
                     "15: Iterator (in progress)\n"+
                     "16: Mediator (in progress)\n"+
                     "17: Memento (in progress)\n"+
                     "18: Observer\n"+
                     "19: State (in progress)\n"+
                     "20: Strategy\n"+
                     "21: Template method (in progress)\n"+
                     "22: Visitor (in progress)\n"+
                     "");

   bool validInput = false;
   var userInput = 0;
   try
   {
       userInput = Convert.ToInt32(Console.ReadLine());
       validInput = true;
   }
   catch (Exception e)
   {
       Console.WriteLine("Please enter a number between 1 and 21.\n" + e.Message + "\nPlease try again.");
   }

   if (validInput == false)
   {
       continue;
   }

   if (userInput < 0 || userInput > 22)
   {
       Console.WriteLine("Please enter a number between 0 and 22.\n");
       continue;
   }

   switch (userInput)
   {  
       case 0: flag = false; break;
       case 1: Factory.FactoryExample(); break;
       case 2: AbstractFactory.AbstractFactoryExample(); break;
       case 3: BuilderExample.BuilderExampleMain(); break;
       case 4: Console.WriteLine("Prototype (in progress)\n"); break;
       case 5: Console.WriteLine("Singleton (in progress)\n"); break;
       case 6: AdapterExample.AdapterExampleMain(); break;
       case 7: BridgeExample.BridgeExampleMain(); break;
       case 8: Console.WriteLine("Composite (in progress)\n"); break;
       case 9: Console.WriteLine("Decorator (in progress)\n"); break;
       case 10: FacadeClient.FacadeMain(); break;
       case 11: Console.WriteLine("Flyweight (in progress):\n"); break;
       case 12: ProxyExample.ProxyExampleMain(); break;
       case 13: Console.WriteLine("Chain of responsibility  (in progress)\n"); break;
       case 14: Console.WriteLine("Command:\n"); break;
       case 15: Console.WriteLine("Iterator (in progress)\n"); break;
       case 16: Console.WriteLine("Mediator (in progress)\n"); break;
       case 17: Console.WriteLine("Memento (in progress)\n"); break;
       case 18: Console.WriteLine("Observer:\n"); break;
       case 19: Console.WriteLine("State (in progress)\n"); break;
       case 20: Console.WriteLine("Strategy:\n"); break;
       case 21: Console.WriteLine("Template method (in progress)\n"); break;
       case 22: Console.WriteLine("Visitor (in progress)\n"); break;
   }
}
