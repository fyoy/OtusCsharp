namespace Delegates
{
    public class FileSearcher 
    {
        public event EventHandler<FileArgs> FileFound;
        public bool CancelSearch { get; private set; }

        public void SearchFiles(string directory)
        {
            foreach (var file in Directory.GetFiles(directory))
            {
                OnFileFound(new FileArgs(file));
                if (CancelSearch)
                {
                    Console.WriteLine("Поиск отменен.");
                    return;
                }
            }
        }

        protected virtual void OnFileFound(FileArgs e)
        =>  FileFound?.Invoke(this, e);
        public void Cancel()
        =>  CancelSearch = true;
    }

    public class FileArgs : EventArgs
    {
        public string FileName { get; }

        public FileArgs(string fileName)
        {
            FileName = fileName;
            Console.WriteLine($"Найден файл: {fileName}");
        }
    }
}