namespace LRUCache;

public class LRUCache
{
    private int _capacity;
    private Dictionary<string, Node> _cache;
    public DoublyLinkedList _doublyLinkedList;

    public LRUCache(int capacity)
    {
        this._capacity = capacity;
        _cache = new Dictionary<string, Node>();
        _doublyLinkedList = new DoublyLinkedList();
    }

    public string? Get(string key)
    {
        if (this._cache.ContainsKey(key))
        {
            var node = this._cache[key];
            _doublyLinkedList.MoveToFront(node);
            return node.value;
        }
        else
        {
            Console.WriteLine("LRUCache does not contain key: " + key);
        }

        return null;
    }

    public void Put(string key, string value)
    {
        if (this._cache.ContainsKey(key))
        {
            var node = this._cache[key];
            _doublyLinkedList.MoveToFront(node);
        }
        else
        {
            if (this._cache.Count >= this._capacity)
            {
                
                var deletedNode = _doublyLinkedList.RemoveLast();
                this._cache.Remove(deletedNode.key);
            }
            
            var newNode = new Node(key, value);
            this._cache.Add(key, newNode);
            _doublyLinkedList.AddFirst(newNode);

        }
    }
}