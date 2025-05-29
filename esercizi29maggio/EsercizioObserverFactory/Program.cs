using System;

class Program
{
    public static void Main(string[] args)
    {
        // istanzia del singleton GestioneCreazioneUtente
        GestioneCreazioneUtente g = GestioneCreazioneUtente.GetInstance();
        // registrazione dei moduli osservatori
        g.Registra(new ModuloLog());
        g.Registra(new ModuloMarketing());

        bool x = true;
        
        do 
        {
            Console.WriteLine("\n-- Menù --");
            Console.WriteLine("0. Esci");
            Console.WriteLine("1. Crea utente");
            Console.Write("Scelta: ");
            int sceltamenu = int.Parse(Console.ReadLine());
        
            switch (sceltamenu)
            {
                case 0:
                    x = false;
                    break;
        
                case 1:
                    // richiesta del nome utente e creazione dell'utente
                    Console.Write($"Inserisci nome utente: ");
                    string nome = Console.ReadLine();
                    g.CreaUtente(nome);
                    break;
        
                default:
                    Console.WriteLine("Scelta non valida.");
                    break;
            }
        }
        while (x);
    }
}

// interfaccia Observer e Subject per il pattern Observer
public interface IObserver
{
    void NotificaCreazione(string nUtente);
}

public interface ISubject
{
    void Registra(IObserver observer);
    void Rimuovi(IObserver observer);
    void Notifica(string nUtente);
}

// Classe reale che implementa l'observable
public class GestioneCreazioneUtente : ISubject
{
    private static GestioneCreazioneUtente _instance;
    private readonly List<IObserver> _observers = new List<IObserver>();

    private GestioneCreazioneUtente() { }

    public static GestioneCreazioneUtente GetInstance()
    {
        if (_instance == null)
        {
            _instance = new GestioneCreazioneUtente();
        }
        return _instance;
    }

    public void Registra(IObserver observer)
    {
        _observers.Add(observer);
    }

    public void Rimuovi(IObserver observer)
    {
        _observers.Remove(observer);
    }

    public void Notifica(string nUtente)
    {
        foreach (var observer in _observers)
        {
            observer.NotificaCreazione(nUtente);
        }
    }

    public void CreaUtente(string nome)
    {
        Utente u = UserFactory.CreaUtente(nome);
        Console.WriteLine($"Utente creato: {u}");
        Notifica(u.Nome);
    }
}

// Factory per la creazione di utenti
public static class UserFactory
{
    public static Utente CreaUtente(string nome)
    {
        return new Utente(nome);
    }
}

public class Utente
{
    public string Nome { get; set; }

    public Utente(string nome)
    {
        Nome = nome;
    }

    public override string ToString()
    {
        return "Utente: " + Nome;
    }
}

// Moduli Observer
public class ModuloLog : IObserver
{
    public void NotificaCreazione(string nUtente)
    {
        Console.WriteLine($"[Log] Utente creato {nUtente}");
    }
}

public class ModuloMarketing : IObserver
{
    public void NotificaCreazione(string nUtente)
    {
        Console.WriteLine($"[Marketing] Invia email a {nUtente}");
    }
}