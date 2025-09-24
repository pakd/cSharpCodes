namespace LRUCache;

public class Node
{
    public string key;
    public string value;
    
    public Node Next;
    public Node Prev;

    public Node(string key, string value)
    {
        this.key = key;
        this.value = value;
    }
        
    
}