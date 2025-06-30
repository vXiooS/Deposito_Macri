using System;
using System.Runtime.CompilerServices;

class Program
{
    static void Main(string[] args)
    {
        //lista dei veicoli
        List<Veicolo> veicoli = new List<Veicolo>();

        //ciclo per far girare il programma finchè non si decide di uscire
        bool x = true;
        do
        {
            Console.WriteLine($"1: aggiungi Auto");
            Console.WriteLine($"2: aggiungi Moto");
            Console.WriteLine($"3: aggiungi Camion");
            Console.WriteLine($"4: ripara veicoli");
            Console.WriteLine($"5: cambia la targa di un veicolo");
            Console.WriteLine($"0: esci");
            Console.Write($"Cosa vuoi fare? ");
            int sceltamenu = int.Parse(Console.ReadLine());

            switch (sceltamenu)
            {
                //uscita dal programma
                case 0:
                    x = false;
                    break;

                //case 1, 2, 3 consentono l'aggiunta di un nuovo Veicolo (di diverso tipo) nella lista    
                case 1:
                    Console.Write($"Inserisci la targa: ");
                    string atarga = Console.ReadLine();
                    veicoli.Add(new Auto(atarga));
                    break;
                case 2:
                    Console.Write($"Inserisci la targa: ");
                    string mtarga = Console.ReadLine();
                    veicoli.Add(new Moto(mtarga));
                    break;
                case 3:
                    Console.Write($"Inserisci la targa: ");
                    string ctarga = Console.ReadLine();
                    veicoli.Add(new Camion(ctarga));
                    break;

                //ripara tutti gli elementi nella lista di Veicoli    
                case 4:
                    foreach (Veicolo v in veicoli)
                    {
                        if (v.Nmodifiche < 3)
                        {
                            v.Ripara();
                            v.Nmodifiche++;
                        }
                    }
                    break;

                //scelta di un Veicolo nella lista data la targa, e inserimento di una nuova targa
                case 5:
                    Console.Write($"Inserisci la vecchia targa: ");
                    string vtarga = Console.ReadLine();
                    Console.Write($"Inserisci la nuova targa: ");
                    string ntarga = Console.ReadLine();

                    foreach (Veicolo v in veicoli)
                    {
                        if (v.Targa == vtarga)
                        {
                            if (v.Nmodifiche < 3)
                            {
                                v.Ripara(ntarga);
                                v.Nmodifiche++;
                            }
                            else
                            {
                                Console.WriteLine($"Numero massimo di riparazioni raggiunto");
                            }
                            
                        }
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
    private string _targa;

    private int _nmodifiche = 0;

    public string Targa
    {
        get { return _targa; }
        set { _targa = value; }
    }

    public int Nmodifiche
    {
        get { return _nmodifiche; }
        set { _nmodifiche = value;}
    }

    public Veicolo(string targa)
    {
        _targa = targa;
    }

    public virtual void Ripara()
    {
        Console.WriteLine($"Il veicolo con targa {Targa} viene controllato.");
    }

    public virtual void Ripara(string newtarga)
    {
    }

}

public class Auto : Veicolo
{
    public Auto(string targa) : base(targa)
    {
    }

    public override void Ripara()
    {
        Console.WriteLine($"Controllo olio, freni, motore dell'auto con targa {Targa}.");
    }

    public override void Ripara(string newtarga)
    {
        Targa = newtarga;
        Console.WriteLine($"Targa cambiata in {newtarga}");
    }

}

public class Moto : Veicolo
{
    public Moto(string targa) : base(targa)
    {
    }

    public override void Ripara()
    {
        Console.WriteLine($"Controllo catena, freni, gomme della moto con targa {Targa}.");
    }

    public override void Ripara(string newtarga)
    {
        Targa = newtarga;
        Console.WriteLine($"Targa cambiata in {newtarga}");
    }

}

public class Camion : Veicolo
{
    public Camion(string targa) : base(targa)
    {
    }

    public override void Ripara()
    {
        Console.WriteLine($"Controllo sospensioni, freni, carico del camion con targa {Targa}.");
    }

    public override void Ripara(string newtarga)
    {
        Targa = newtarga;
        Console.WriteLine($"Targa cambiata in {newtarga}");
    }
}
