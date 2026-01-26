using System.Text.Json;

public class Shape2D
{
    public float[][] Points { get; set; }
    public int [][] Lines { get; set; }

    public void Print ()
    {
        Console.WriteLine (JsonSerializer.Serialize (this));
    }
}