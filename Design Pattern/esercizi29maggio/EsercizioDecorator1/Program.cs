using System;
using System.ComponentModel;

class Program
{
    public static void Main(string[] args)
    {
        // scelta del tipo di bevanda
        Console.WriteLine($"Cosa vuoi ordinare? ");
        Console.WriteLine($"1: Caffè");
        Console.WriteLine($"2: Tè");
        int ordine = int.Parse(Console.ReadLine());
        IBevanda bevanda;

        if (ordine == 1)
        {
            bevanda = new Caffe();
        }
        else if (ordine == 2)
        {
            bevanda = new Te();
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
            Console.WriteLine("1. Aggiungi latte");
            Console.WriteLine("2. Aggiungi cioccolato");
            Console.WriteLine("3. Aggiungi panna");
            Console.Write("Scelta: ");
            int sceltamenu = int.Parse(Console.ReadLine());
        
            switch (sceltamenu)
            {
                case 0:
                    // uscita dal menu, stampa della descrizione della bevanda
                    Console.WriteLine($"Hai ordinato: {bevanda.Descrizione()}");
                    Console.WriteLine($"Il costo totale è: {bevanda.Costo()} euro");
                    x = false;
                    break;
        
                case 1:
                    // aggiunta del latte alla bevanda
                    bevanda = new ConLatte(bevanda);
                    Console.WriteLine($"Hai aggiunto latte. {bevanda.Descrizione()}");
                    Console.WriteLine($"Il costo totale è: {bevanda.Costo()} euro");
                    break;
        
                case 2:
                    // aggiunta del cioccolato alla bevanda
                    bevanda = new ConCioccolato(bevanda);
                    Console.WriteLine($"Hai aggiunto cioccolato. {bevanda.Descrizione()}");
                    Console.WriteLine($"Il costo totale è: {bevanda.Costo()} euro");
                    break;

                case 3:
                    // aggiunta della panna alla bevanda
                    bevanda = new ConPanna(bevanda);
                    Console.WriteLine($"Hai aggiunto panna. {bevanda.Descrizione()}");
                    Console.WriteLine($"Il costo totale è: {bevanda.Costo()} euro");
                    break;
        
                default:
                    Console.WriteLine("Scelta non valida.");
                    break;
            }
        }
        while (x);

    }
}

// interfaccia implementata da tutte le bevande
public interface IBevanda
{
    string Descrizione();
    double Costo();

}

public class Caffe : IBevanda
{
    public string Descrizione()
    {
        return "Caffè";
    }

    public double Costo()
    {
        return 1.00;
    }
}

public class Te : IBevanda
{
    public string Descrizione()
    {
        return "Tè";
    }

    public double Costo()
    {
        return 1.80;
    }
}

// classe astratta, Decorator base delle bevande
public abstract class DecoratoreBevanda : IBevanda
{
    protected IBevanda _bevanda;

    protected DecoratoreBevanda(IBevanda bevanda)
    {
        _bevanda = bevanda;
    }

    public virtual double Costo()
    {
        return _bevanda.Costo();
    }

    public virtual string Descrizione()
    {
        return _bevanda.Descrizione();
    }
}

// Decoratori specifici per le bevande
public class ConLatte : DecoratoreBevanda
{
    public ConLatte(IBevanda bevanda) : base(bevanda)
    {
    }

    public override double Costo()
    {
        return base.Costo() + 0.2;
    }

    public override string Descrizione()
    {
        return base.Descrizione() + " con latte.";
    }
}

public class ConCioccolato : DecoratoreBevanda
{
    public ConCioccolato(IBevanda bevanda) : base(bevanda)
    {
    }

    public override double Costo()
    {
        return base.Costo() + 0.25;
    }

    public override string Descrizione()
    {
        return base.Descrizione() + " con cioccolato.";
    }
}

public class ConPanna : DecoratoreBevanda
{
    public ConPanna(IBevanda bevanda) : base(bevanda)
    {
    }

    public override double Costo()
    {
        return base.Costo() + 0.1;
    }

    public override string Descrizione()
    {
        return base.Descrizione() + " con panna.";
    }
}



