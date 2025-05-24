# Factory Pattern
The Factory Design Pattern is a creational design pattern that provides a way to create objects without exposing the instantiation logic to the client. Instead of calling a constructor directly, the client calls a factory method that returns an object.

# Example
```csharp

// product interface
public interface IShape
{
    void Draw();
}

// concrete products
public class Circle : IShape
{
    public void Draw()
    {
        Console.WriteLine("Drawing a Circle");
    }
}

public class Rectangle : IShape
{
    public void Draw()
    {
        Console.WriteLine("Drawing a Rectangle");
    }
}

// factory class
public class ShapeFactory
{
    public IShape GetShape(string shapeType)
    {
        if (string.IsNullOrWhiteSpace(shapeType))
            return null;

        switch (shapeType.ToLower())
        {
            case "circle":
                return new Circle();
            case "rectangle":
                return new Rectangle();
            default:
                return null;
        }
    }
}

// client code
class Program
{
    static void Main(string[] args)
    {
        ShapeFactory factory = new ShapeFactory();

        IShape shape1 = factory.GetShape("circle");
        shape1?.Draw();

        IShape shape2 = factory.GetShape("rectangle");
        shape2?.Draw();
    }
}
```

Example without switch:
```csharp

// product interface
public interface IShape
{
    void Draw();
}

// concrete products
public class Circle : IShape
{
    public void Draw()
    {
        Console.WriteLine("Drawing a Circle");
    }
}

public class Rectangle : IShape
{
    public void Draw()
    {
        Console.WriteLine("Drawing a Rectangle");
    }
}

// factory
public abstract class ShapeFactory
{
    public abstract IShape CreateShape();
}

public class CircleFactory : ShapeFactory
{
    public override IShape CreateShape()
    {
        return new Circle();
    }
}

public class RectangleFactory : ShapeFactory
{
    public override IShape CreateShape()
    {
        return new Rectangle();
    }
}

// client code
class Program
{
    static void Main(string[] args)
    {
        ShapeFactory factory1 = new CircleFactory();
        IShape shape1 = factory1.CreateShape();
        shape1.Draw();

        ShapeFactory factory2 = new RectangleFactory();
        IShape shape2 = factory2.CreateShape();
        shape2.Draw();
    }
}

```

# Reference
1. https://www.youtube.com/watch?v=EdFq_JIThqM