using System;
using SkiaSharp;
using System.IO;

public static class Program
{public static void Main()
    {
        InputData data = InputData.LoadFromJson("input.json");
        Shape2D projected = ProjectShape(data.Model);
        projected.Print (); // The tests check for the correct projected data to be printed
        Render(projected, data.Parameters, "output.jpg");
    }

    private static void Render(Shape2D shape, RenderParameters parameters, string outputPath)
    {
        string projectRoot = Path.GetFullPath(
        Path.Combine(AppContext.BaseDirectory, "..", "..", "..")
    );

    string finalPath = Path.Combine(projectRoot, outputPath);

    int res = parameters.Resolution;

    using var bitmap = new SKBitmap(res, res);
    using var canvas = new SKCanvas(bitmap);

    canvas.Clear(SKColors.White);

    using var paint = new SKPaint
    {
        Color = SKColors.Black,
        StrokeWidth = 2,
        IsAntialias = true
    };

    SKPoint ToScreen(float x, float y)
    {
        float px = (x - parameters.XMin) / (parameters.XMax - parameters.XMin) * res;
        float py = res - ((y - parameters.YMin) / (parameters.YMax - parameters.YMin) * res);
        return new SKPoint(px, py);
    }

    foreach (var line in shape.Lines)
    {
        var p0 = shape.Points[line[0]];
        var p1 = shape.Points[line[1]];

        SKPoint a = ToScreen(p0[0], p0[1]);
        SKPoint b = ToScreen(p1[0], p1[1]);

        canvas.DrawLine(a, b, paint);
    }

    using var image = SKImage.FromBitmap(bitmap);
    using var data = image.Encode(SKEncodedImageFormat.Jpeg, 100);

    File.WriteAllBytes(finalPath, data.ToArray());
    }

    private static Shape2D ProjectShape(Model3D model)
    {
        int vertexCount = model.VertexTable.Length;

    float[][] points2D = new float[vertexCount][];

    for (int i = 0; i < vertexCount; i++)
    {
        float x = model.VertexTable[i][0];
        float y = model.VertexTable[i][1];
        float z = model.VertexTable[i][2];

        float px = x / z;
        float py = y / z;

        points2D[i] = new float[] { px, py };
    }

    return new Shape2D
    {
        Points = points2D,
        Lines = model.EdgeTable
    };
    }
}

