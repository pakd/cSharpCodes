# Field vs Properties

## Field
- Fields are variables declared directly in a class or struct.

- They hold data/state.

- Usually declared with access modifiers like private, public, etc.

- Accessing fields directly exposes the internal representation, which can be unsafe or inflexible.

- Fields don’t have logic for getting or setting values (unless manually wrapped).

```csharp
public class Person
{
    public string name;   // field
}

```

## Properties
- Properties are special methods called accessors that provide controlled access to fields.

- They look like fields from outside but can have logic in their get and/or set accessors.

- Allow validation, lazy loading, encapsulation, and can be read-only or write-only.

- Help to protect and control how data is accessed or modified.

- Provide a clean, flexible way to expose data publicly.

```csharp
public class Person
{
    private string _name;    // private field

    public string Name       // property
    {
        get { return _name; }
        set 
        { 
            if (!string.IsNullOrEmpty(value))
                _name = value; 
        }
    }
}
```

## Comparison
| Aspect           | Field                         | Property                           |
| ---------------- | ----------------------------- | ---------------------------------- |
| What it is       | Data storage variable         | Accessor methods (get/set)         |
| Access control   | Direct, less controlled       | Controlled (can add validation)    |
| Syntax           | Simple variable               | Special syntax with get/set blocks |
| Encapsulation    | Poor (exposes internal state) | Good (can protect internal state)  |
| Usage            | For internal data storage     | For exposing data publicly safely  |
| Can be computed? | No                            | Yes (can compute value on access)  |
