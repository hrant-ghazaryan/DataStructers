using System.Collections;

namespace MyLinkedListLibrary;

public class MyArrayLinkedList<T> : ICollection<T> where T : IComparable<T>
{
    private ArrayNode<T>?[] array;

    public ArrayNode<T>? Head { get; set; }
    /*if (array.Length == 0)
                return null;
            return array[0];*/
    public ArrayNode<T>? Tail { get; set; }
    /*if (Count == 0)
                return null;
            return array[array.Length - 1];*/
    #region ICollection
    public int Count { get => array.Length; private set; }

    public bool IsReadOnly { get; }

    public void Add(T item)
        => AddFirst(new ArrayNode<T>(item));

    public void Clear()
    {
        Head = null;
        Tail = null;
        Count = 0;
    }

    public bool Contains(T item)
    {
        var current = Head;
        var itemNode = new ArrayNode<T>(item);
        while (current != null)
        {
            if (current.Value.CompareTo(item) == 0)
                return true;
            current = current.Next;
        }
        return false;
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        throw new NotImplementedException();
    }

    public IEnumerator<T> GetEnumerator()
    {
        var current = Head;
        while (current != null)
        {
            yield return current.Value;
            current = current.Next;
        }
    }

    public bool Remove(T item)
    {
        throw new NotImplementedException();
    }

    IEnumerator IEnumerable.GetEnumerator()
        => ((IEnumerable)this).GetEnumerator();
    #endregion
    #region Add
    private void AddFirst(ArrayNode<T> item)
    {
        ArrayNode<T>? oldHead = Head;
        ArrayNode<T>[] arrayCopy = new ArrayNode<T>[array.Length + 1];
        arrayCopy[0] = item;
        for (int i = 0; i < array.Length; i++)
            arrayCopy[i + 1] = array[i];
        for (int i = 0; i < array.Length; i++)
            arrayCopy[i + 1] = array[i];
        array = arrayCopy;
        Head = item;
        item.Next = oldHead;
    }
    #endregion
}
