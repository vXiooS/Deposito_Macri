using System;

class Program
{
    static void Main(string[] args)
    {
        //lista dei soldati 
        List<Soldato> soldati = new List<Soldato>();

        //bool su cui continua il successivo do while
        bool x = true;
        do
        {
            //menu di scelta dell'operazione 
            Console.WriteLine($"1: aggiungi Fante");
            Console.WriteLine($"2: aggiungi Artigliere");
            Console.WriteLine($"3: visualizza tutti i soldati");
            Console.WriteLine($"0: esci");
            Console.Write($"Cosa vuoi fare? ");
            int sceltamenu = int.Parse(Console.ReadLine());

            switch (sceltamenu)
            {
                //uscita dal ciclo
                case 0:
                    x = false;
                    break;
                //inserimento del fante: nome, grado e anni di servizio sono dati della clase padre Soldato, "arma" è un dato aggiunto dalla classe derivata Fante  
                case 1:
                    Console.WriteLine($"Inserisci i dati del fante");
                    Console.Write($"Nome: ");
                    string nome = Console.ReadLine();
                    Console.Write($"Grado: ");
                    string grado = Console.ReadLine();
                    Console.Write($"Anni di servizio: ");
                    int annis = int.Parse(Console.ReadLine());
                    Console.Write($"Arma in dotazione: ");
                    string arma = Console.ReadLine();

                    Fante f = new Fante(nome, grado, annis, arma);
                    soldati.Add(f);
                    break;
                //inserimento dell'artigliere: nome, grado e anni di servizio sono dati della clase padre Soldato, "calibro" è un dato aggiunto dalla classe derivata Arigliere      
                case 2:
                    Console.WriteLine($"Inserisci i dati dell'artigliere");
                    Console.Write($"Nome: ");
                    string nome2 = Console.ReadLine();
                    Console.Write($"Grado: ");
                    string grado2 = Console.ReadLine();
                    Console.Write($"Anni di servizio: ");
                    int annis2 = int.Parse(Console.ReadLine());
                    Console.Write($"Calibro gestito: ");
                    int calibro = int.Parse(Console.ReadLine());

                    Artigliere a = new Artigliere(nome2, grado2, annis2, calibro);
                    soldati.Add(a);
                    break;
                //stampa di tutti i soldati nella lista, indipendentemente dal loro tipo derivato    
                case 3:
                    foreach (Soldato s in soldati)
                    {
                        s.Descrizione();
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

public class Soldato
{
    private string _nome;
    private string _grado;

    private int _anniServizio;

    public Soldato(string n, string g, int a)
    {
        _nome = n;
        _grado = g;
        _anniServizio = a;
    } 

    public string Nome
    {
        get { return _nome; }
        set { _nome = value; }
    }

    public string Grado
    {
        get { return _grado; }
        set { _grado = value; }
    }

    public int anniServizio
    {
        get { return _anniServizio; }
        set
        {
            if (value >= 0)
            {
                _anniServizio = value;
            }
        }
    }

    public virtual void Descrizione()
    {
        Console.WriteLine($"Nome: {Nome}, grado: {Grado}, anni di servizio: {anniServizio}");
    }
}

public class Fante : Soldato
{
    private string _arma;

    public Fante(string n, string g, int a, string arma) : base(n, g, a)
    {
        _arma = arma;
    }

    public string Arma
    {
        get { return _arma; }
        set { _arma = value; }
    }

    public override void Descrizione()
    {
        Console.WriteLine($"Nome: {Nome}, grado: {Grado}, anni di servizio: {anniServizio}, arma in dotazione: {Arma}");
    }
}

public class Artigliere : Soldato
{
    private int _calibro;

    public Artigliere(string n, string g, int a, int calibro) : base(n, g, a)
    {
        _calibro = calibro;
    }

    public int Calibro
    {
        get { return _calibro; }
        set
        {
            if (value > 0)
            {
                _calibro = value;
            }
        }
    }

    public override void Descrizione()
    {
        //Console.WriteLine($"{base.Descrizione} , calibro gestito: {Calibro}");
        Console.WriteLine($"Nome: {Nome}, grado: {Grado}, anni di servizio: {anniServizio}, calibro gestito: {Calibro}");
        
    }
}


