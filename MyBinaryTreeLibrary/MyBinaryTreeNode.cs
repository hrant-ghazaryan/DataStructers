namespace MyBinaryTreeLibrary;

public class MyBinaryTreeNode<T> : IComparable<T> where T : IComparable<T>
{
    public T Value { get; set; }
    public MyBinaryTreeNode<T>? Left { get; set; }
    public MyBinaryTreeNode<T>? Right { get; set; }
    public MyBinaryTreeNode() { }
    public MyBinaryTreeNode(T value)
        => Value = value;
    public int CompareTo(T? other)
        => Value.CompareTo(other);
}
