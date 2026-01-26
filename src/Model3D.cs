using System.Text.Json;

public class Model3D
{
    public float[][] VertexTable { get; set; } = default!;
    public int[][] EdgeTable { get; set; } = default!;

    public void Print ()
    {
        Console.WriteLine (JsonSerializer.Serialize (this));
    }
}