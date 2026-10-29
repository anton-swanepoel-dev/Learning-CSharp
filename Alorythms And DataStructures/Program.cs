using System.Collections;

namespace MyApplication;

interface Inode
{
    public int? Data { get; set; }
    public Inode? previousNode { get; set; }

    public Inode? nextNode { get; set; }

    public void Speak();
}


class Cat : Inode
{
    public Inode? previousNode { get; set; }
    public Inode? nextNode { get; set; }

    public int? Data { get; set; }

    public void Speak() { Console.WriteLine(Data); }

    public Cat(int data)
    {
        Data = data;
    }
}

class Dog : Inode
{
    public Inode? previousNode { get; set; }
    public Inode? nextNode { get; set; }

    public int? Data { get; set; }

    public void Speak() { Console.WriteLine(Data); }

    public Dog(int data)
    {
        Data = data;
    }

}

class Bird : Inode
{
    public Inode? previousNode { get; set; }
    public Inode? nextNode { get; set; }

    public int? Data { get; set; }

    public void Speak() { Console.WriteLine(Data); }

    public Bird(int data)
    {
        Data = data;
    }

}

class MyList()
{
    public Inode? firstNode;
    public Inode? lastNode;

    private int _length = 0;

    public void AddEnd(Inode node)
    {

        if (firstNode == null)
        {
            firstNode = node;
            lastNode = node;
            _length++;
        }
        else
        {
            node.previousNode = lastNode;
            lastNode!.nextNode = node;
            lastNode = node;
            lastNode.nextNode = null;
            _length++;
        }
    }

    public void AddFirst(Inode node)
    {
        if (firstNode == null)
        {
            firstNode = node;
            lastNode = node;
            _length++;
        }
        else
        {
            node.nextNode = firstNode;
            firstNode.previousNode = node;
            firstNode = node;
            _length++;
        }
    }

    public bool IsEmptyList()
    {
        return firstNode == null;
    }

    public void SpeakForward()
    {
        if (firstNode != null)
        {
            firstNode.Speak();
            Inode? nextInLine = firstNode.nextNode;

            while (nextInLine != null)
            {
                nextInLine.Speak();
                nextInLine = nextInLine.nextNode;
            }
        }
    }

    public void SpeakInReverse()
    {
        if (lastNode != null)
        {
            lastNode.Speak();

            Inode? nextInLine = lastNode.previousNode;

            while (nextInLine != null)
            {
                nextInLine.Speak();
                nextInLine = nextInLine.previousNode;
            }
        }
    }

    public Inode? Search(int data)
    {
        Inode? current = firstNode;

        while (current != null)
        {
            if (current.Data == data) return current;

            current = current.nextNode;
        }

        return null;
    }


    public bool IsInList(int data)
    {
        Inode? nodeToCheck = firstNode;

        if (nodeToCheck == null) return false;

        while (nodeToCheck != null)
        {
            if (nodeToCheck.Data == data) return true;

            nodeToCheck = nodeToCheck.nextNode;
        }

        return false;
    }

    public int SizeOfList()
    {
     //   return _length;
        Inode? currentNode = firstNode;

        int count = 0;

        while (currentNode != null)
        {
            count++;
            currentNode = currentNode.nextNode;
        }
        return count;
    }

    public void Insert(Inode node, int index)
    {
        if (index < 0 || index > _length)
        {
            throw new ArgumentOutOfRangeException(nameof(index));
        }

        if ((firstNode == null) && (index == 0))
        {
            AddFirst(node);
            return;
        }

        if (index == _length)
        {
            AddEnd(node);
            return;
        }

        Inode? currentNode = firstNode;

        for (int i = 1; i < index; i++)
        {
            currentNode = currentNode!.nextNode;
        }

        Inode? previousNode = currentNode!.previousNode;
        Inode? nextNode = currentNode.nextNode;

        currentNode.nextNode = node;
        node.previousNode = currentNode;
        node.nextNode = nextNode;
        nextNode!.previousNode = node;
        _length++;
    }

