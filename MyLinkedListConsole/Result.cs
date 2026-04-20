using static System.Net.Mime.MediaTypeNames;

namespace MyLinkedListLibrary;

public class Result<T> where T : IComparable<T>
{

    // 1st easy task of HackerRank(LinkedList)
    /*public static MyLinkedListNode<int> removeKthNodeFromEnd(MyLinkedListNode<int> head, int k)
    {
        MyLinkedListNode<int>? first = head;
        MyLinkedListNode<int>? second = head;

        if (first == null)
            return head;

        for (int i = 0; i < k; i++)
        {
            if (second is not null)
                second = second.Next;
            else
                return head;
        }

        if (second is null)
            return head.Next;

        while (second.Next != null)
        {
            first = first.Next;
            second = second.Next;
        }

        first.Next = first.Next.Next;
        return head;
    }*/
    public static MyLinkedListNode<int> RemoveKthNodeFromEnd(MyLinkedListNode<int> head, int k)
    {
        if (head == null) return null;

        // 1. Հաշվում ենք երկարությունը (n)
        int n = 0;
        MyLinkedListNode<int> temp = head;
        while (temp != null)
        {
            n++;
            temp = temp.Next;
        }

        // 2. Եթե k-ն անվավեր է (բացասական կամ ավելի մեծ քան երկարությունը)
        // Ըստ խնդրի նկարագրության՝ վերադարձնել օրիգինալը
        if (k < 0 || k >= n)
        {
            // Բայց եթե թեստը հեռացնում է head-ը, երբ k-ն մեծ է, փոխեք սա head.next
            return head;
        }

        // 3. Հեռացման տրամաբանությունը
        MyLinkedListNode<int> dummy = new MyLinkedListNode<int>(0);
        dummy.Next = head;
        MyLinkedListNode<int> fast = dummy;
        MyLinkedListNode<int> slow = dummy;

        // Քանի որ k-ն 0-ից է սկսվում, շարժվում ենք k+1 քայլ
        for (int i = 0; i <= k; i++)
        {
            fast = fast.Next;
        }

        while (fast.Next != null)
        {
            fast = fast.Next;
            slow = slow.Next;
        }

        // Հեռացնում ենք թիրախային node-ը
        if (slow.Next != null)
        {
            slow.Next = slow.Next.Next;
        }

        return dummy.Next;
    }
    // 2nd easy task of HackerRank(LinkedList)
    public static MyLinkedListNode<int> DeleteDuplicates(MyLinkedListNode<int> head)
    {
        if (head == null)
            return head;

        MyLinkedListNode<int>? current = head;

        while (current != null)
        {
            if (current.Next != null && current.Value == current.Next.Value)
                current.Next = current.Next.Next;
            else
                current = current.Next;
        }
        return head;
    }
    // 3rd medium task of HackerRank(LinkedList)
    /*public static MyLinkedListNode<int> extractAndAppendSponsoredNodes(MyLinkedListNode<int> head)
    {
        MyLinkedListNode<int>? current = head.Next;
        int n = 0;
        List<MyLinkedListNode<int>> arrayZ = new List<MyLinkedListNode<int>>();
        List<MyLinkedListNode<int>> arrayK = new List<MyLinkedListNode<int>>();


        while (current != null)
        {
            if (n % 2 == 0)
                arrayZ.Add(current);
            else
                arrayK.Add(current);

            current = current.Next;
            n++;

        }

        arrayZ.Reverse();
        foreach (var item in arrayZ)
            arrayK.Add(item);

        return arrayK[0];
    }*/

