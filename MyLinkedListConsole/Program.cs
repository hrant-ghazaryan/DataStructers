using MyBinaryTreeLibrary;

MyBinaryTree<int> tree = new MyBinaryTree<int>();
tree.Add(1);
tree.Add(2);
tree.Add(3);
tree.Add(4);
tree.Add(5);
tree.Add(6);
tree.Add(7);
tree.Add(8);
tree.Add(9);
foreach (var item in tree)
    Console.WriteLine(item);
