# Strategy Pattern
The Strategy Pattern is a behavioral design pattern that allows a class to change its behavior at runtime by selecting an algorithm or strategy from a family of algorithms. Instead of having multiple conditional statements, the Strategy Pattern encapsulates algorithms in their own classes and allows them to be interchangeable.

# Example
```csharp

// define the strategy interface
public interface ISortStrategy
{
    void Sort(List<int> list);
}

// concrete strategies
public class QuickSortStrategy : ISortStrategy
{
    public void Sort(List<int> list)
    {
        Console.WriteLine("Sorting using QuickSort");
        list.Sort();  // Using built-in sort (QuickSort is typically used)
    }
}

public class BubbleSortStrategy : ISortStrategy
{
    public void Sort(List<int> list)
    {
        Console.WriteLine("Sorting using BubbleSort");
        for (int i = 0; i < list.Count; i++)
        {
            for (int j = 0; j < list.Count - 1; j++)
            {
                if (list[j] > list[j + 1])
                {
                    // Swap
                    int temp = list[j];
                    list[j] = list[j + 1];
                    list[j + 1] = temp;
                }
            }
        }
    }
}

// The Context class uses an ISortStrategy and allows switching the strategy at runtime.
public class Sorter
{
    private ISortStrategy _sortStrategy;

    // Constructor accepts a default sorting strategy
    public Sorter(ISortStrategy sortStrategy)
    {
        _sortStrategy = sortStrategy;
    }

    // Method to set the sorting strategy dynamically
    public void SetSortStrategy(ISortStrategy sortStrategy)
    {
        _sortStrategy = sortStrategy;
    }

    // Method to perform sorting
    public void Sort(List<int> list)
    {
        _sortStrategy.Sort(list);
    }
}

// client code
class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int> { 10, 7, 9, 3, 5 };

        // Initializing sorter with QuickSortStrategy
        var sorter = new Sorter(new QuickSortStrategy());
        sorter.Sort(numbers);  // Sorting using QuickSort

        // Changing strategy to BubbleSort at runtime
        sorter.SetSortStrategy(new BubbleSortStrategy());
        sorter.Sort(numbers);  // Sorting using BubbleSort
    }
}


```