using System;

class Program
{
    public static void Main(string[] args)
    {
        // scelta del piatto base
        Console.WriteLine($"Cosa vuoi mangiare?");
        Console.WriteLine($"1) Pizza");
        Console.WriteLine($"2) Hamburger");
        Console.WriteLine($"3) Insalata");
        Console.Write($"Scegli il piatto: ");
        string scelta = Console.ReadLine().ToLower();
        IPiatto p = PiattoFactory.CreaPiatto(scelta);
        if (p == null)
        {
            Console.WriteLine("Scelta non valida.");
            return;
        }


        // menù di scelta degli ingredienti extra
        bool x = true;
        do
        {
            Console.WriteLine("\n-- Vuoi aggiungere qualcosa? --");
            Console.WriteLine("0. Esci");
            Console.WriteLine("1. Aggiungi formaggio");
            Console.WriteLine("2. Aggiungi bacon");
            Console.WriteLine("3. Aggiungi salsa");
            Console.Write("Scelta: ");
            int sceltaAggiunte = int.Parse(Console.ReadLine());

            switch (sceltaAggiunte)
            {
                case 0:
                    x = false;
                    break;

                case 1:
                    p = new ConFormaggioDecorator(p);
                    break;

                case 2:
                    p = new ConBaconDecorator(p);
                    break;

                case 3:
                    p = new ConSalsaDecorator(p);
                    break;

                default:
                    Console.WriteLine("Scelta non valida.");
                    break;
            }
        }
        while (x);

        Chef chef = new Chef();
        // scelta del metodo di cottura
            Console.WriteLine("1. Fritto");
            Console.WriteLine("2. Alla griglia");
            Console.WriteLine("3. Al forno");
            Console.Write("Scelta: ");
            int sceltaCottura = int.Parse(Console.ReadLine());

            switch (sceltaCottura)
            {
                case 1:
                    chef.ImpostaPreparazione(new Fritto());
                    break;

                case 2:
                    chef.ImpostaPreparazione(new AllaGriglia());
                    break;

                case 3:
                    chef.ImpostaPreparazione(new AlForno());
                    break;

                default:
                    Console.WriteLine("Scelta non valida.");
                    break;
            }

        Console.WriteLine($"Ordine completato");
        Console.WriteLine($"Piatto: {p.Descrizione()}");
        Console.WriteLine($"Preparazione: {chef.PreparaPiatto(p)}");
    }
}


public interface IPiatto
{
    string Descrizione();
    string Prepara();
}

public class Pizza : IPiatto
{
    public string Descrizione()
    {
        return "Pizza";
    }

    public string Prepara()
    {
        return "Preparazione della pizza";
    }
}

public class Hamburger : IPiatto
{
    public string Descrizione()
    {
        return "Hamburger";
    }

    public string Prepara()
    {
        return "Preparazione dell'hamburger";
    }
}

public class Insalata : IPiatto
{
    public string Descrizione()
    {
        return "Insalata";
    }

    public string Prepara()
    {
        return "Preparazione dell'insalata";
    }
}

public abstract class IngredienteExtra : IPiatto
{
    protected IPiatto _piatto;

    public IngredienteExtra(IPiatto piatto)
    {
        _piatto = piatto;
    }

    public virtual string Descrizione()
    {
        return _piatto.Descrizione();
    }

    public virtual string Prepara()
    {
        return _piatto.Prepara();
    }
}


public class ConFormaggioDecorator : IngredienteExtra
{
    public ConFormaggioDecorator(IPiatto piatto) : base(piatto) { }

    public override string Descrizione()
    {
        return _piatto.Descrizione() + " con formaggio";
    }

    public override string Prepara()
    {
        return _piatto.Prepara() + " e aggiunta di formaggio";
    }
}

public class ConBaconDecorator : IngredienteExtra
{
    public ConBaconDecorator(IPiatto piatto) : base(piatto) { }

    public override string Descrizione()
    {
        return _piatto.Descrizione() + " con bacon";
    }

    public override string Prepara()
    {
        return _piatto.Prepara() + " e aggiunta di bacon";
    }
}

public class ConSalsaDecorator : IngredienteExtra
{
    public ConSalsaDecorator(IPiatto piatto) : base(piatto) { }

    public override string Descrizione()
    {
        return _piatto.Descrizione() + " con salsa";
    }

    public override string Prepara()
    {
        return _piatto.Prepara() + " e aggiunta di salsa";
    }
}

public static class PiattoFactory
{
    public static IPiatto CreaPiatto(string tipo)
    {
        if (tipo == "pizza")
        {
            return new Pizza();
        }
        else if (tipo == "hamburger")
        {
            return new Hamburger();
        }
        else if (tipo == "insalata")
        {
            return new Insalata();
        }
        else
        {
            Console.WriteLine("Tipo di piatto non valido");
            return null;
        }
    }
}

public interface IPreparazione
{
    string Prepara(string desc);
}

public class Fritto : IPreparazione
{
    public string Prepara(string desc)
    {
        return $"{desc} fritto";
    }
}

public class AllaGriglia : IPreparazione
{
    public string Prepara(string desc)
    {
        return $"{desc} alla griglia";
    }
}

public class AlForno : IPreparazione
{
    public string Prepara(string desc)
    {
        return $"{desc} al forno";
    }
}

public class Chef 
{
    private IPreparazione _preparazione;

    public void ImpostaPreparazione(IPreparazione preparazione)
    {
        _preparazione = preparazione;
    }

    public string PreparaPiatto(IPiatto piatto)
    {
        if (_preparazione == null)
        {
            return "Nessun metodo di preparazione impostato.";
        }
        return _preparazione.Prepara(piatto.Descrizione());
    }
}
