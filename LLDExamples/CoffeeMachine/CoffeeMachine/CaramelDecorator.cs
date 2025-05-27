namespace CoffeeMachine
{
    public class CaramelDecorator : BeverageDecorator
    {
        public CaramelDecorator(Beverage beverage) : base(beverage)
        {
        }
        
        public override string GetDescription() => beverage.GetDescription() + " with Caramel";

        public override double GetCost() => beverage.GetCost() + 5.0;
    }
}