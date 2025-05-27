namespace CoffeeMachine
{
    public class MilkDecorator : BeverageDecorator
    {
        public MilkDecorator(Beverage beverage) : base(beverage)
        {
        }
        
        public override string GetDescription() => beverage.GetDescription() + " with Milk";

        public override double GetCost() => beverage.GetCost() + 2.0;
    }
}