namespace LRUCache;

public class DoublyLinkedList
{
    public Node head;
    public Node tail;

    public DoublyLinkedList()
    {
        
    }

    public void AddFirst(Node node)
    {
        node.Prev = null;
        node.Next = head;

        if (head != null)
        {
            head.Prev = node;
        }

        this.head = node;

        if (this.tail == null)
        {
            this.tail = node;
        }
        
    }

    public Node RemoveLast()
    {
        // first time, there was no node
        if (tail == null)
        {
            return null;
        }
        
        var node = this.tail;

        if (node.Prev != null)
        {
            node.Prev.Next = null;
        }
        
        this.tail = node.Prev;
        return node;
    }

    public void Remove(Node node)
    {
        if (node.Prev != null)
            node.Prev.Next = node.Next;
        else
            head = node.Next; // node is head

        if (node.Next != null)
            node.Next.Prev = node.Prev;
        else
            tail = node.Prev; // node is tail
    }

    public void MoveToFront(Node node)
    {
        Remove(node);
        AddFirst(node);
    }
}