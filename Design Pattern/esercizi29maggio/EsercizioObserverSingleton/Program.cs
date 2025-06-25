using System;

class Program
{
    static void Main(string[] args)
    {
        NewsAgency agency = NewsAgency.GetInstance();
        MobileApp mobileApp = new MobileApp();
        EmailClient emailClient = new EmailClient();

        agency.Register(mobileApp);
        agency.Register(emailClient);

        bool x = true;
        
        do 
        {
            Console.WriteLine("\n-- Menù --");
            Console.WriteLine("0. Esci");
            Console.WriteLine("1. aggiungi news");
            Console.Write("Scelta: ");
            int sceltamenu = int.Parse(Console.ReadLine());
        
            switch (sceltamenu)
            {
                case 0:
                    x = false;
                    break;
        
                case 1:
                    Console.Write($"Inserisci news: ");
                    string news = Console.ReadLine();
                    agency.News = news;
                    break;
        
                default:
                    Console.WriteLine("Scelta non valida.");
                    break;
            }
        }
        while (x);
    }
}

public interface IObserver
{
    void Update(string messaggio);
}

public interface ISubject
{
    string News { get; set; }
    void Register(IObserver observer);
    void Unregister(IObserver observer);
    void Notify(string message);
}

public sealed class NewsAgency : ISubject
{
    private static NewsAgency _instance;

    private NewsAgency () {}

    public static NewsAgency GetInstance ()
        {
            if (_instance == null)
            {
                _instance = new NewsAgency();
            }
            return _instance;
        }

    private string _news;

    public string News
    {
        get { return _news; }
        set
        {
            _news = value;
            Notify(_news);
        }
    }

    private readonly List<IObserver> _observers = new List<IObserver>();

    public void Register(IObserver observer)
    {
        _observers.Add(observer);
    }

    public void Unregister(IObserver observer)
    {
        _observers.Remove(observer);
    }

    public void Notify(string message)
    {
        foreach (var observer in _observers)
        {
            observer.Update(News);
        }
    }
}

public class MobileApp : IObserver
{
    public void Update(string messaggio)
    {
        Console.WriteLine($"Notifica su mobile: {messaggio}");
    }
}

public class EmailClient : IObserver
{
    public void Update(string messaggio)
    {
        Console.WriteLine($"Email : {messaggio}");
    }
}
