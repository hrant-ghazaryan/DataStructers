using System.Collections;

namespace MyQueueLibrary;

public class MyArrayQueue<T> : IEnumerable<T>
{
    T[] queue;
    public int Count { get => queue.Length; private set; }

    public MyArrayQueue(int count)
    {
        queue = new T[count];
        Count = count;
    }
    public void Enqueue(T item)
    {
        T[] copyArray = new T[queue.Length + 1];
        copyArray[0] = item;
        for (int i = 0; i < queue.Length; i++) 
            copyArray[i + 1] = queue[i];
        queue = copyArray;
        Count++;
    }
    public void Dequeue(T item)
    {
        T[] copyArray = new T[queue.Length - 1];
        for (int i = 0; i < queue.Length - 1; i++)
            copyArray[i] = queue[i];
        queue = copyArray;
        Count--;
    }
    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < queue.Length; i++)
            yield return queue[i];
    }

    IEnumerator IEnumerable.GetEnumerator()
        => ((IEnumerable<T>)this).GetEnumerator();
}
