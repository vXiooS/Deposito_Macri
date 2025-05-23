using System;
using Microsoft.Win32.SafeHandles;

class Program
{
    static void Main(string[] args)
    {
        List<Veicolo> veicoli = new List<Veicolo>();

        // veicoli.Add(new AutoAziendale("Honda", "jazz", 2003, "fg345sd", true));
        // veicoli.Add(new AutoAziendale("Toyota", "Yaris", 2017, "gb455ee", false));
        // veicoli.Add(new FurgoneAziendale("Fiat", "fiorino", 2006, 144));
        // foreach (Veicolo v in veicoli)
        // {
        //     v.StampaInfo();
        // }

        bool x = true;
        do
        {
            Console.WriteLine($"1: aggiungi auto aziendale");
            Console.WriteLine($"2: aggiungi furgone aziendale");
            Console.WriteLine($"3: stampa lista veicoli");
            Console.WriteLine($"0: esci");
            Console.Write($"Cosa vuoi fare? ");
            int sceltamenu = int.Parse(Console.ReadLine());

            switch (sceltamenu)
            {
                case 0:
                    x = false;
                    break;
                case 1:
                    Console.Write($"Inserisci la marca: ");
                    string amarca = Console.ReadLine();
                    Console.Write($"Inserisci il modello: ");
                    string amodello = Console.ReadLine();
                    Console.Write($"Inserisci l'anno di immatricolazione: ");
                    int aanno = int.Parse(Console.ReadLine());
                    Console.Write($"Inserisci la targa: ");
                    string atarga = Console.ReadLine();
                    Console.Write($"Uso privato (true/false): ");
                    bool auso = bool.Parse(Console.ReadLine());

                    AutoAziendale a = new AutoAziendale(amarca, amodello, aanno, atarga, auso);
                    veicoli.Add(a);
                    break;

                case 2:
                    Console.Write($"Inserisci la marca: ");
                    string fmarca = Console.ReadLine();
                    Console.Write($"Inserisci il modello: ");
                    string fmodello = Console.ReadLine();
                    Console.Write($"Inserisci l'anno di immatricolazione: ");
                    int fanno = int.Parse(Console.ReadLine());
                    Console.Write($"Inserisci la capacità di carico: ");
                    int fcarico = int.Parse(Console.ReadLine());

                    FurgoneAziendale f = new FurgoneAziendale(fmarca, fmodello, fanno, fcarico);
                    veicoli.Add(f);
                    break;
                case 3:
                    foreach (Veicolo v in veicoli)
                    {
                        v.StampaInfo();
                    }
                    break;
                default:
                Console.WriteLine($"Scelta non valida");
                    break;
            }
        }
        while (x);

    }
}


public class Veicolo
{
    private string _marca;

    private string _modello;

    private int _annoImmatricolazione;

    public Veicolo(string marca, string modello, int annoImmatricolazione)
    {
        _marca = marca;
        _modello = modello;
        _annoImmatricolazione = annoImmatricolazione;
    }

    public string Marca
    {
        get { return _marca; }
        set { _marca = value; }
    }

    public string Modello
    {
        get { return _modello; }
        set { _modello = value; }
    }

    public int AnnoImmatricolazione
    {
        get { return _annoImmatricolazione; }
        set { _annoImmatricolazione = value; }
    }

    public virtual void StampaInfo()
    {
        Console.WriteLine($"Marca: {Marca}, Modello: {Modello}, Anno di immatricolazione: {AnnoImmatricolazione}");
    }
}

public class AutoAziendale : Veicolo
{
    private string _targa;

    private bool _usoPrivato;

    public AutoAziendale(string marca, string modello, int annoImmatricolazione, string targa, bool usoPrivato) : base(marca, modello, annoImmatricolazione)
    {
        _targa = targa;
        _usoPrivato = usoPrivato;
    }

    public string Targa
    {
        get { return _targa; }
        set { _targa = value; }
    }

    public bool UsoPrivato
    {
        get { return _usoPrivato; }
        set { _usoPrivato = value; }
    }

    public override void StampaInfo()
    {
        base.StampaInfo();
        Console.WriteLine($"Targa: {Targa}, Abilitata all'uso privato: {UsoPrivato}\n");
    }
}

public class FurgoneAziendale : Veicolo
{
    private int _capacitaCarico;

    public FurgoneAziendale(string marca, string modello, int annoImmatricolazione, int capacitaCarico) : base(marca, modello, annoImmatricolazione)
    {
        _capacitaCarico = capacitaCarico;
    }

    public int CapacitaCarico
    {
        get { return _capacitaCarico; }
        set { _capacitaCarico = value; }
    }

    public override void StampaInfo()
    {
        base.StampaInfo();
        Console.WriteLine($"Capacità di carico: {CapacitaCarico}\n");
    }
}
