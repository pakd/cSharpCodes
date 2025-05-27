namespace CoffeeMachine
{
    public abstract class BeverageDecorator : Beverage
    {
        protected Beverage beverage;

        public BeverageDecorator(Beverage beverage)
        {
            this.beverage = beverage;
        }
        
        public override abstract string GetDescription();
        public override abstract double GetCost();
    }
}

