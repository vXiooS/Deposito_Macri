using System;

class Program
{
    public static void Main(string[] args)
    {
        int[] voti = new int[5];

        int somma = 0;
        int maggiore = voti[0];
        int minore = voti[0];


        for (int i = 0; i < voti.Length; i++)
        {
            Console.Write($"Inserisci il {i + 1} numero: ");
            voti[i] = int.Parse(Console.ReadLine());
            somma += voti[i];

            if (voti[i] > maggiore)
            {
                maggiore = voti[i];
            }
            else if (voti[i] < minore)
            {
                minore = voti[i];
            }
        }

        double media = somma / voti.Length;
        Console.WriteLine($"La media è {media}");
        Console.WriteLine($"Il maggiore è {maggiore}");
        Console.WriteLine($"Il minore è {minore}");

    }
}
