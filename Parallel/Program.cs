using System.Collections.Generic;
using System.Diagnostics;

int[] sizeList = { 100000, 1000000, 10000000 };

foreach(var size in sizeList)
{
    List<int> intList = new();

    for (int i = 0; i < size; i++)
    {
        intList.Add(new Random().Next(0, 50));
    }

    Console.WriteLine("\n");
    Console.WriteLine($"[{size}]");
    Console.WriteLine(GetSumm(intList));
    Console.WriteLine(GetSumParallel(intList));
    Console.WriteLine(GetSumParallelLINQ(intList));
}

static string GetSumm(List<int> list)
{
    Stopwatch sw = new();
    int sum = 0;

    sw.Start();
    foreach(var e in list)
        sum += e;
    sw.Stop();

    return $"\t[Sequential] \tSum = {sum}. \tTime = {sw.ElapsedMilliseconds} ms.";
}

static string GetSumParallel(List<int> list)
{
    Stopwatch sw = new();
    int sum = 0;

    sw.Start();
    Parallel.For(0, list.Count, () => 0, (i, state, localSum) =>
    {
        localSum += list[i];
        return localSum;
    },
    localSum => { Interlocked.Add(ref sum, localSum); });
    sw.Stop();

    return $"\t[Parallel] \tSum = {sum}. \tTime = {sw.ElapsedMilliseconds} ms.";
}

static string GetSumParallelLINQ(List<int> list)
{
    Stopwatch sw = new();

    sw.Start();
    var sum = list.AsParallel().Sum();
    sw.Stop();
    
    return $"\t[LINQ Parallel] \tSum = {sum}. \tTime = {sw.ElapsedMilliseconds} ms.";
}