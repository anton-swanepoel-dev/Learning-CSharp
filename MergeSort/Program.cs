using System;
using System.Collections.Generic;

public class MergeSorter
{

    public List<int> MergeSort(List<int> list)
    {
        if (list.Count <= 1) return list;

        (List<int> lefttHalf, List<int> rightHalf) = Split(list);

        List<int> left = MergeSort(lefttHalf);
        List<int> right = MergeSort(rightHalf);

        return Merge(left, right);

    }

    public (List<int> LefttHalf, List<int> RightHalf) Split(List<int> list)
    {
        int count = list.Count;

        int halfSize = count / 2;

        List<int> lefttHalf = list.GetRange(0, halfSize);
        List<int> rightHalf = list.GetRange(halfSize, list.Count - halfSize);

        return (lefttHalf, rightHalf);
    }

    public List<int> Merge(List<int> left, List<int> right)
    {
        List<int> merged = new List<int>();

        int i = 0;
        int j = 0;

        while (i < left.Count && j < right.Count)
        {
            if (left[i] < right[j])
            {
                merged.Add(left[i]);
                i++;
            }
            else
            {
                merged.Add(right[j]);
                j++;
            }
        }

        while (i < left.Count)
        {
            merged.Add(left[i]);
            i++;
        }

        while (j < right.Count)
        {
            merged.Add(right[j]);
            j++;
        }

        return merged;


    }

}


public class Program
{
    public static void Main()
    {
        List<int> unsorted =
            new() { 1, 5, 9, 3, 7, 2, 4, 8, 6, 0 };

        MergeSorter sorter = new MergeSorter();

        List<int> sorted = sorter.MergeSort(unsorted);

        foreach (int value in sorted)
        {
            Console.WriteLine(value);
        }
    }
}