    public Inode NodeAtIndex(MyList list, int index)
    {
        Inode? current = firstNode;
        for (int i = 1; i < index; i++)
        {
            current = current.nextNode;
        }

        return current;
    }


    public bool Delete(int data)
    {
        if (firstNode == null) return false;

        Inode? current = firstNode;

        for (int i = 0; i < _length && current != null; i++)
        {
            if (current.Data == data) break;
            current = current.nextNode;
        }

        if (current.Data == data)
        {
            Inode? previous = current.previousNode;
            Inode? next = current.nextNode;

            if (previous != null)
            {
                if (next != null)
                {
                    previous.nextNode = next;
                    next.previousNode = previous;
                }
                else
                {
                    previous.nextNode = null;
                    lastNode = previous;
                }
            }
            else
            {
                if (next != null)
                {
                    next.previousNode = null;
                    firstNode = next;
                }
                else
                {
                    firstNode = null;
                    lastNode = null;
                }
            }
            _length--;

            return true;
        }
        else
        {
            return false;
        }
    }
}


class Program
{
    static void Main()
    {

        MyList animals = new MyList();

        //    Console.WriteLine("the list is empty " + animals.IsEmptyList());

        animals.AddFirst(new Cat(8));
        animals.AddEnd(new Dog(1));
        animals.AddEnd(new Bird(5));
        animals.AddEnd(new Bird(3));

        //animals.AddFirst(new Dog(7));

        //animals.Insert(new Dog(4), 2);

        //animals.SpeakForward();

        //Console.WriteLine("");

        //animals.SpeakInReverse();

        //Console.WriteLine();

        //Console.WriteLine(animals.IsInList("Chirp"));
        //Console.WriteLine("The list is empty " + animals.IsEmptyList());


        //Console.WriteLine("The size of the lists is " + animals.SizeOfList());

        //Console.WriteLine(" data deleted " + animals.Delete("Mew"));
        //animals.SpeakForward();
        //Console.WriteLine("The size of the lists is " + animals.SizeOfList());

        //Console.WriteLine();

        //string searchTerm = "hhhh";

        //Inode? newNode = animals.Search(searchTerm);

        //if (newNode != null)
        //{
        //    newNode.Speak();
        //}
        //else
        //{
        //    Console.WriteLine($"Could not find {searchTerm}");
        //}
        //animals.SpeakForward();
        //Console.WriteLine("The size of the lists is " + animals.SizeOfList());

        //animals.DeleteByIndex(5);
        //animals.SpeakForward();
        //Console.WriteLine("The size of the lists is " + animals.SizeOfList());
        SortFunctions sort = new SortFunctions();

        MyList sortedList = sort.MergeSort(animals);
        sortedList.SpeakForward();

        Console.WriteLine("Sorted " + sort.VerifySorted(sortedList));

    }

    class SortFunctions()
    {

