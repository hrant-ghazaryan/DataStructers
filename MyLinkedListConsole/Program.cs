using MyBinaryTreeLibrary;

#region MyTree
MyBinaryTree<int> tree = new MyBinaryTree<int>();
tree.Add(4);
tree.Add(2);
tree.Add(1);
tree.Add(3);
tree.Add(6);
tree.Add(5);
tree.Add(7);
foreach (var item in tree)
    Console.WriteLine(item);
#endregion

#region lINQ
List<int> list = new List<int>();
list.Add(1);
list.Add(2);
list.Add(3);
list.Add(4);
list.Add(5);
list.Add(6);
list.Add(7);
list.Add(8);
list.Add(9);
list.Add(10);

var events = list.Where(x => x > 5);
var squares = list.Select(x => x * x);
var orderList = list.Select(x => x > 5)
    .OrderByDescending(x => x);
var list2 = list.First(x => x > 7);
var list3 = list.FirstOrDefault(x => x > 7);
bool exist = list.Any(x => x < 0);

var kent = list.Where(x => x % 2 == 1).
    Select(x => x * 3).
    Where(x => x > 10);

List<int> numbers = new List<int>()
{
    12, 5, 8, 21, 14, 7, 18, 3, 10, 25
};

var newList = numbers.Where(x => x % 2 == 0).
    Select(x => x * 2).
    Where(x => x > 20).
    OrderBy(x=>x).
    Take(3);
#endregion