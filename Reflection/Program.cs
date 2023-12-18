using System;
using System.Text.Json;

namespace CsvService
{

    class Program
    {
        static void Main()
        {
            CsvService _service = new();
            int quantity = 10000;
            string data = "";

            F f_object = F.Get();

            DateTime startTime = DateTime.Now;

            for (int i = 0; i < quantity; i++)
            {
                data = _service.Serialize(f_object);
            }

            DateTime endTime = DateTime.Now;

            var total = (endTime - startTime).TotalMilliseconds;

            var average = total / quantity;

            startTime = DateTime.Now;
            Console.WriteLine($"\r\nЗадания 1-5:\r\nРезультат: {data} \r\nПрошедшее время: {total} мс\n\rВремя на 1 итерацию: {average} мс для {quantity} итераций");
            endTime = DateTime.Now;

            Console.WriteLine($"\r\nЗадание 6:\r\nВремя на вывод в консоль: {(endTime - startTime).TotalMilliseconds} мс");

            data = JsonSerializer.Serialize(f_object);

            Console.WriteLine($"\r\nЗадание 7:\r\n{data}");

            startTime = DateTime.Now;

            for (int i = 0; i < quantity; i++)
            {
                data = JsonSerializer.Serialize(f_object);
            }

            endTime = DateTime.Now;

            total = (endTime - startTime).TotalMilliseconds;
            average = total / quantity;

            Console.WriteLine($"\r\nЗадание 8:\r\nПрошедшее время: {total} мс\n\rВремя на 1 итерацию: {average} мс для {quantity} итераций");

            startTime = DateTime.Now;

            List<F> data_list = _service.Deserialize<F>("MyFile.csv");
            foreach (var d in data_list)
            {
                Console.WriteLine(_service.Serialize(d));
            }

            endTime = DateTime.Now;

            total = (endTime - startTime).TotalMilliseconds;
            average = total / quantity;

            Console.WriteLine($"\r\nЗадание 9:\r\nПрошедшее время: {total} мс\n\rВремя на 1 итерацию: {average} мс для {quantity} итераций");

            string json = "{\"i1\":6, \"i2\":4, \"i3\":3, \"i4\":42, \"i5\":5}";

            for (int i = 0; i < quantity; i++)
            {
                f_object = JsonSerializer.Deserialize<F>(json);
            }

            endTime = DateTime.Now;

            total = (endTime - startTime).TotalMilliseconds;
            average = total / quantity;

            Console.WriteLine($"\r\nЗадание 10:\r\nПрошедшее время: {total} мс\n\rВремя на 1 итерацию: {average} мс для {quantity} итераций"); 
        }
    }
}