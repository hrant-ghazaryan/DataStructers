
using System.Collections;
using System.ComponentModel;
namespace MyBinaryTreeLibrary;

public class MyBinaryTree<T> : IEnumerable<T> where T : IComparable<T>
{
    private MyBinaryTreeNode<T>? _root { get; set; }
    private int _count { get; set; }

    public void PostOrderTraversal(Action<T> action, MyBinaryTreeNode<T>? node)
    {
        if (node != null)
        {
            PostOrderTraversal(action, node.Left);
            PostOrderTraversal(action, node.Right);
            action(node.Value);
        }
    }

    public void PreOrderTraversal(Action<T> action, MyBinaryTreeNode<T>? node)
    {
        if (node != null)
        {
            action(node.Value);
            PreOrderTraversal(action, node.Left);
            PreOrderTraversal(action, node.Right);
        }
    }

    public void InOrderTraversal(Action<T> action, MyBinaryTreeNode<T>? node)
    {
        if (node != null)
        {
            InOrderTraversal(action, node.Left);
            action(node.Value);
            InOrderTraversal(action, node.Right);
        }
    }

    public T Min(MyBinaryTreeNode<T>? root)
    {
        if (root == null)
            throw new ArgumentNullException(nameof(root));

        MyBinaryTreeNode<T>? current = root;

        while (current.Left != null)
            current = current.Left;

        return current.Value;
    }

    public T Max(MyBinaryTreeNode<T>? root)
    {
        if (root == null)
            throw new ArgumentNullException(nameof(root));

        MyBinaryTreeNode<T>? current = root;

        while (current.Right != null)
            current = current.Right;

        return current.Value;
    }

    public void Add(MyBinaryTreeNode<T>? node)
    {
        if (node == null || node.Value == null)
            throw new ArgumentNullException(nameof(node));

        if (_root == null)
        {
            _root = node;
            return;
        }

        MyBinaryTreeNode<T>? current = _root;
        MyBinaryTreeNode<T>? parent = null;

        while (current != null)
        {
            parent = current;
            int result = node!.Value.CompareTo(current.Value);

            if (result > 0)
                current = current.Right;
            else if (result < 0)
                current = current.Left;
        }

        if (node.Value.CompareTo(parent!.Value) > 0)
            parent.Right = node;
        else
            parent.Left = node;
    }

    IEnumerable<T> EnumerationMethod(MyBinaryTreeNode<T>? node)
    {
        if (node != null)
        {
            foreach (var item in EnumerationMethod(node.Left))
                yield return item;

            yield return node.Value;

            foreach (var item in EnumerationMethod(node.Right))
                yield return item;
        }
    }

    public IEnumerator<T> GetEnumerator()
        => EnumerationMethod(_root).GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator()
        => GetEnumerator();
}
