using MyLinkedListLibrary;
using System.Collections;

namespace MyStackLibrary;

public class MyStack<T> : IEnumerable<T> , IComparable<T>
    where T : IComparable<T>
{
    public MyLinkedList<T> stack = new MyLinkedList<T>();
    public int Count { get => stack.Count; }

    public T Pop()
    {
        if (Count == 0)
            throw new ArgumentException("Stack is empty!");

        T value = stack.Head.Value;
        stack.RemoveFirst();
        return value;
    }
    public T? Peek()
        => stack.Head.Value;
    public void Push(T item)
        => stack.AddFirst(item);
    public IEnumerator<T> GetEnumerator()
    {
        MyLinkedListNode<T>? current = stack.Head;
        while (current != null)
        {
            yield return current.Value;
            current = current.Next;
        }
    }
    IEnumerator IEnumerable.GetEnumerator()
        => ((IEnumerable<T>)this).GetEnumerator();

    public int CompareTo(T? other)
    {
        throw new NotImplementedException();
    }
}
