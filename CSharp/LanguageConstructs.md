# C# Revision Notes

## 1. Taking Input from User

### Read a single line of input
```csharp
string input = Console.ReadLine();
Console.WriteLine("You entered: " + input);
```

### Parse input to int / double
```csharp
int num = int.Parse(Console.ReadLine());       // Converts string to int
double d = double.Parse(Console.ReadLine());   // Converts string to double
```

### Safer parsing with `TryParse`
```csharp
if (int.TryParse(Console.ReadLine(), out int value))
{
    Console.WriteLine("Parsed int: " + value);
}
else
{
    Console.WriteLine("Invalid number");
}
```

### Read multiple space-separated integers
```csharp
// Learn 1. .Split() method 2. var keyword
var parts = Console.ReadLine().Split(' ');
List<int> numbers = new();

// See foreach syntax
foreach (var part in parts)
{
    int number = int.Parse(part);
    numbers.Add(number);
}

// See the syntax to get the count of elements in a list
for (int i = 0; i < numbers.Count; i++)
{
    Console.WriteLine(numbers[i]);
}
```

## 2. Sorting

### General principle for custom sorting
- The `.Sort()` method (on arrays or lists) expects a **comparer**:  
  a function `(x, y)` that returns:
  - `< 0` if `x` should come **before** `y`
  - `0` if they are **equal**
  - `> 0` if `x` should come **after** `y`

---

### Example: Sort array
```csharp
int[] arr = { 5, 2, 8, 1, 3 };
Array.Sort(arr);

foreach (int n in arr)
    Console.WriteLine(n);   // Output: 1 2 3 5 8
```

---

### Example: Sort list
```csharp
List<int> numbers = new() { 5, 2, 8, 1, 3 };
numbers.Sort();

foreach (int n in numbers)
    Console.WriteLine(n);   // Output: 1 2 3 5 8

// To sort in descending order, just call reverse function
numbers.Reverse();
```

---

### Example: Sort in descending order
```csharp
numbers.Sort((a, b) => b.CompareTo(a));

foreach (int n in numbers)
    Console.WriteLine(n);   // Output: 8 5 3 2 1
```

---

### Example: Sort list of objects by Age (using CompareTo)
```csharp
people.Sort((p1, p2) => p1.Age.CompareTo(p2.Age));
```

---

### Example: Sort list of objects by Age (C++-style if/else comparator)
```csharp
people.Sort((p1, p2) =>
{
    if (p1.Age < p2.Age) return -1;   // p1 comes before p2
    if (p1.Age > p2.Age) return 1;    // p1 comes after p2
    return 0;                         // equal
});
```

---

### Example: Multi-level sorting (Age, then Name length)
```csharp
people.Sort((p1, p2) =>
{
    if (p1.Age == p2.Age)
    {
        if (p1.Name.Length == p2.Name.Length) return 0;
        return (p1.Name.Length < p2.Name.Length) ? -1 : 1;
    }

    return (p1.Age < p2.Age) ? -1 : 1;
});
```

✅ **Rule of thumb**:  
- Use `CompareTo()` for concise sorting.  
- Use `if-else` style when you want full control (like in C++) or multi-criteria sorting.


## 3. Console Output

### Console.WriteLine
- Prints the text **with a newline at the end**.
- Next output starts on a **new line**.

```csharp
Console.WriteLine("Hello");
Console.WriteLine("World");
```

**Output:**
```
Hello
World
```

---

### Console.Write
- Prints the text **without a newline**.
- Next output continues on the **same line**.

```csharp
Console.Write("Hello ");
Console.Write("World");
```

**Output:**
```
Hello World
```

---

### String Interpolation (preferred modern style)
```csharp
string name = "Alice";
int age = 25;

Console.WriteLine($"Name: {name}, Age: {age}");
```

**Output:**
```
Name: Alice, Age: 25
```

---

### Format Strings (older style)
```csharp
string name = "Alice";
int age = 25;

Console.WriteLine("Name: {0}, Age: {1}", name, age);
```

## 4. Collections in C#

