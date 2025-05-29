using System;

class Program
{
    public static void Main(string[] args)
    {
        // scelta del tipo di torta
        Console.WriteLine($"Che tipo di torta vuoi ordinare? ");
        Console.WriteLine($"1: Torta al cioccolato");
        Console.WriteLine($"2: Torta alla vaniglia");
        Console.WriteLine($"3: Torta alla frutta");
        int sceltaTorta = int.Parse(Console.ReadLine());
        ITorta torta;

        if (sceltaTorta == 1)
        {
            torta = TortaFactory.CreaTortaBase("cioccolato");
        }
        else if (sceltaTorta == 2)
        {
            torta = TortaFactory.CreaTortaBase("vaniglia");
        }
        else if (sceltaTorta == 3)
        {
            torta = TortaFactory.CreaTortaBase("frutta");
        }
        else
        {
            Console.WriteLine("Opzione non valida.");
            return;
        }
        
        bool x = true;
        
        // ciclo principale del menù
        do 
        {
            Console.WriteLine("\n-- Vuoi aggiungere qualcosa? --");
            Console.WriteLine("0. Esci");
            Console.WriteLine("1. Aggiungi panna");
            Console.WriteLine("2. Aggiungi fragole");
            Console.WriteLine("3. Aggiungi glassa");
            Console.Write("Scelta: ");
            int sceltamenu = int.Parse(Console.ReadLine());
        
            switch (sceltamenu)
            {
                case 0:
                    //uscita dal menu, stampa della descrizione della torta
                    Console.WriteLine($"Hai ordinato: {torta.Descrizione()}");
                    x = false;
                    break;
        
                case 1:
                    // aggiunta della panna alla torta
                    torta = new ConPanna(torta);
                    Console.WriteLine($"Hai aggiunto panna. {torta.Descrizione()}");
                    break;
        
                case 2:
                    // aggiunta delle fragole alla torta
                    torta = new ConFragole(torta);
                    Console.WriteLine($"Hai aggiunto fragole. {torta.Descrizione()}");
                    break;

                case 3:
                    // aggiunta della glassa alla torta
                    torta = new ConGlassa(torta);
                    Console.WriteLine($"Hai aggiunto glassa. {torta.Descrizione()}");
                    break;

                default:
                    Console.WriteLine("Scelta non valida.");
                    break;
            }
        }
        while (x);
    }
}

//interfaccia implementata da tutte le torte
public interface ITorta
{
    string Descrizione();
}

public class TortaCioccolato : ITorta
{
    public string Descrizione()
    {
        return "Torta al cioccolato";
    }
}

public class TortaVaniglia : ITorta
{
    public string Descrizione()
    {
        return "Torta alla vaniglia";
    }
}

public class TortaFrutta : ITorta
{
    public string Descrizione()
    {
        return "Torta alla frutta";
    }
}

// Decorator astratto per le torte
public abstract class TortaDecorator : ITorta
{
    protected ITorta _torta;

    public TortaDecorator(ITorta torta)
    {
        _torta = torta;
    }

    public virtual string Descrizione()
    {
        return _torta.Descrizione();
    }
}

// Decoratori specifici per le torte
public class ConPanna : TortaDecorator
{
    public ConPanna(ITorta torta) : base(torta) { }

    public override string Descrizione()
    {
        return _torta.Descrizione() + " con panna";
    }
}

public class ConFragole : TortaDecorator
{
    public ConFragole(ITorta torta) : base(torta) { }

    public override string Descrizione()
    {
        return _torta.Descrizione() + " con fragole";
    }
}

public class ConGlassa : TortaDecorator
{
    public ConGlassa(ITorta torta) : base(torta) { }

    public override string Descrizione()
    {
        return _torta.Descrizione() + " con glassa";
    }
}

// Factory per la creazione di ogni tipo di torta
public static class TortaFactory
{
    public static ITorta CreaTortaBase(string tipo)
    {
        if (tipo == "cioccolato")
        {
            return new TortaCioccolato();
        }
        else if (tipo == "vaniglia")
        {
            return new TortaVaniglia();
        }
        else if (tipo == "frutta")
        {
            return new TortaFrutta();
        }
        else
        {
            Console.WriteLine("Tipo di torta non valido");
            return null;
        }
    }
}

