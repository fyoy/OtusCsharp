using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        // Пример использования функции для чтения и подсчета пробелов в трех файлах параллельно.
        Console.WriteLine("==========");
        Console.WriteLine("Задание 1:");
        Console.WriteLine("==========");
        string[] fileNames = { "file1.txt", "file2.txt", "file3.txt" };
        await ProcessFilesAsync(fileNames);

        // Пример использования функции для чтения и подсчета пробелов во всех файлах в указанной папке.
        Console.WriteLine("\n==========");
        Console.WriteLine("Задание 2:");
        Console.WriteLine("==========");
        string folderPath = @".\files";
        await ProcessFilesInFolderAsync(folderPath);
    }

    static async Task ProcessFilesAsync(string[] fileNames)
    {
        var stopwatch = Stopwatch.StartNew();

        var tasks = fileNames.Select(fileName => CountSpacesAsync(fileName));
        await Task.WhenAll(tasks);

        stopwatch.Stop();
        Console.WriteLine($"Всего времени прошло: {stopwatch.ElapsedMilliseconds} мс");
    }

    static async Task ProcessFilesInFolderAsync(string folderPath)
    {
        var stopwatch = Stopwatch.StartNew();

        if (Directory.Exists(folderPath))
        {
            var fileNames = Directory.GetFiles(folderPath);
            var tasks = fileNames.Select(fileName => CountSpacesAsync(fileName)).ToArray();
            await Task.WhenAll(tasks);
        }
        else
        {
            Console.WriteLine($"Папка не найдена: {folderPath}");
        }

        stopwatch.Stop();
        Console.WriteLine($"Всего времени прошло: {stopwatch.ElapsedMilliseconds} мс");
    }

    static async Task CountSpacesAsync(string fileName)
    {
        try
        {
            var content = await File.ReadAllTextAsync(fileName);
            int spaceCount = content.Count(char.IsWhiteSpace);
            Console.WriteLine($"Файл: {fileName}, Количество пробелов: {spaceCount}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при обработке файла {fileName}: {ex.Message}");
        }
    }
}