    public static MyLinkedListNode<int>? ExtractAndAppendSponsoredNodes(MyLinkedListNode<int> head)
    {
        MyLinkedListNode<int>? zuyg = head;
        MyLinkedListNode<int>? kent = head.Next;

        while (zuyg?.Next != null)
        {
            if (zuyg?.Next.Next != null)
                zuyg.Next = zuyg.Next.Next;
        }
        while (kent?.Next != null)
        {
            if (kent?.Next.Next != null)
                kent.Next = kent.Next.Next;
        }

        MyLinkedListNode<int>? currentzuyg = zuyg;
        while (currentzuyg != null)
        {

        }

        return kent;
    }
    // 1st easy task of LeetCode(LinkedList)
    public MyLinkedListNode<T> MergeTwoLists(MyLinkedListNode<T> list1, MyLinkedListNode<T> list2)
    {
        if (list1 == null)
            return list2;

        if (list2 == null)
            return list1;

        MyLinkedListNode<T>? current1 = list1;
        MyLinkedListNode<T>? current2 = list2;

        MyLinkedListNode<T>? resultHead;
        if (current1.CompareTo(current2) <= 0)
        { resultHead = current1; current1 = current1.Next; }
        else
        { resultHead = current2; current2 = current2.Next; }

        MyLinkedListNode<T>? resultTail = resultHead;

        while (current1 != null && current2 != null)
        {
            if (current1.CompareTo(current2) <= 0)
            {
                resultTail.Next = current1;
                current1 = current1.Next;
            }
            else
            {
                resultTail.Next = current2;
                current2 = current2.Next;
            }
            resultTail = resultTail.Next;
        }

        resultTail.Next = current1 ?? current2;

        return resultHead;
    }
    // 2nd easy task of LeetCode(Linked List)
    public bool HasCycle(MyLinkedListNode<T> head)
    {
        if (head == null || head.Next == null)
            return false;

        MyLinkedListNode<T>? fast = head.Next;
        MyLinkedListNode<T>? slow = head;

        while (fast != null && fast?.Next != null)
        {

            fast = fast?.Next?.Next;
            slow = slow?.Next;
            if (fast == slow)
                return true;
        }
        return false;
    }
    // 3rd easy task of LeetCode(Linked List)
    public MyLinkedListNode<T>? GetIntersectionNode(MyLinkedListNode<T> headA, MyLinkedListNode<T> headB)
    {
        if (headA == null || headB == null)
            return null;

        MyLinkedListNode<T>? currentA = headA;
        MyLinkedListNode<T>? currentB = headB;

        while (currentA != currentB)
        {
            if (currentA == null)
                currentA = headB;
            else
                currentA = currentA?.Next;

            if (currentB == null)
                currentB = headA;
            else
                currentB = currentB?.Next;
        }

        return currentA;
    }
    // 4th easy task of LeetCode(Linked List)
    public MyLinkedListNode<T>? MiddleNode(MyLinkedListNode<T>? head)
    {
        if (head == null) return null;
        if (head.Next == null) return head;

        MyLinkedListNode<T>? slow = head;
        MyLinkedListNode<T>? fast = head.Next;

        while (fast != null)
        {
            if (fast.Next != null)
                fast = fast.Next.Next;
            else
                return slow.Next;
            slow = slow.Next;
        }
        return slow;
    }
    // 5th easy task of LeetCode(Linked List)
    public MyLinkedListNode<T>? ReverseList(MyLinkedListNode<T>? head)
    {
        if (head == null) return null;
        if (head.Next == null) return head;

        MyLinkedListNode<T>? current = head;
        MyLinkedListNode<T>? previous = null;

        while (current != null)
        {
            MyLinkedListNode<T>? next = current.Next;
            current.Next = previous;
            previous = current;
            current = next;
        }

        return previous;
    }
    // 1st medium task of LeetCode(Linked List)
    public MyLinkedListNode<T>? SwapPairs(MyLinkedListNode<T>? head)
    {
        if (head == null) return null;
        if (head.Next == null) return head;

        MyLinkedListNode<T>? first;
        MyLinkedListNode<T>? second;

        MyLinkedListNode<T>? dummy = new MyLinkedListNode<T>();
        dummy.Next = head;

        MyLinkedListNode<T>? tail = dummy;

        while (tail.Next != null && tail.Next.Next != null)
        {
            first = tail.Next;
            second = tail.Next.Next;

            first.Next = second.Next;
            second.Next = first;
            tail.Next = second;

            tail = first;

        }
        return dummy.Next;
    }
    // 2nd medium task of LeetCode(LinkedList)
    public MyLinkedListNode<T>? RotateRight(MyLinkedListNode<T>? head, int k)
    {
        if (head == null || head.Next == null || k == 0)
            return head;

        // 1. Find length and tail
        int n = 1;
        MyLinkedListNode<T> tail = head;

        while (tail.Next != null)
        {
            tail = tail.Next;
            n++;
        }

        // 2. Normalize k
        k %= n;
        if (k == 0)
            return head;

        // 3. Make it circular
        tail.Next = head;

        // 4. Find new tail position
        int stepsToNewTail = n - k;

        MyLinkedListNode<T> newTail = head;
        for (int i = 1; i < stepsToNewTail; i++)
        {
            newTail = newTail.Next;
        }

        // 5. Define new head
        MyLinkedListNode<T> newHead = newTail.Next;

        // 6. Break the circle
        newTail.Next = null;

        return newHead;
    }

}
