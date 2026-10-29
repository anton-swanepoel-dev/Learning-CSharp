using System.Collections.Generic;

namespace Myapp
{
    class Program
    {
        public int quicSortCounter { get; set; } = 0;
        public int sumNumbers(List<int> numbers)
        {
            if (numbers.Count == 0) return 0;

            return numbers[0] + sumNumbers(numbers.GetRange(1, numbers.Count - 1));

        }

        public int GetIndexOfName(List<string> names, string value)
        {
            for (int i = 0; i < names.Count; i++)
            {
                if (names[i] == value) return i;
            }

            return -1;
        }

        public List<int> MergeSort(List<int> numbers)
        {
            if (numbers.Count <= 1) return numbers;

            List<int> left = [];
            List<int> right = [];

            int half = numbers.Count / 2;

            left = numbers.GetRange(0, half);
            right = numbers.GetRange(half, numbers.Count - half);

            List<int> leftsorted = MergeSort(left);
            List<int> rightSorted = MergeSort(right);

            List<int> merged = [];

            while (leftsorted.Count > 0 && rightSorted.Count > 0)
            {
                if (leftsorted[0] > rightSorted[0])
                {
                    merged.Add(rightSorted[0]);
                    rightSorted.RemoveAt(0);
                }
                else
                {
                    merged.Add(leftsorted[0]);
                    leftsorted.RemoveAt(0);
                    
                }
            }

            foreach(var number in leftsorted)
            {
                merged.Add(number);
            }

            foreach(var number in rightSorted)
            {
                merged.Add(number);
            }


            return merged;



        }



        public List<int> QuickSort(List<int> numbers)
        {
            if (numbers.Count <= 1) return numbers;

            int pivot = numbers[0];

            List<int> left = new();
            List<int> right = new();

            foreach (int value in numbers.GetRange(1, numbers.Count - 1))
            {
                quicSortCounter++;
                if (value <= pivot) 
                {
                    left.Add(value);
                }
                else
                {
                    right.Add(value);
                }
            }

            List<int> leftSorted = [];
            List<int> rightSorted = [];
            List<int> result = [];


            leftSorted = QuickSort(left);
            rightSorted = QuickSort(right);

            foreach (var number in leftSorted)
            {
                result.Add(number);
                quicSortCounter++;
            }

            result.Add(pivot);
            quicSortCounter++;

            foreach (var number in rightSorted)
            {
                result.Add(number);
                quicSortCounter++;
            }
            return result;
        }


        static void Main()
        {
            List<int> unSorted = new List<int> { 3, 99, 4, 7, 33, 89, 35, 5, 55, 11, 13, 11 };
            List<int> unSorted2 = new List<int> { 3, 99, 4, 7, 33, 89, 35, 5, 55, 11, 13, 11 };
            List<int> unSorted3 = new List<int> { 3, 99, 4, 7, 33, 89, 35, 5, 55, 11, 13, 11 };


            List<int> Sorted = new List<int>();

            bool sorted = false;
            int count = 0;

            while (!sorted)
            {
                int lowest = 0;

                if (unSorted.Count > 0)
                {
                    lowest = unSorted[0];

                    foreach (int number in unSorted)
                    {
                        if (number < lowest) lowest = number;
                        Console.WriteLine($"Counter: {++count}");

                    }

                    Sorted.Add(lowest);
                    unSorted.Remove(lowest);
                }
                else
                {
                    sorted = true;
                }

            }

            foreach (var number in Sorted)
            {
                Console.WriteLine($"Number: {number}");
            }

            int total = 0;
            foreach (var number in Sorted)
            {
                total += number;
            }

            Console.WriteLine($"Total: {total}");

            Program program = new();


            Console.WriteLine($"Using recursive sum functoion. Total: {program.sumNumbers(Sorted)}");


            Console.WriteLine("Using the quicksort method:");

            foreach(var number in unSorted2)
            {
                Console.WriteLine(number);
            }

            Console.WriteLine($"\nafter sorting with quicksort\nnumber of calls {program.quicSortCounter}\n\n");

            List<int> quickSorted = program.QuickSort(unSorted2);

            foreach (var number in quickSorted)
            {
                Console.WriteLine(number);
            }

            List<int> mergeSorted = program.MergeSort(unSorted3);

            Console.WriteLine("\n\nDoing merge sort");

            foreach (var number in mergeSorted)
            {
                Console.WriteLine(number);
            }

            List<string> names = ["john", "piet", "sam", "zaxk"];

            Console.WriteLine($"index of john {program.GetIndexOfName(names , "sam")}");


            int flag = 2;

            Func<int, int> square = x => x * x;

            (int a, int b) = (flag == 2 ? 2 : 1, square(4));

        }
    }
}