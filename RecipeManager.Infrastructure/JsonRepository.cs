using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace RecipeManager.Infrastructure;

public class JsonRepository<T>
{
    private readonly string _filePath;

    public JsonRepository(string filePath)
    {
        _filePath = filePath;
    }

    public void SaveToFile(List<T> items)
    {
        var options = new JsonSerializerOptions { WriteIndented = true };
        string json = JsonSerializer.Serialize(items, options);
        File.WriteAllText(_filePath, json);
    }

    public List<T> LoadFromFile()
    {
        if (!File.Exists(_filePath))
        {
            return new List<T>();
        }

        string json = File.ReadAllText(_filePath);
        return JsonSerializer.Deserialize<List<T>>(json) ?? new List<T>();
    }
}