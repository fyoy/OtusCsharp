1. Написать обобщённую функцию расширения, находящую и возвращающую максимальный элемент коллекции.
Функция должна принимать на вход делегат, преобразующий входной тип в число для возможности поиска максимального значения.
public static T GetMax(this IEnumerable collection, Func<T, float> convertToNumber) where T : class;

    >>  MaxExtension.cs

2. Написать класс, обходящий каталог файлов и выдающий событие при нахождении каждого файла;
    
    >>  FileSearcher.cs 
    >>  class FileSearcher

3. Оформить событие и его аргументы с использованием .NET соглашений:
public event EventHandler FileFound;
FileArgs – будет содержать имя файла и наследоваться от EventArgs

    >>  FileSearcher.cs 
    >>  public event EventHandler FileFound;
    >>  class FileArgs

4. Добавить возможность отмены дальнейшего поиска из обработчика;

    >>  FileSearcher.cs
    >>  bool CancelSearch и Cancel()
    
5. Вывести в консоль сообщения, возникающие при срабатывании событий и результат поиска максимального элемента.