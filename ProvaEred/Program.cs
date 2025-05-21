using System;

class Program
{
    static void Main(string[] args)
    {
        Cane c = new Cane();
        c.FaiVerso();
        c.Scodinzola();
        
    }
}

public class Animale
{
    public virtual void FaiVerso()
    {
        Console.WriteLine($"L'animale fa un verso.");
    }
}

public class Cane : Animale
{
    public void Scodinzola()
    {
        Console.WriteLine($"Il cane scodinzola.");
    }

    public override void FaiVerso()
    {
        base.FaiVerso();
        Console.WriteLine($"Bau!");
    }
}
