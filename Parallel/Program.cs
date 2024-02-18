using System.Collections.Generic;
using System.Diagnostics;

int[] sizeList = { 100000, 1000000, 10000000 };

foreach(var size in sizeList)
{
    List<int> numbers = new();

    for (int i = 0; i < size; i++)
    {
        numbers.Add(new Random().Next(0, 50));
    }

    Console.WriteLine("\n");
    Console.WriteLine($"[{size,10}]");
    Console.WriteLine(GetSum(numbers));
    Console.WriteLine(GetSumThread(numbers));
    Console.WriteLine(GetSumLINQ(numbers));
}

static string GetSum(List<int> list)
{
    Stopwatch sw = new();
    int sum = 0;

    sw.Start();
    foreach(var e in list)
    {
        sum += e;
    }
    sw.Stop();

    return $"[Sequential] Sum = {sum}. Time = {sw.ElapsedMilliseconds} ms.";
}

static string GetSumThread(List<int> list)
{
    Stopwatch sw = new();
    int sum = 0;
    object lockObj = new();

    sw.Start();

    List<Thread> threads = new();
    int proccessorCount = Environment.ProcessorCount;
    int chunkSize = (int)Math.Ceiling((double)list.Count/proccessorCount);

    for (int i=0;i<proccessorCount; i++)
    {
        int start = i*chunkSize;
        int end = Math.Min((i+1)*chunkSize,list.Count);

        Thread thread = new(()=>
        {
            int localSum = 0;

            for(int j = start;j<end;j++)
            {
                localSum += list[j];
            } 
            lock(lockObj)
            {
                sum += localSum;
            }
        });
        threads.Add(thread);
    }

    foreach(var t in threads)
    {
        t.Start();
    }

    foreach(var t in threads)
    {
        t.Join();
    }
    sw.Stop();

    return $"[{"Thread",10}] Sum = {sum}. Time = {sw.ElapsedMilliseconds} ms.";
}

static string GetSumLINQ(List<int> list)
{
    Stopwatch sw = new();
    int sum = 0;

    sw.Start();
    sum = list.AsParallel().Sum();
    sw.Stop();

    return $"[{"LINQ",10}] Sum = {sum}. Time = {sw.ElapsedMilliseconds} ms.";
}