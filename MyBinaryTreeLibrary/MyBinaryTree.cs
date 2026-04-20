using System.Collections;

namespace MyBinaryTreeLibrary;

public class MyBinaryTree<T> : IEnumerable<T> where T : IComparable<T>
{
    private MyBinaryTreeNode<T> _root { get; set; }
    private int _count { get; set; }

    public IEnumerator<T> GetEnumerator()
    {
        throw new NotImplementedException();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
