using System;
using LRUCache;

class Program
{
    public static void Main()
    {
        // Create LRU Cache with capacity 3
        LRUCache.LRUCache cache = new LRUCache.LRUCache(3);

        // Add some items
        cache.Put("A", "Apple");
        cache.Put("B", "Banana");
        cache.Put("C", "Cherry");

        Console.WriteLine("Initial cache state:");
        PrintCacheState(cache);

        // Access some items
        Console.WriteLine("\nAccess key B: " + cache.Get("B")); // Moves B to front
        Console.WriteLine("\nCache state after accessing B:");
        PrintCacheState(cache);

        // Add another item, should evict least recently used (A)
        cache.Put("D", "Date");
        Console.WriteLine("\nCache state after adding D (evicts A):");
        PrintCacheState(cache);

        // Access key C
        Console.WriteLine("\nAccess key C: " + cache.Get("C")); // Moves C to front
        Console.WriteLine("\nCache state after accessing C:");
        PrintCacheState(cache);

        // Add another item, should evict least recently used (B)
        cache.Put("E", "Elderberry");
        Console.WriteLine("\nCache state after adding E (evicts B):");
        PrintCacheState(cache);
    }

    static void PrintCacheState(LRUCache.LRUCache cache)
    {
        var node = cache._doublyLinkedList.head;
        Console.WriteLine("Cache (Most recent → Least recent):");
        while (node != null)
        {
            Console.WriteLine($"{node.key}: {node.value}");
            node = node.Next;
        }
    }
}