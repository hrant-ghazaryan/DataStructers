using System.Collections;

namespace MyQueueLibrary;

public class MyArrayQueue<T> : IEnumerable<T>
{
    public int Length { get => queue.Length; private set; }
    T[] queue;
    public MyArrayQueue(int length)
        => queue = new T[length];

    public void Add(T item)
    {
        T[] copyArray = new T[queue.Length + 1];
        copyArray[0] = item;
        for (int i = 0; i < queue.Length; i++) 
            copyArray[i + 1] = queue[i];
        queue = copyArray;
    }
    public void Remove(T item)
    {
        T[] copyArray = new T[queue.Length - 1];
        for (int i = 0; i < queue.Length - 1; i++)
            copyArray[i] = queue[i];
        queue = copyArray;
    }
    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < queue.Length; i++)
            yield return queue[i];
    }

    IEnumerator IEnumerable.GetEnumerator()
        => ((IEnumerable<T>)this).GetEnumerator();
}
