# Coffee Machine
- Coffee Machine is classical example of Decorator pattern.
- Decorator is structural design pattern
- lets you attach new behaviors to an object by placing this object inside a special wrapper that contains these behaviors.

## Requirements
- Order Bevareges.
- Pick add-ons for the Beverages.
- Pay only for the add-on you want.
- Should have flexibility to on-board new beverages without affecting existing ones

## Entities
- Beverage - base abstract class having two abstract methods: GetDescription and GetCost
- Cappuccino & Espresso - sub classes of Beverage
- BeverageDecorator - abstract classes, has Beverage Object - still abstract methods GetDescription and GetCost
- MilkDecorator and CaramelDecorator - concrete classes of BeverageDecorator

### Disclaimer:
This example is primarily intended to demonstrate the Decorator Design Pattern, rather than to serve as a complete CoffeeHouse application. In a full implementation, you would typically include additional classes for user input, payment methods, and other features. For a comprehensive solution, it's recommended to refer to a more complete example.

## Reference
1. https://www.youtube.com/watch?v=3rI5n2hwz2o
2. Chat GPT