namespace CoffeeMachine
{
    public class Espresso : Beverage
    {
        public override string GetDescription() => "Espresso";
        public override double GetCost() => 10.0;
    }
}