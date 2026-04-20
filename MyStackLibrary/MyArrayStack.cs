using System.Collections;

namespace MyStackLibrary;

public class MyArrayStack<T> : IEnumerable<T> where T : IComparable<T>
{
    T[] stack;
    public int Length { get => stack.Length; private set; }
    public MyArrayStack(int length)
    {
        stack = new T[length];
        Length = length;
    }
    public void Add(T item)
    {
        T[] copyArray = new T[stack.Length + 1];
        for (int i = 0; i < stack.Length; i++)
            copyArray[i] = stack[i];
        copyArray[copyArray.Length - 1] = item;
        stack = copyArray; 
    }
    public void Remove(T item)
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
