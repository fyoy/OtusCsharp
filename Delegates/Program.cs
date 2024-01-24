using Microsoft.VisualBasic;

namespace Delegates
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("[Все файлы]\n");
            FileSearcher fs = new();

            fs.SearchFiles("./"); 

            Console.WriteLine("\n[Самый большой файл по длинне наименования]\n");


            Func<FileArgs,float> convertToNumber = (name) => 
            {
                return (float)name.FileName.Length;
            };


            string[] files = Directory.GetFiles("./");

            if(files != null)
            {
                List<FileArgs> args = new();

                foreach(var file in files)
                    args.Add(new FileArgs(file));

                Console.WriteLine($"Самое большое {MaxExtension.GetMax(args,convertToNumber).FileName}");
            }
        }
    }
}