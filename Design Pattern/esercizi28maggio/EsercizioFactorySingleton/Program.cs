using System;

class Program
{
    public static void Main(string[] args)
    {
        RegistroVeicoli registro = RegistroVeicoli.Instance;

        bool x = true;
        
        // ciclo principale del menù
        do 
        {
            Console.WriteLine("\n-- Menù --");
            Console.WriteLine("0. Esci");
            Console.WriteLine("1. Inserisci veicoli");
            Console.WriteLine("2. Stampa veicoli registrati");
            Console.Write("Scelta: ");
            int sceltamenu = int.Parse(Console.ReadLine());
        
            switch (sceltamenu)
            {
                case 0:
                    x = false;
                    break;
        
                case 1:
                    registro.RegistraVeicolo();
                    break;
        
                case 2:
                    registro.MostraVeicoli();
                    break;
        
                default:
                    Console.WriteLine("Scelta non valida.");
                    break;
            }
        }
        while (x);
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

public sealed class RegistroVeicoli
{
    private static RegistroVeicoli _instance;

    public List<IVeicolo> veicoliCreati;

    private RegistroVeicoli()
    {
        veicoliCreati = new List<IVeicolo>();
    }

    public static RegistroVeicoli Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new RegistroVeicoli();
            }
            return _instance;
        }
    }

    public void RegistraVeicolo()
    {
        bool x = true;
        do
        {
            Console.WriteLine("Scegli il tipo di veicolo da registrare:");
            Console.WriteLine("1. Auto");
            Console.WriteLine("2. Moto");
            Console.WriteLine("3. Camion");
            Console.WriteLine("0. Annulla");
            Console.Write("Scelta: ");
            int scelta = int.Parse(Console.ReadLine());

            IVeicolo veicolo = null;
            switch (scelta)
            {
                case 1:
                    veicolo = new AutoFactory().CreaVeicolo();
                    veicoliCreati.Add(veicolo);
                    break;

                case 2:
                    veicolo = new MotoFactory().CreaVeicolo();
                    veicoliCreati.Add(veicolo);
                    break;

                case 3:
                    veicolo = new CamionFactory().CreaVeicolo();
                    veicoliCreati.Add(veicolo);
                    break;

                case 0:
                    x = false;
                    break;

                default:
                    Console.WriteLine("Scelta non valida.");
                    break;
            }
        }
        while (x);
    }

    public void MostraVeicoli()
    {
        foreach (var v in veicoliCreati)
        {
            v.MostraTipo();
        }
    }
}

