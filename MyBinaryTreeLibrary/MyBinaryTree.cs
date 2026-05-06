using System.Collections;
namespace MyBinaryTreeLibrary;

public class MyBinaryTree<T> : IEnumerable<T>
    where T : IComparable<T>
{
    #region oldAdd
    private MyBinaryTreeNode<T>? root { get; set; }

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
    public void Add(T? value)
    {
        if (value == null)
            throw new ArgumentNullException(nameof(value));
        Add(new MyBinaryTreeNode<T>(value));
    }
    public void Add(MyBinaryTreeNode<T>? node)
    {
        if (node == null || node.Value == null)
            throw new ArgumentNullException(nameof(node));

        if (root == null)
        {
            root = node;
            return;
        }

        MyBinaryTreeNode<T>? current = root;
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
    public IEnumerable<T> InOrderTraversal()
    {
        if (root != null)
        {

            Stack<MyBinaryTreeNode<T>> stack = new Stack<MyBinaryTreeNode<T>>();
            MyBinaryTreeNode<T>? current = root;

            bool goleftdown = true;
            stack.Push(current);

            while (stack.Count > 0)
            {
                if (goleftdown)
                {
                    while (current.Left != null)
                    {
                        stack.Push(current);
                        current = current.Left;
                    }
                }

                yield return current.Value;

                if (current.Right != null)
                {
                    current = current.Right;
                    goleftdown = true;
                }
                else
                {
                    current = stack.Pop();
                    goleftdown = false;
                }
            }
        }
    }
    public IEnumerator<T> GetEnumerator()
        => EnumerationMethod(root).GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator()
        => GetEnumerator();
    #endregion
    #region newAdd
    public void InOrderTraversal(List<T> list, MyBinaryTreeNode<T>? node)
    {
        if (node != null)
        {
            InOrderTraversal(list, node.Left);
            list.Add(node.Value);
            InOrderTraversal(list, node.Right);
        }
    }
    public MyBinaryTree<T>? Addd(T node)
        => Addd(new MyBinaryTreeNode<T>(node));
    public MyBinaryTree<T>? Addd(MyBinaryTreeNode<T> node)
    {
        List<T> list = new List<T>();
        InOrderTraversal(list, root);

        list.Add(node.Value);
        list.Sort();

        MyBinaryTree<T> newTree = new MyBinaryTree<T>();

        if (list.Count % 2 == 0)
        {
            newTree.Add(list[list.Count / 2 - 1]);
            list.RemoveAt(list.Count / 2 - 1);
        }
        else
        {
            newTree.Add(list[(list.Count + 1) / 2]);
            list.RemoveAt((list.Count + 1) / 2);
        }


        for (int i = 0; i < list.Count; i++)
            newTree.Add(list[i]);

        return newTree;
    }

    #endregion


    #region GPT Add
    public MyBinaryTree<T> Adddd(MyBinaryTreeNode<T> node)
    {
        if (node == null)
            throw new ArgumentNullException(nameof(node));

        // 1️⃣ Tree → sorted list
        List<T> list = new List<T>();
        InOrderTraversal(v => list.Add(v), root);

        // 2️⃣ Add new value
        list.Add(node.Value);

        // 3️⃣ Sort
        list.Sort();

        // 4️⃣ Build BALANCED tree ճիշտ ձևով
        MyBinaryTree<T> newTree = new MyBinaryTree<T>();
        newTree.root = BuildBalanced(list, 0, list.Count - 1);

        return newTree;
    }
    private MyBinaryTreeNode<T>? BuildBalanced(List<T> list, int left, int right)
    {
        if (left > right)
            return null;

        int mid = (left + right) / 2;

        var node = new MyBinaryTreeNode<T>(list[mid]);

        node.Left = BuildBalanced(list, left, mid - 1);
        node.Right = BuildBalanced(list, mid + 1, right);

        return node;
    }
    #endregion
}
