using System;

class Program
{
    public static void Main(string[] args)
    {
        var calcolatrice = new Calcolatrice();

        Console.WriteLine($"Inserisci il primo numero:");
        double a = double.Parse(Console.ReadLine());
        Console.WriteLine($"Inserisci il secondo numero:");
        double b = double.Parse(Console.ReadLine());

        Console.WriteLine($"1) Somma");
        Console.WriteLine($"2) Sottrazione");
        Console.WriteLine($"3) Moltiplicazione");
        Console.WriteLine($"4) Divisione");
        Console.Write("Scegli l'operazione: ");
        int scelta = int.Parse(Console.ReadLine());

        switch (scelta)
        {
            case 1:
                calcolatrice.ImpostaStrategia(new SommaStrategia());
                break;
            case 2:
                calcolatrice.ImpostaStrategia(new SottrazioneStrategia());
                break;
            case 3:
                calcolatrice.ImpostaStrategia(new MoltiplicazioneStrategia());
                break;
            case 4:
                calcolatrice.ImpostaStrategia(new DivisioneStrategia());
                break;
            default:
                Console.WriteLine("Operazione non valida.");
                return;
        }

        Console.WriteLine($"Hai scelto l'operazione: {scelta}");
        Console.WriteLine($"Risultato:");
        calcolatrice.EseguiOperazione(a, b);
    }
}

// interfaccia comune per le strategie
public interface IStrategy
{
    double Calcola(double a, double b);
}

// Implementazioni concrete delle strategie per le operazioni matematiche
public class SommaStrategia : IStrategy
{
    public double Calcola(double a, double b)
    {
        return a + b;
    }
}

public class SottrazioneStrategia : IStrategy
{
    public double Calcola(double a, double b)
    {
        return a - b;
    }
}

public class MoltiplicazioneStrategia : IStrategy
{
    public double Calcola(double a, double b)
    {
        return a * b;
    }
}

public class DivisioneStrategia : IStrategy
{
    public double Calcola(double a, double b)
    {
        if (b == 0)
        {
            throw new DivideByZeroException("Divisione per zero non permessa.");
        }
        return a / b;
    }
}

// Classe che utilizza le strategie per eseguire le operazioni
public class Calcolatrice
{
    private IStrategy _strategia;

    public void ImpostaStrategia(IStrategy strategia)
    {
        _strategia = strategia;
    }

    // esegue l'operazione utilizzando la strategia impostata
    public void EseguiOperazione(double a, double b)
    {
        if (_strategia == null)
        {
            Console.WriteLine("Nessuna strategia impostata.");
            return;
        }
        double risultato = _strategia.Calcola(a, b);
        Console.WriteLine($"Risultato dell'operazione: {risultato}");
    }
}
