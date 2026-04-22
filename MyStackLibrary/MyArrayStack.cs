using System.Collections;

namespace MyStackLibrary;

public class MyArrayStack<T> : IEnumerable<T> where T : IComparable<T>
{
    T[] stack;
    public int Count { get => stack.Length; private set; }
    public MyArrayStack(int count)
    {
        stack = new T[count];
        Count = count;
    }
    public void Push(T item)
    {
        T[] copyArray = new T[stack.Length + 1];
        for (int i = 0; i < stack.Length; i++)
            copyArray[i] = stack[i];
        copyArray[copyArray.Length - 1] = item;
        stack = copyArray; 
    }
    public void Pop(T item)
    {
        T[] copyArray = new T[stack.Length - 1];
        for (int i = 0; i < stack.Length - 1; i++)
            copyArray[i] = stack[i];
        stack = copyArray;
    }
    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < stack.Length; i++)
            yield return stack[i];
    }

    IEnumerator IEnumerable.GetEnumerator()
        => ((IEnumerable<T>)this).GetEnumerator();
}
