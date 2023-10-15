
//The generic class Node contains an item and a reference to the next Node.
public class Node<T>
{
    //T Item and Node<T> Next returns
    public T Item { get; set; }
    public Node<T> Next { get; set; }
    
    //Returns item and next
    public Node(T item, Node<T> next)
    {
        this.Item = item;
        this.Next = next;
    }

}
