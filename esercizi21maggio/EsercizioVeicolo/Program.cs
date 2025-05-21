using System;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine($"benvenuto nel garage \n");
        List<Veicolo> garage = new List<Veicolo>();
        
        //ciclo per far continuare le operazioni finche non si decide di uscire
        bool x = true;
        do
        {            
            //menu di scelta dell'operazione da eseguire
            Console.WriteLine($"1: aggiungi veicolo");
            Console.WriteLine($"2: visualizza garage");
            Console.WriteLine($"3: esci");
            Console.Write($"Cosa vuoi fare? ");
            int sceltamenu = int.Parse(Console.ReadLine());

            //switch per i vari casi di scelta
            switch (sceltamenu)
            {
                //case 1: input di auto o moto nel garage
                case 1:
                    Console.Write($"Vuoi inserire un auto o una moto? ");
                    string sceltaaom = Console.ReadLine();

                    if (sceltaaom == "auto")
                    {
                        Console.Write($"Marca: ");
                        string marca = Console.ReadLine();
                        Console.Write($"Modello: ");
                        string modello = Console.ReadLine();
                        Console.Write($"Numero porte: ");
                        int numPorte = int.Parse(Console.ReadLine());

                        Auto a = new Auto(marca, modello, numPorte);
                        garage.Add(a);
                    }
                    else if (sceltaaom == "moto")
                    {
                        Console.Write($"Marca: ");
                        string marca = Console.ReadLine();
                        Console.Write($"Modello: ");
                        string modello = Console.ReadLine();
                        Console.Write($"Tipo manubrio: ");
                        string tManubrio = Console.ReadLine();

                        Moto m = new Moto(marca, modello, tManubrio);
                        garage.Add(m);
                    }
                    else
                    {
                        Console.WriteLine($"Scelta non valida");
                    }

                    break;

                // stampa di tutti i veicoli nel garage
                case 2:
                    foreach (Veicolo v in garage)
                    {
                        Console.WriteLine(v.StampaInfo());
                    }
                    break;

                // uscita dal ciclo
                case 3:
                    x = false;
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
    protected string marca;
    protected string modello;

    public Veicolo(string marca, string modello)
    {
        this.marca = marca;
        this.modello = modello;
    }

    public virtual string StampaInfo()
    {
        return $"Marca: {marca}, Modello: {modello} ";
    }
}

public class Auto : Veicolo
{

    protected int numeroPorte;

    public Auto(string marca, string modello, int numeroPorte) : base(marca, modello)
    {
        this.marca = marca;
        this.modello = modello;
        this.numeroPorte = numeroPorte;
    }

    public override string StampaInfo()
    {
        return $"Marca: {marca}, Modello: {modello} , numero porte: {numeroPorte}";
    }
}

public class Moto : Veicolo
{
    protected string tipoManubrio;

    public Moto(string marca, string modello, string tipoManubrio) : base(marca, modello)
    {
        this.marca = marca;
        this.modello = modello;
        this.tipoManubrio = tipoManubrio;
    }

    public override string StampaInfo()
    {
        return $"Marca: {marca}, Modello: {modello} , tipo manubrio: {tipoManubrio}";
    }
}
