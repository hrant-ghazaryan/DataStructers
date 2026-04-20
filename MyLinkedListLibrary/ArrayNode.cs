namespace MyLinkedListLibrary;

public class ArrayNode<T>
{
    public T Value { get; set; }
    public ArrayNode<T> Next { get; set; }
    public ArrayNode() { }
    public ArrayNode(T value)
        => Value = value;
}