### List<T>
- Dynamic array (resizable).
```csharp
List<int> numbers = new();

// Add elements
numbers.Add(10);
numbers.AddRange(new int[] { 20, 30 });

// Access elements
int first = numbers[0];

// Remove elements
numbers.Remove(20);        // removes first occurrence of 20
numbers.RemoveAt(0);       // removes element at index 0
numbers.Clear();           // removes all elements

// Search
bool exists = numbers.Contains(30);
int index = numbers.IndexOf(30);

// Count
Console.WriteLine(numbers.Count);
```

---

### Dictionary<TKey, TValue>
- Key–value store (like map in C++).
```csharp
Dictionary<string, int> ages = new();

// Add elements
ages.Add("Alice", 25);
ages["Bob"] = 30;      // another way to insert/update

// Access elements
int aliceAge = ages["Alice"];

// Check existence
if (ages.ContainsKey("Charlie"))
    Console.WriteLine("Charlie exists");

// Remove element
ages.Remove("Alice");

// Iteration
foreach (var kvp in ages)
    Console.WriteLine($"{kvp.Key} → {kvp.Value}");
```

---

### HashSet<T>
- Stores **unique elements only**, no duplicates.
```csharp
HashSet<int> set = new();

// Add
set.Add(1);
set.Add(2);
set.Add(2);   // ignored

// Remove
set.Remove(1);

// Check
bool hasTwo = set.Contains(2);

// Iteration
foreach (var item in set)
    Console.WriteLine(item);
```

---

### BinarySearch (on List/Array)
- Works only on **sorted collections**.
```csharp
List<int> numbers = new() { 1, 3, 5, 7, 9 };
int index = numbers.BinarySearch(5);

if (index >= 0)
    Console.WriteLine($"Found at index {index}");
else
    Console.WriteLine("Not found");
```
- If not found, returns a **negative number** (`~insertionIndex`).

---

### Queue<T>
- FIFO (first in, first out).
```csharp
Queue<string> q = new();

// Enqueue
q.Enqueue("Alice");
q.Enqueue("Bob");

// Peek (front element without removing)
Console.WriteLine(q.Peek());   // Alice

// Dequeue
Console.WriteLine(q.Dequeue()); // removes Alice

// Count
Console.WriteLine(q.Count);
```

---

### Stack<T>
- LIFO (last in, first out).
```csharp
Stack<int> st = new();

// Push
st.Push(1);
st.Push(2);
st.Push(3);

// Peek (top element without removing)
Console.WriteLine(st.Peek());  // 3

// Pop
Console.WriteLine(st.Pop());   // removes 3

// Count
Console.WriteLine(st.Count);
```

### Deque (using LinkedList<T>)
- No direct Deque<T> in C#, use LinkedList<T>.
```csharp
LinkedList<int> dq = new();

// Add to front
dq.AddFirst(10);

// Add to back
dq.AddLast(20);

// Access front & back
Console.WriteLine(dq.First.Value);  // 10
Console.WriteLine(dq.Last.Value);   // 20

// Remove from front
dq.RemoveFirst();

// Remove from back
dq.RemoveLast();

// Check count
Console.WriteLine(dq.Count);

// Iterate
foreach (int x in dq)
    Console.WriteLine(x);
```

### PriorityQueue<TElement, TPriority>

- Introduced in **.NET 6+**
- Min-heap by default (element with **smallest priority** dequeued first)
- **TElement** = value stored in the queue  
- **TPriority** = value used for sorting (priority)  
- For simple cases (like integers), TElement and TPriority can be the same type.

---

#### 1. Min-Heap (default)
```csharp
PriorityQueue<int, int> pq = new();

pq.Enqueue(10, 10);  // element = 10, priority = 10
pq.Enqueue(5, 5);
pq.Enqueue(20, 20);

Console.WriteLine(pq.Dequeue()); // 5
Console.WriteLine(pq.Dequeue()); // 10
Console.WriteLine(pq.Dequeue()); // 20
```

---

#### 2. Max-Heap (custom comparer)
```csharp
var maxHeap = new PriorityQueue<int, int>(Comparer<int>.Create((a, b) => b.CompareTo(a)));

maxHeap.Enqueue(10, 10);
maxHeap.Enqueue(5, 5);
maxHeap.Enqueue(20, 20);

Console.WriteLine(maxHeap.Dequeue()); // 20
Console.WriteLine(maxHeap.Dequeue()); // 10
Console.WriteLine(maxHeap.Dequeue()); // 5
```

