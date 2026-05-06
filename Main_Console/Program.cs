using MyBinaryTreeLibrary;

MyBinaryTreeNode<int> root = new MyBinaryTreeNode<int>(4);
MyBinaryTree<int> tree = new MyBinaryTree<int>();
tree.Add(root);
tree.Add(2);
tree.Add(1);
tree.Add(3);
tree.Add(6);
tree.Add(5);
tree.Add(7);

MyBinaryTree<int> addedTree = new MyBinaryTree<int>();

MyBinaryTreeNode<int> newRoot = new MyBinaryTreeNode<int>(8);

addedTree = tree.Adddd(newRoot);

foreach (var item in addedTree)
    Console.WriteLine(item);