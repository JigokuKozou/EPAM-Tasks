using SuperArray;

int[] arr = { 1, 2, 4, 2 };
arr.ForEach(x => Console.Write(x + " "));
Console.WriteLine();
Console.WriteLine("Sum elements: " + SuperArrayExtentions.Sum(arr));
Console.WriteLine("Average value: " + SuperArrayExtentions.Average(arr));
Console.WriteLine("Most repeated value: " + arr.FindMostRepeatedElement());