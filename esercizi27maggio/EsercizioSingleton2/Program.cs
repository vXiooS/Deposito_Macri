using System;

class Program
{
    static void Main(string[] args)
    {
        bool x = true;
        
        // ciclo principale del menù
        do 
        {
            // istanza del logger
            Logger l = Logger.GetInstance();
            Logger l2 = Logger.GetInstance();

            Console.WriteLine("\n-- Menù --");
            Console.WriteLine("0. Esci");
            Console.WriteLine("1. Aggiungi log (istanza 1)");
            Console.WriteLine("1. Aggiungi log (istanza 2)");
            Console.WriteLine("3. Mostra log");
            Console.Write("Scelta: ");
            int sceltamenu = int.Parse(Console.ReadLine());
        
            switch (sceltamenu)
            {
                case 0:
                    x = false;
                    break;
        
                case 1:
                    // Aggiungi un log tramite l'istanza 1                
                    Console.Write("Inserisci il messaggio da loggare: ");
                    string m1 = Console.ReadLine();
                    l2.InsLog(m1);
                    break;
        
                case 2:
                    // Aggiungi un log tramite l'istanza 2
                    Console.Write("Inserisci il messaggio da loggare: ");
                    string m2 = Console.ReadLine();
                    l2.InsLog(m2);
                    break;

                case 3:
                    // Mostra i log
                    Console.WriteLine("\n--- Log ---");
                    l.ShowLogs();
                    break;    
        
                default:
                    Console.WriteLine("Scelta non valida.");
                    break;
            }
        }
        while (x);
    }
}


public sealed class Logger
{
    private static Logger _instance;

    private Logger() { }

    public static Logger GetInstance()
    {
        if (_instance == null)
        {
            _instance = new Logger();
        }
        return _instance;
    }

    private List<string> logs = new List<string>();

    public void InsLog(string message)
    {
        logs.Add(message);
    }

    public void ShowLogs()
    {
        foreach (string log in logs)
        {
            Console.WriteLine(log);
        }
    }
}
