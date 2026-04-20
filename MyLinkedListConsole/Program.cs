using MyLinkedListLibrary;

MyLinkedList<int> head = new MyLinkedList<int>();

int headCount = Convert.ToInt32(Console.ReadLine().Trim());

for (int i = 0; i < headCount; i++)
{
    int headItem = Convert.ToInt32(Console.ReadLine().Trim());
    head.Add(headItem);
}

int k = Convert.ToInt32(Console.ReadLine().Trim());

MyLinkedListNode<int> result = Result<int>.RemoveKthNodeFromEnd(head.Head, k);

