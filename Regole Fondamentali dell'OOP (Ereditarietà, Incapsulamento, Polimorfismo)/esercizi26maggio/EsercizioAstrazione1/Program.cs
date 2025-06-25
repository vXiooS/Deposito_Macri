using System;
using System.Diagnostics.Contracts;

class Program
{
    static void Main(string[] args)
    {
        List<DispositivoElettronico> dispositivi = new List<DispositivoElettronico>();

        bool x = true;
        do
        {
            Console.WriteLine($"");
            Console.WriteLine($"1: aggiungi computer");
            Console.WriteLine($"2: aggiungi stampante");
            Console.WriteLine($"3: accendi tutti i dispositivi");
            Console.WriteLine($"4: spegni tutti i dispositivi");
            Console.WriteLine($"5: mostra info di tutti i dispositivi");
            Console.WriteLine($"0: esci");
            Console.Write($"Cosa vuoi fare? ");
            int sceltamenu = int.Parse(Console.ReadLine());

            switch (sceltamenu)
            {
                case 0:
                    x = false;
                    break;
                case 1:
                    Computer c = new Computer();
                    Console.Write($"Inserisci il modello del computer: ");
                    c.Modello = Console.ReadLine();
                    dispositivi.Add(c);
                    break;
                case 2:
                    Stampante s = new Stampante();
                    Console.Write($"Inserisci il modello della stampante: ");
                    s.Modello = Console.ReadLine();
                    dispositivi.Add(s);
                    break;
                case 3:
                    foreach (DispositivoElettronico d in dispositivi)
                    {
                        d.Accendi();
                    }
                    break;
                case 4:
                    foreach (DispositivoElettronico d in dispositivi)
                    {
                        d.Spegni();
                    }
                    break;
                case 5:
                    foreach (DispositivoElettronico d in dispositivi)
                    {
                        d.MostraInfo();
                    }
                    break;
                default:
                    Console.WriteLine($"Scelta non valida.");
                    break;
            }
            

        }
        while (x);
    }
}

public abstract class DispositivoElettronico
{
    private string _modello;

    public abstract void Accendi();
    public abstract void Spegni();

    public virtual void MostraInfo()
    {
        Console.WriteLine($"Modello: {_modello}");
    }
}

public class Computer : DispositivoElettronico
{
    private string _modello;

    public string Modello
    {
        get { return _modello; }
        set { _modello = value; }
    }

    public override void Accendi()
    {
        Console.WriteLine($"Il computer {Modello} si avvia...");
    }

    public override void Spegni()
    {
        Console.WriteLine($"Il computer {Modello} si spegne.");
    }

    public override void MostraInfo()
    {
        Console.WriteLine($"Computer modello: {Modello}");
    }
}

public class Stampante : DispositivoElettronico
{
    private string _modello;

    public string Modello
    {
        get { return _modello; }
        set { _modello = value; }
    }

    public override void Accendi()
    {
        Console.WriteLine($"la stampante {Modello} si avvia...");
    }

    public override void Spegni()
    {
        Console.WriteLine($"La stampante {Modello} si spegne.");
    }

    public override void MostraInfo()
    {
        Console.WriteLine($"Stampante modello: {Modello}");
    }
} 

