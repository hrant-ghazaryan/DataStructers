using MyLinkedListLibrary;
using System.Collections;

namespace MyQueueLibrary;

public class MyQueue<T> : IEnumerable<T> where T : IComparable<T>
{
    MyLinkedList<T> queue = new MyLinkedList<T>();
    public int Count { get => queue.Count; }
    public void Enqueue(T item)
        => queue.Add(item);
    public T Dequeue()
    {
        if (Count == 0)
            throw new ArgumentException("Queue is empty!");

        T value = queue.Head.Value;
        queue.RemoveFirst(queue.Head.Value);
        return value;
    }
    public T Peek()
    {
        if (Count == 0)
            throw new ArgumentException("Queue is empty!");
        else
            return queue.Head.Value;
    }
    public IEnumerator<T> GetEnumerator()
        => queue.GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator()
        => ((IEnumerable<T>)this).GetEnumerator();
}
