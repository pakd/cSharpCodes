# Lock Example

| Modifier   | Purpose                                                 |
| ---------- | ------------------------------------------------------- |
| `private`  | Limits access to prevent interference                   |
| `static`   | Ensures one lock across all instances (for static data) |
| `readonly` | Prevents reassignment after initialization              |


- **private** restricts access to the object so that it can only be used within the class where it's defined. This helps prevent external code from accessing or locking on the same object, which could lead to unexpected behavior or deadlocks.

- **static** means the object belongs to the class itself rather than to any instance of the class. This is important when the code being protected by the lock is also static, such as a static method or static field. It ensures all threads share the same lock.

- **readonly** ensures that the reference to the object cannot be changed after it is initialized. This is crucial for thread safety, because if the lock object were reassigned after some threads had already started using it, synchronization would break down.
# Example 

```csharp

using System;

class Program
{
    private static readonly object lockObject = new object();

    static void Main()
    {
        Console.WriteLine("Before lock");

        lock (lockObject)
        {
            Console.WriteLine("Inside locked section");
        }

        Console.WriteLine("After lock");
    }
}

```