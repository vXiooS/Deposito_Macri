using System;

class Program
{
    static void Main(string[] args)
    {
        Singleton istanza1 = Singleton.GetIstanza();
        Singleton istanza2 = Singleton.GetIstanza();

        istanza1.ScriviMessaggio("Sistema avviato.");
        istanza2.ScriviMessaggio("Connessione al database stabilita.");

        Console.WriteLine($"Le due istanze sono uguali: {istanza1 == istanza2}");
        Console.WriteLine($"Programma terminato.");
    }
}

public sealed class Singleton
{
    private static Singleton _instance;

    private Singleton() { }

    public static Singleton GetIstanza()
    {
        if (_instance == null)
        {
            _instance = new Singleton();
        }
        return _instance;
    }

    public void ScriviMessaggio(string messaggio)
    {
        Console.WriteLine($"[{DateTime.Now}] : {messaggio}");
    }

}
