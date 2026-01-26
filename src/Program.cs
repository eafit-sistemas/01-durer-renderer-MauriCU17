using System;

public static class Program
{
    public static void Main()
    {
        InputData data = InputData.LoadFromJson("input.json");
        Shape2D projected = ProjectShape(data.Model);
        projected.Print (); // The tests check for the correct projected data to be printed
        Render(projected, data.Parameters, "output.jpg");
    }

    private static void Render(Shape2D shape, RenderParameters parameters, string outputPath)
    {
        //TODO: Use skiasharp to render the shape to the output path, the test checks for this location
        // with the given parameters.
        throw new NotImplementedException();
    }

    private static Shape2D ProjectShape(Model3D model)
    {
        //TODO: Implement projection logic
        throw new NotImplementedException();
    }
}

