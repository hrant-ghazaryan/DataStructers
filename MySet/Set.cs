using System.Collections;

namespace MySetProj;

public class Set<T> : IEnumerable<T>
   where T : IComparable<T>
{
    private readonly List<T> _items = new List<T>();

    public int Count
    {
        get
        {
            return _items.Count;
        }
    }
    public Set()
    { }
    public Set(IEnumerable<T> items)
    {
        AddRange(items);
    }
    public void Add(T item)
    {
        if (Contains(item))
        {
            throw new InvalidOperationException("Item already exists in Set");
        }
        _items.Add(item);
    }
    public void AddRange(IEnumerable<T> items)
    {
        foreach (T item in items)
        {
            Add(item);
        }
    }

    public bool Remove(T item)
    {
        return _items.Remove(item);
    }
    public bool Contains(T item)
    {
        return _items.Contains(item);
    }
    public Set<T> Union(Set<T> other)
    {
        Set<T> result = new Set<T>(_items);
        result.AddRangeSkipDuplicates(other._items);

        return result;
    }

    public Set<T> Intersection(Set<T> other)
    {
        Set<T> result = new Set<T>();
        foreach (T item in other._items)
        {
            if (_items.Contains(item))
            {
                result.Add(item);
            }
        }

        return result;
    }

    public Set<T> Difference(Set<T> other)
    {
        Set<T> result = new Set<T>(_items);
        foreach (T item in other._items)
        {
            result.Remove(item);
        }

        return result;
    }

    public Set<T> SymetricDifference(Set<T> other)
    {
        Set<T> intersection = Intersection(other);
        Set<T> union = Union(other);

        return union.Difference(intersection);
    }

    private void AddSkipDuplicates(T item)
    {
        if (!Contains(item))
        {
            _items.Add(item);
        }
    }
    private void AddRangeSkipDuplicates(IEnumerable<T> items)
    {
        foreach (T item in items)
        {
            AddSkipDuplicates(item);
        }
    }

    public IEnumerator<T> GetEnumerator()
    {
        return _items.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return _items.GetEnumerator();
    }
}