        public MyList MergeSort(MyList list)
        {
            if (list.SizeOfList() == 0)
            {
                return list;
            }
            else if (list.SizeOfList() == 1)
            {
                list.firstNode.previousNode = null;
                list.lastNode.nextNode = null;
                return list;
            }

            MyList leftHalf = new MyList();
            MyList rightHalf = new MyList();

            MyList merged = new MyList();

            (leftHalf, rightHalf) = Split(list);

            MyList left = new();
            MyList right = new();

            left = MergeSort(leftHalf);
            right = MergeSort(rightHalf);

            int leftCount = left.SizeOfList();
            int rightCount = right.SizeOfList();

            int i = 0;
            int j = 0;

            Inode? leftNode = left.firstNode;
            Inode? rightNode = right.firstNode;

            while (leftNode != null && rightNode != null)
            {
                if (leftNode.Data < rightNode.Data)
                {
                    Inode? nextLeft = leftNode.nextNode;
                    merged.AddEnd(leftNode);
                    leftNode = nextLeft;
                }
                else
                {
                    Inode? nextRight = rightNode.nextNode;
                    merged.AddEnd(rightNode);
                    rightNode = nextRight;
                }
            }

            while (leftNode != null)
            {
                Inode? nextLeft = leftNode.nextNode;
                merged.AddEnd(leftNode);
                leftNode = nextLeft;
            }

            while (rightNode != null)
            {
                Inode? nextRight = rightNode.nextNode;
                merged.AddEnd(rightNode);
                rightNode = nextRight;
            }

            //Inode? leftNode = left.firstNode;
            //Inode? rightNode = right.firstNode;

            //while (i < leftCount && j < rightCount)
            //{
            //    leftNode = left.NodeAtIndex(left, i);
            //    rightNode = right.NodeAtIndex(right, j);

            //    if (leftNode.Data < rightNode.Data)
            //    {
            //        merged.AddEnd(leftNode);
            //        i++;
            //    }
            //    else
            //    {
            //        merged.AddEnd(rightNode);
            //        j++;
            //    }
            //}

            //while (i < leftCount && j < rightCount)
            //{
            //    Inode? nextLeft = leftNode.nextNode;
            //    Inode? nextRight = rightNode.nextNode;

            //    if (leftNode.Data < rightNode.Data)
            //    {
            //        merged.AddEnd(leftNode);
            //        leftNode = nextLeft;
            //        i++;
            //    }
            //    else
            //    {
            //        merged.AddEnd(rightNode);
            //        rightNode = nextRight;
            //        j++;
            //    }
            //}




            //while (i < leftCount)
            //{
            //    leftNode = left.NodeAtIndex(left, i);
            //    merged.AddEnd(leftNode);
            //    i++;
            //}

            //while (j < rightCount)
            //{
            //    rightNode = right.NodeAtIndex(right, j);
            //    merged.AddEnd(rightNode);
            //    j++;
            //}



            return merged;

        }

        public (MyList left, MyList right) Split(MyList list)
        {
            int count = list.SizeOfList();

            MyList leftHalf = new MyList();

            MyList rightHalf = new MyList();

            if (count == 0 || count == 1)
            {
                list.firstNode.nextNode = null;
                list.firstNode.previousNode = null;
                rightHalf.firstNode = null;
                rightHalf.lastNode = null;
                return (list, rightHalf);
            }

            int halfSize = count / 2;

            leftHalf.firstNode = list.firstNode;
            leftHalf.firstNode.previousNode = null;
            leftHalf.lastNode = list.NodeAtIndex(list, halfSize);

            

            rightHalf.firstNode = leftHalf.lastNode.nextNode;


            rightHalf.firstNode.previousNode = null;

            leftHalf.lastNode.nextNode = null;

            rightHalf.lastNode = list.lastNode;

            rightHalf.lastNode.nextNode = null;

            return (leftHalf, rightHalf);

        }

        public MyList Merge(MyList left, MyList right)
        {
            MyList merged = new();

            merged.firstNode = left.firstNode;
            // merged.lastNode = right.lastNode;

            Inode current = left.firstNode;

            while (current != null)
            {
                if (current.nextNode == null) break;
                
                current = current.nextNode;
            }

            current.nextNode = right.firstNode;

            merged.lastNode = right.lastNode;




            return merged;



        }

        public bool VerifySorted(MyList list)
        {
            if (list.firstNode.nextNode == null) return true;
            MyList subList = new();
            subList.firstNode = list.firstNode.nextNode;

            return (list.firstNode.Data < list.firstNode.nextNode.Data && VerifySorted(subList));


        }
    }
}



//class MyLinkedList
//{
//    public Node? First { get; private set; }
//    public Node? Last { get; private set; }

//    public void Add(string data)
//    {
//        Node newNode = new Node(data);

//        if (First == null)
//        {
//            First = newNode;
//            Last = newNode;
//        }
//        else
//        {
//            newNode.Previous = Last;
//            Last!.Next = newNode;
//            Last = newNode;
//        }
//    }
//}

//class Node
//{
//    public string Data { get; set; }

//    public Node? Previous { get; set; }
//    public Node? Next { get; set; }

//    public Node(string data)
//    {
//        Data = data;
//    }
//}
