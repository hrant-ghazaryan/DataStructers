namespace MyLinkedListLibrary;

public class MyLinkedListNode<T> : IComparable<T> where T : IComparable<T>
{
    public T Value { get; set; }
    public MyLinkedListNode<T> Next { get; set; }
    public MyLinkedListNode() {  }
    public MyLinkedListNode(T value)
    { Value = value; }
    public static void PrintMyLinkedNodeListByFirst(MyLinkedListNode<T> first)
    {
        while (first != null)
        {
            Console.WriteLine(first.Value);
            first = first.Next;
        }
    }
    public int CompareTo(T? other)
    {
        if (other == null) return 1;

        return this.CompareTo(other);
    }
    public int CompareTo(MyLinkedListNode<T>? other)
    {
        if (other == null) return 1;

        return this.CompareTo(other.Value);
    }
}
