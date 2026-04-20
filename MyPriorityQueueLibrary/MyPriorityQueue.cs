using MyLinkedListLibrary;
using System.Collections;

namespace MyPriorityQueueLibrary;

public class MyPriorityQueue<T> : IEnumerable<T> where T : IComparable<T>
{
    MyLinkedList<T> priorityQueue = new MyLinkedList<T>();
    public int Count { get => priorityQueue.Count; }
    public void Enqueue(T item)
        => priorityQueue.Add(item);
    public T Dequeue()
    {
        if (Count == 0)
            throw new ArgumentException("Queue is empty!");

        MyLinkedListNode<T> current = priorityQueue.Head;
        MyLinkedListNode<T> best = priorityQueue.Head;


        while (current != null)
        {
            if (current.Value.CompareTo(best.Value) < 0)
                best = current;

            current = current.Next;
        }

        T returnValue = best.Value;

        priorityQueue.Remove(best.Value);
        return returnValue;
    }
    public T Peek()
    {
        if (Count == 0)
            throw new ArgumentException("Queue is empty!");
        else
            return priorityQueue.Head.Value;
    }
    public IEnumerator<T> GetEnumerator()
        => priorityQueue.GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator()
        => ((IEnumerable<T>)this).GetEnumerator();
}
