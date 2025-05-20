using System;

class Program
{
    static void Main(string[] args)
    {
        List<string> spesa = new List<string>();

        for (int i = 0; i < 5; i++)
        {
            Console.Write($"Aggiungi un item alla lista della spesa: ");
            spesa.Add(Console.ReadLine());
        }

        Console.WriteLine($"Lista della spesa");
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine($" {i+1}: {spesa[i]}");
        }
        
    }
}
