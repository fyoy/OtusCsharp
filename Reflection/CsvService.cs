using System;
using System.IO;
using System.Text;

namespace CsvService
{
    public class CsvService
    {
        public string Serialize<T>(T data)
        {
            var properties = typeof(T).GetProperties();
            var fields = typeof(T).GetFields();
            var sb = new StringBuilder();

            foreach (var property in properties)
            {
                sb.Append(property.GetValue(data));
                sb.Append(",");
            }

            foreach (var field in fields)
            {
                sb.Append(field.GetValue(data));
                sb.Append(",");
            }

            return sb.ToString().TrimEnd(',');
        }

        public List<T> Deserialize<T>(string filePath) where T : new()
        {
            var lines = File.ReadAllLines(filePath);
            var header = lines.First().Split(',');
            var properties = typeof(T).GetProperties();

            return lines.Skip(1)
                        .Select(row =>
                        {
                            var item = new T();
                            var values = row.Split(',');
                            for (var i = 0; i < header.Length && i < values.Length; i++)
                            {
                                var property = properties.FirstOrDefault(p => p.Name == header[i]);
                                if (property != null)
                                {
                                    property.SetValue(item, Convert.ChangeType(values[i], property.PropertyType));
                                }
                            }
                            return item;
                        })
                        .ToList();
        }

    }
}