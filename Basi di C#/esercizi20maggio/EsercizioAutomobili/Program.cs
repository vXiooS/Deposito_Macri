using System;

class Program
{
    static void Main(string[] args)
    {
        //inserimento dell'utente
        Console.WriteLine($"Inserisci i tuoi dati: ");
        Console.Write("Nome: ");
        string nome = Console.ReadLine();
        Console.Write("Credito: ");
        int credito = int.Parse(Console.ReadLine());

        Utente u = new Utente(nome, credito);

        //inserimento dei dati dell'auto    
        Console.WriteLine($"Inserisci i dati della tua auto: ");
        Console.Write($"Motore: ");
        string motore = Console.ReadLine();
        Console.Write($"Velocità massima: ");
        float vmax = float.Parse(Console.ReadLine());
        Console.Write($"Sospensioni massime: ");
        int smax = int.Parse(Console.ReadLine());
        Automobile a = new Automobile(motore, vmax, smax);
        Console.WriteLine($"Automobile inserita! ");

        //modifica dell'auto tramite il metodo Modifica della classe Automobile
        a.Modifica(a, u);

        //stampa dell'auto, utilizzando il tostring, dopo la modifica
        Console.WriteLine(a);
    }
}

class Automobile
{
    string motore;
    float velocitaMax;
    int sospensioniMax;
    int nrModifiche = 0;

    public Automobile(string motore, float velocitaMax, int sospensioniMax)
    {
        this.motore = motore;
        this.velocitaMax = velocitaMax;
        this.sospensioniMax = sospensioniMax;
    }

    public override string ToString()
    {
        return $"Motore: {motore}, velocità massima {velocitaMax}, sospensioni massime {sospensioniMax}, numero di modifiche: {nrModifiche}";
    }

    public void Modifica(Automobile a, Utente u)
    {
        
        do
        {
            Console.WriteLine($"");
            Console.WriteLine($"Modifiche rimaste: {u.credito}");
            
            //menu di scelta delle modifiche
            Console.WriteLine($"1: motore");
            Console.WriteLine($"2: velocità massima");
            Console.WriteLine($"3: sospensioni massime");
            Console.WriteLine($"4: esci");

            Console.Write($"Cosa vuoi modificare? ");
            int scelta = int.Parse(Console.ReadLine());

            //switch per i vari casi di scelta delle modifiche 
            switch (scelta)
            {
                case 1:
                    Console.Write($"Inserisci il nuovo motore: ");
                    a.motore = Console.ReadLine();
                    nrModifiche++;
                    u.credito--;
                    break;
                case 2:
                    Console.WriteLine($"Aumento della velocità massima di 10");
                    a.velocitaMax += 10;
                    nrModifiche++;
                    u.credito--;
                    break;
                case 3:
                    Console.WriteLine("Aumento delle sospensioni di 1");
                    a.sospensioniMax++;
                    nrModifiche++;
                    u.credito--;
                    break;
                case 4:
                    u.credito = 0;
                    break;
                default:
                    Console.WriteLine($"Scelta non valida");
                    break;
            }
        }
        while (u.credito > 0);
        
    }
}

class Utente
{
    public string nome;
    public int credito;

    public Utente(string nome, int credito)
    {
        this.nome = nome;
        this.credito = credito;
    }
}
