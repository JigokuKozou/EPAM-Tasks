using System;
using SuperArray;

int[] arr = { 1, 2, 4, 2 };
arr.ForEach(x => Console.Write(x + " "));
Console.WriteLine();
Console.WriteLine("Sum elements: " + arr.Sum());
Console.WriteLine("Average value: " + arr.Average());
Console.WriteLine("Most repeated value: " + arr.FindMostRepeatedElement());