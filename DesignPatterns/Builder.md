# Builder Pattern
The Builder pattern is a creational pattern used to construct complex objects step-by-step. It separates the construction of a complex object from its representation so that the same construction process can create different representations.

# Example
```csharp

public class Car
{
    public string Engine { get; set; }
    public string Color { get; set; }
    public string Transmission { get; set; }
    public bool HasGPS { get; set; }

    public override string ToString()
    {
        return $"Engine: {Engine}, Color: {Color}, Transmission: {Transmission}, GPS: {(HasGPS ? "Yes" : "No")}";
    }
}

public class CarBuilder
{
    private Car car = new Car();

    public CarBuilder SetEngine(string engine)
    {
        car.Engine = engine;
        return this;
    }

    public CarBuilder SetColor(string color)
    {
        car.Color = color;
        return this;
    }

    public CarBuilder SetTransmission(string transmission)
    {
        car.Transmission = transmission;
        return this;
    }

    public CarBuilder AddGPS(bool hasGPS = true)
    {
        car.HasGPS = hasGPS;
        return this;
    }

    public Car Build()
    {
        return car;
    }
}

class Program
{
    static void Main()
    {
        Car sportsCar = new CarBuilder()
            .SetEngine("V8")
            .SetColor("Red")
            .SetTransmission("Manual")
            .AddGPS()
            .Build();

        Car cityCar = new CarBuilder()
            .SetEngine("Electric")
            .SetColor("White")
            .SetTransmission("Automatic")
            .AddGPS(false)
            .Build();

        Console.WriteLine("Sports Car: " + sportsCar);
        Console.WriteLine("City Car: " + cityCar);
    }
}

```

# Reference
1. https://www.youtube.com/watch?v=MaY_MDdWkQw