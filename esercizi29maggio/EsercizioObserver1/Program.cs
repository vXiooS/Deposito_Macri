using System;

class Program
{
    public static void Main(string[] args)
    {
        // inizializzazione del Subject e degli Observer
        CentroMeteo centro = new CentroMeteo();
        DisplayConsole cd = new DisplayConsole();
        DisplayMobile md = new DisplayMobile();

        centro.Registra(cd);
        centro.Registra(md);

        bool x = true;
        
        do 
        {
            Console.WriteLine("\n-- Menù --");
            Console.WriteLine("0. Esci");
            Console.WriteLine("1. Aggiorna meteo");
            Console.Write("Scelta: ");
            int sceltamenu = int.Parse(Console.ReadLine());
        
            switch (sceltamenu)
            {
                case 0:
                    x = false;
                    break;
        
                case 1:
                    // richiesta dell'aggiornamento meteo e notifica agli osservatori
                    Console.Write($"Inserisci l'aggiornamento meteo: ");
                    string messaggio = Console.ReadLine();
                    centro.AggiornaMeteo(messaggio);
                    break;
        
                default:
                    Console.WriteLine("Scelta non valida.");
                    break;
            }
        }
        while (x);
    }
}

// interfacce Observer e Subject per il pattern Observer
public interface IObserver
{
    void Update(string messaggio);
}

public interface ISubject
{
    void Registra(IObserver observer);
    void Rimuovi(IObserver observer);
    void Notifica(string messaggio);
}

// Classe reale che implementa l'observable
public class CentroMeteo : ISubject
{
    private readonly List<IObserver> _observers = new List<IObserver>();

    public void Notifica(string messaggio)
    {
        foreach (var observer in _observers)
        {
            observer.Update(messaggio);
        }
    }

    public void Registra(IObserver observer)
    {
        _observers.Add(observer);
    }

    public void Rimuovi(IObserver observer)
    {
        _observers.Remove(observer);
    }

    public void AggiornaMeteo(string messaggio)
    {
        Console.WriteLine($"Aggiornamento del meteo : {messaggio}");
        Notifica(messaggio);
    }
}

// Observer concreti
public class DisplayConsole : IObserver
{
    public void Update(string messaggio)
    {
        Console.WriteLine($"[Console] ha ricevuto l'aggiornamento: {messaggio}");
    }
}

public class DisplayMobile : IObserver
{
    public void Update(string messaggio)
    {
        Console.WriteLine($"[Mobile] ha ricevuto l'aggiornamento: {messaggio}");
    }
}