# Different Classes

## Interface
- An interface defines a contract — it declares methods, properties, events, or indexers that implementing classes must provide.

- It contains no implementation (except in recent C# versions where default implementations are possible, but conceptually it’s just a contract).

- A class or struct that implements an interface must implement all its members.

- Interfaces support multiple inheritance of behavior.

```csharp
public interface IAnimal
{
    void MakeSound();
}
```

## Abstract Class
- An abstract class is a class that cannot be instantiated directly.

- It can contain both abstract members (without implementation) and concrete members (with implementation).

- Abstract members must be overridden in derived concrete classes.

- Abstract classes are used to provide a common base with shared code and common interface.

- Supports single inheritance only.

```csharp
public abstract class AnimalBase
{
    public abstract void Eat();  // Must be implemented by subclasses

    public void Sleep()          // Concrete method with implementation
    {
        Console.WriteLine("Sleeping...");
    }
}

```

## Concrete Class
- A concrete class is a normal class that can be instantiated.

- It provides implementation for all inherited abstract members or interface members.

- Can inherit from one class (abstract or concrete) and implement multiple interfaces.

- Represents real objects in your program.

```csharp
public class Dog : AnimalBase, IAnimal
{
    public override void Eat()
    {
        Console.WriteLine("Dog is eating.");
    }

    public void MakeSound()
    {
        Console.WriteLine("Woof! Woof!");
    }
}
```

## Comparison
| Concept        | Can Instantiate? | Contains Implementation?          | Supports Multiple Inheritance?          | Usage                       |
| -------------- | ---------------- | --------------------------------- | --------------------------------------- | --------------------------- |
| Interface      | No               | No (only declarations)            | Yes                                     | Define contract for classes |
| Abstract Class | No               | Yes (abstract + concrete members) | No                                      | Base class with shared code |
| Concrete Class | Yes              | Yes                               | Inherits one class, multiple interfaces | Actual usable class         |
