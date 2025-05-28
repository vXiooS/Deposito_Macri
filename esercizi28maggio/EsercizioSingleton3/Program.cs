using System;


class Program
{
    static void Main(string[] args)
    {

        ModuloA modA = new ModuloA();
        ModuloB modB = new ModuloB();
        modA.Configura();
        modB.Configura();

        bool x = true;
        
        
        do 
        {
            Console.WriteLine("\n-- Menù --");
            Console.WriteLine("0. Esci");
            Console.WriteLine("1. Inserisci config in Modulo A");
            Console.WriteLine("2. Inserisci config in Modulo B");
            Console.WriteLine("3. Verifica istanza");
            Console.WriteLine("4. Stampa tutte le configurazioni");
            Console.Write("Scelta: ");
            int sceltamenu = int.Parse(Console.ReadLine());
        
            switch (sceltamenu)
            {
                case 0:
                    x = false;
                    break;
        
                case 1:
                    Console.Write($"Inserisci la chiave per il Modulo A: ");
                    string keyA = Console.ReadLine();
                    Console.Write($"Inserisci il valore: ");
                    string valA = Console.ReadLine();
                    modA.ImpostaConfig(keyA, valA);
                    break;
        
                case 2:
                    Console.Write($"Inserisci la chiave per il Modulo B: ");
                    string keyB = Console.ReadLine();
                    Console.Write($"Inserisci il valore: ");
                    string valB = Console.ReadLine();
                    modA.ImpostaConfig(keyB, valB);
                    break;
        
                case 3:
                    Console.WriteLine($"Verifica accesso unificato: " +  (ConfigSystem.GetInstance == ConfigSystem.GetInstance));
                    break;
        
                case 4:
                    ConfigSystem.GetInstance.StampaTutte();
                    break;
        
                default:
                    Console.WriteLine("Scelta non valida.");
                    break;
            }
        }
        while (x);
    }
}


public sealed class ConfigSystem
{
    private static ConfigSystem _instance;

    private ConfigSystem()
    {
        configs = new Dictionary<string, string>();
    }

    public static ConfigSystem GetInstance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new ConfigSystem();
            }
            return _instance;
        }
    }

    private Dictionary<string, string> configs;

    public void Imposta(string key, string value)
    {
        configs[key] = value;
    }

    public string Ottieni(string key)
    {
        if (configs.ContainsKey(key))
        {
            return configs[key];
        }
        else
        {
            throw new KeyNotFoundException($"La chiave '{key}' non esiste nel sistema di configurazione.");
        }
    }

    public void StampaTutte()
    {
        foreach (var pair in configs)
        {
            Console.WriteLine($"{pair.Key}: {pair.Value}");
        }
    }
}


public class ModuloA
{
    public void Configura()
    {
        ConfigSystem config = ConfigSystem.GetInstance;
    }

    public void ImpostaConfig(string key, string value)
    {
        ConfigSystem.GetInstance.Imposta(key, value);
    }
}

public class ModuloB
{
    public void Configura()
    {
        ConfigSystem config = ConfigSystem.GetInstance;
    }

    public void ImpostaConfig(string key, string value)
    {
        ConfigSystem.GetInstance.Imposta(key, value);
    }
}
