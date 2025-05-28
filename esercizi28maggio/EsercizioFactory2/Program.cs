using System;

class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine($"Scegli la forma da disegnare (Circle, Square):");
        string shapeType = Console.ReadLine();

        CreateShapeCreator c = new CreateShapeCreator();
        IShape s = c.CreateShape(shapeType);
        if (s != null)
        {
            s.Draw();
        }
        else
        {
            Console.WriteLine("Nessuna forma creata.");
        }
    }
}

public interface IShape
{
    void Draw();
}

public class Circle : IShape
{
    public void Draw()
    {
        Console.WriteLine("Drawing a Circle");
    }
}

public class Square : IShape
{
    public void Draw()
    {
        Console.WriteLine("Drawing a Square");
    }
}

public abstract class ShapeCreator
{
    public abstract IShape CreateShape();
}

public class CircleCreator : ShapeCreator
{
    public override IShape CreateShape()
    {
        return new Circle();
    }

}

public class SquareCreator : ShapeCreator
{
    public override IShape CreateShape()
    {
        return new Square();
    }
}

public class CreateShapeCreator
{
    public IShape CreateShape(string shapeType)
    {
        if (shapeType.Equals("Circle"))
        {
            return new CircleCreator().CreateShape();
        }
        else if (shapeType.Equals("Square"))
        {
            return new SquareCreator().CreateShape();
        }
        else
        {
            Console.WriteLine($"tipo non valido");
            return null;
        }
    }
}


