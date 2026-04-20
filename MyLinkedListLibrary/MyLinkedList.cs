using System.Collections;

namespace MyLinkedListLibrary;

public class MyLinkedList<T> : ICollection<T>  where T : IComparable<T>
{
    public MyLinkedListNode<T>? Head { get; set; }
    public MyLinkedListNode<T>? Tail { get; set; }
    bool isHeadAvailable = false;
    public void PrintMyLinkedList(T item)
    {
        var ob = new MyLinkedListNode<T>(item);
        Head = ob;
        while (ob != null)
        {
            Console.WriteLine(ob.Value);
            ob = ob.Next;
        }
    }

    #region ICollection
    public int Count { get; private set; }
    public bool IsReadOnly { get; }
    public void Add(T item)
        => AddL(new MyLinkedListNode<T>(item));
    public void Clear()
    {
        Head = null;
        Tail = null;
        Count = 0;
    }
    public bool Contains(T item)
    {
        while (Head != null)
        {
            if (Head.Value.Equals(item))
                return true;
            Head = Head.Next;
        }
        return false;
    }
    public void CopyTo(T[] array, int arrayIndex)
    {
        var current = Head;
        while (Head != null && arrayIndex < array.Length)
        {
            array[arrayIndex] = current!.Value;
            current = current.Next;
            arrayIndex++;
        }
    }
    public IEnumerator<T> GetEnumerator()
    {
        MyLinkedListNode<T>? current = Head;
        while (current != null)
        {
            yield return current.Value;
            current = current.Next;
        }
    }
    public bool Remove(T item)
        => Removee(new MyLinkedListNode<T>(item));
    IEnumerator IEnumerable.GetEnumerator()
        => ((IEnumerable<T>)this).GetEnumerator();
    #endregion
    #region Add
    public void AddFirst(T item)
        => AddF(new MyLinkedListNode<T>(item));
    private void AddF(MyLinkedListNode<T> item)
    {
        var temp = Head;
        Head = item;
        Head.Next = temp;
    }
    private void AddL(MyLinkedListNode<T> item)
    {
        if (Head == null)
        {
            if (!isHeadAvailable)
            {
                Head = item;
                isHeadAvailable = true;
            }
            Tail = item;
        }
        else
        {
            Tail.Next = item;
            Tail = Tail.Next;
        }

        Count++;
    }
    #endregion
    #region Remove
    public void RemoveFirst(T item)
        => RemoveFirstt(new MyLinkedListNode<T>(item));
    private void RemoveFirstt(MyLinkedListNode<T> item)
    {
        Head = Head?.Next;
        Count--;
    }
    public void RemoveLast(T item)
        => RemoveLastt(new MyLinkedListNode<T>(item));
    private void RemoveLastt(MyLinkedListNode<T> item)
    {
        if (Head == null)
            Count = 0;
        if (Head != null)
        {
            Tail = null;
            Count--;
        }
    }
    private bool Removee(MyLinkedListNode<T> item)
    {
        if (Head == null)
            return false;

        if (Head.Value.Equals(item.Value))
        {
            Head = Head.Next;
            Count--;
            return true;

        }
        MyLinkedListNode<T>? current = Head;
        MyLinkedListNode<T>? next = Head.Next;

        while (next != null)
        {
            if (next.Value.Equals(item.Value))
            {
                current.Next = next.Next;
                Count--;
                return true;
            }
            current = current.Next;
            next = current.Next;
        }

        return false;
    }

    
    #endregion


}
