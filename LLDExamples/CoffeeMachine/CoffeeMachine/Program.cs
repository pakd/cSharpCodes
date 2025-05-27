using System;

namespace CoffeeMachine
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Beverage beverage = new Espresso();
            Console.WriteLine(beverage.GetDescription());
            Console.WriteLine(beverage.GetCost());

            beverage = new MilkDecorator(beverage);
            Console.WriteLine("after decorating with milk");
            Console.WriteLine(beverage.GetDescription());
            Console.WriteLine(beverage.GetCost());

            beverage = new CaramelDecorator(beverage);
            beverage = new CaramelDecorator(beverage);
            Console.WriteLine("after decorating with double caramel");
            Console.WriteLine(beverage.GetDescription());
            Console.WriteLine(beverage.GetCost());
        }
    }
}
