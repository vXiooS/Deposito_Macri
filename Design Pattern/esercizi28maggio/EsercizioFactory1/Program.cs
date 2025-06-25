using System;
using System.Diagnostics.Contracts;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine($"Benvenuto nel sistema di creazione veicoli!");
        Console.WriteLine($"Scegli il tipo di veicolo da creare (auto, moto, camion):");
        string tipoVeicolo = Console.ReadLine();

        Menu menu = new Menu();
        IVeicolo v = menu.CreaVeicolo(tipoVeicolo);
        if (v != null)
        {
            v.Avvia();
            v.MostraTipo();
        }
        else
        {
            Console.WriteLine("Nessun veicolo creato.");
        }
    }    
}

public interface IVeicolo
{
    void Avvia();
    void MostraTipo();
}

public class Auto : IVeicolo
{
    public void Avvia()
    {
        Console.WriteLine("L'auto è stata avviata.");
    }

    public void MostraTipo()
    {
        Console.WriteLine($"Tipo di veicolo: {GetType()}");
    }
}

public class Moto : IVeicolo
{
    public void Avvia()
    {
        Console.WriteLine("La moto è stata avviata.");
    }

    public void MostraTipo()
    {
        Console.WriteLine($"Tipo di veicolo: {GetType()}");
    }
}

public class Camion : IVeicolo
{
    public void Avvia()
    {
        Console.WriteLine("Il camion è stato avviato.");
    }

    public void MostraTipo()
    {
        Console.WriteLine($"Tipo di veicolo: {GetType()}");
    }
}

public abstract class VeicoloFactory
{
    public abstract IVeicolo CreaVeicolo();
}

public class AutoFactory : VeicoloFactory
{
    public override IVeicolo CreaVeicolo()
    {
        return new Auto();
    }
}

public class MotoFactory : VeicoloFactory
{
    public override IVeicolo CreaVeicolo()
    {
        return new Moto();
    }
}

public class CamionFactory : VeicoloFactory
{
    public override IVeicolo CreaVeicolo()
    {
        return new Camion();
    }
}

public class Menu
{
    public IVeicolo CreaVeicolo(string tipo)
    {
        switch (tipo.ToLower())
        {
            case "auto":
                return new AutoFactory().CreaVeicolo();
            case "moto":
                return new MotoFactory().CreaVeicolo();
            case "camion":
                return new CamionFactory().CreaVeicolo();
            default:
                Console.WriteLine($"Tipo non riconosciuto");
                return null;
        }
    }
}

