using System.Text.Json;
using System.Threading.Tasks;

class EntityWriter<T> : IEntityWriter<T> where T : IEntity
{
    public async Task Save(T entity)
    {
        string filePath = $"{typeof(T).Name}s.json";
        List<T> entities = new ();
        if (File.Exists(filePath))
        {
            entities = await ReadJsonFromFileAsync(filePath);
        }
        var entitythatExists = entities.FirstOrDefault(e => e.Id == entity.Id);
        if(entitythatExists != null)
        {
            Console.WriteLine("yes");
            var index = entities.IndexOf(entitythatExists);
            entities[index] = entity;
        }
        else
        {
            entities.Add(entity);   
        }
        await WriteJsonToFileAsync(filePath, entities);
    }

    static async Task WriteJsonToFileAsync(string filePath, List<T> entities)
    {
        string json = JsonSerializer.Serialize(entities, new JsonSerializerOptions { WriteIndented = true });
        await File.WriteAllTextAsync(filePath, json);
        Console.WriteLine("Added List Successfully");
    }

    static async Task<List<T>> ReadJsonFromFileAsync(string filePath)
    {
        string json = await File.ReadAllTextAsync(filePath);
        return JsonSerializer.Deserialize<List<T>>(json);
    }
}