using System.Text.Json;

public class InputData
{
    public Model3D Model { get; set; } 
    public RenderParameters Parameters { get; set; }

    public static InputData LoadFromJson(string path)
    {
        if (!File.Exists(path))
            throw new FileNotFoundException($"JSON file not found: {path}");

        var json = File.ReadAllText(path);
        var data = JsonSerializer.Deserialize<InputData>(json)!;

        return data;
    }
}