---

#### 3. Using objects as elements
```csharp
class Task
{
    public string Name;
}

PriorityQueue<Task, int> pq = new();
pq.Enqueue(new Task { Name = "A" }, 1); // priority = 1
pq.Enqueue(new Task { Name = "B" }, 5); // priority = 5

Task first = pq.Dequeue(); // Task with priority 1
```

---

#### 4. Notes / Tips
- Always specify both **element** and **priority types**.  
- For integers or simple values, you can use the same type for both.  
- Use **custom comparer** for max-heap or custom ordering.  
- Peek at the top element without removing: `pq.Peek()`.  
- Count of elements: `pq.Count`.


## 5. Classes & Object-Oriented Concepts

### 1. Class
- Basic blueprint for objects.
```csharp
class Person
{
    // Fields
    private string name;
    private int age;

    // Constructor
    public Person(string name, int age)
    {
        this.name = name;
        this.age = age;
    }

    // Method
    public void Greet()
    {
        Console.WriteLine($"Hello, my name is {name} and I am {age} years old.");
    }
}

// Usage
Person alice = new Person("Alice", 25);
alice.Greet();
```

---

### 2. Properties
- Encapsulate fields with **getters and setters**.
```csharp
class Person
{
    public string Name { get; set; }
    public int Age { get; set; }

    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }
}

// Usage
Person bob = new Person("Bob", 30);
Console.WriteLine(bob.Name);
bob.Age = 31;
```

---

### 3. Abstract Class
- Cannot be instantiated directly.  
- Can have **abstract methods** (no body) and **concrete methods**.
```csharp
abstract class Shape
{
    public abstract double Area(); // must be implemented by derived classes

    public void Describe()
    {
        Console.WriteLine("I am a shape.");
    }
}

class Circle : Shape
{
    public double Radius { get; set; }

    public Circle(double radius)
    {
        Radius = radius;
    }

    public override double Area()
    {
        return Math.PI * Radius * Radius;
    }
}

// Usage
Shape c = new Circle(5);
Console.WriteLine(c.Area());
c.Describe();
```

---

### 4. Interface
- Defines a **contract**; all methods must be implemented.  
- No fields allowed, only method signatures and properties.
```csharp
interface IDriveable
{
    void Start();
    void Stop();
}

class Car : IDriveable
{
    public void Start() => Console.WriteLine("Car started");
    public void Stop() => Console.WriteLine("Car stopped");
}

// Usage
IDriveable car = new Car();
car.Start();
```

---

### 5. Inheritance
- **Derived class** inherits from **base class** using `:`.
```csharp
class Vehicle
{
    public string Brand { get; set; }
    public void Honk() => Console.WriteLine("Beep!");
}

class Bike : Vehicle
{
    public bool HasCarrier { get; set; }
}

// Usage
Bike bike = new Bike();
bike.Brand = "Yamaha";
bike.Honk();   // inherited from Vehicle
```

---

### 6. Polymorphism (method overriding)
```csharp
class Vehicle
{
    public virtual void Start() => Console.WriteLine("Vehicle started");
}

class Car : Vehicle
{
    public override void Start() => Console.WriteLine("Car started");
}

// Usage
Vehicle v = new Car();
v.Start();  // Output: Car started (runtime polymorphism)
```

---

### 7. Access Modifiers
- `public` → accessible everywhere  
- `private` → accessible only inside the class  
- `protected` → accessible in class and derived classes  
- `internal` → accessible within same assembly  
- `protected internal` → combination of protected + internal  

---

### 8. Modeling Tips for LLD
- **Use classes** for entities (User, Account, Vehicle, etc.)  
- **Use interfaces** for capabilities (Driveable, Payable)  
- **Use abstract classes** when you have a **common base** with shared code and some methods that must be implemented  
- **Prefer composition over inheritance** when possible (HAS-A relationship)  
- **Encapsulate fields** with properties to make design clean and maintainable  


