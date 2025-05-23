using System;

class Program
{
    static void Main(string[] args)
    {
        //lista di oggetti Operatore
        Console.WriteLine($"--Gestionale operatori--\n");
        List<Operatore> operatori = new List<Operatore>();

        //ciclo per far continuare il programma finchè non si decide di uscire
        bool x = true;
        do
        {
            Console.WriteLine($"");
            Console.WriteLine($"1: aggiungi operatore emergenza");
            Console.WriteLine($"2: aggiungi operatore sicurezza");
            Console.WriteLine($"3: aggiungi operatore logistica");
            Console.WriteLine($"4: stampa lista di tutti gli operatori");
            Console.WriteLine($"5: compito eseguito dagli operatori");
            Console.WriteLine($"0: esci");
            Console.Write($"Cosa vuoi fare? ");
            int sceltamenu = int.Parse(Console.ReadLine());

            switch (sceltamenu)
            {
                //uscita dal programma
                case 0:
                    x = false;
                    break;

                //case 1, 2, 3 consentono l'inserimento di un Operatore di diverso tipo    
                case 1:
                    Console.Write($"Inserisci il nome dell'operatore: ");
                    string ename = Console.ReadLine();
                    Console.Write($"Inserisci il turno dell'operatore: ");
                    string eturno = Console.ReadLine();
                    Console.Write($"Inserisci il grado di emergenza: ");
                    int em = int.Parse(Console.ReadLine());
                    operatori.Add(new OperatoreEmergenza(ename, eturno, em));
                    break;
                case 2:
                    Console.Write($"Inserisci il nome dell'operatore: ");
                    string sname = Console.ReadLine();
                    Console.Write($"Inserisci il turno dell'operatore: ");
                    string sturno = Console.ReadLine();
                    Console.Write($"Inserisci l'area sorvegliata: ");
                    string areas = Console.ReadLine();
                    operatori.Add(new OperatoreSicurezza(sname, sturno, areas));
                    break;
                case 3:
                    Console.Write($"Inserisci il nome dell'operatore: ");
                    string lname = Console.ReadLine();
                    Console.Write($"Inserisci il turno dell'operatore: ");
                    string lturno = Console.ReadLine();
                    Console.Write($"Inserisci il numero di consegne: ");
                    int lcon = int.Parse(Console.ReadLine());
                    operatori.Add(new OperatoreLogistica(lname, lturno, lcon));
                    break;

                //stampa di tutti gli elementi nella lista operatori     
                case 4:
                    foreach (Operatore o in operatori)
                    {
                        Console.WriteLine($"{((Operatore)o).ToString()}");
                        
                    }
                    break;

                //stampa del compito di ogni operatore nella lista operatori 
                case 5:
                    foreach (Operatore o in operatori)
                    {
                        o.EseguiCompito();
                    }
                    break;        
            }        
        }
        while (x);

    }
}

public class Operatore
{
    private string _nome;
    private string _turno;

    public Operatore(string nome, string turno)
    {
        _nome = nome;
        _turno = turno;
    }
    public string Nome
    {
        get { return _nome; }
        set { _nome = value; }
    }

    public string Turno
    {
        get { return _turno; }
        set
        {
            if (value.ToLower() == "giorno" || value.ToLower() == "notte")
            {
                _turno = value;
            }
        }
    }

    public override string ToString()
    {
        return $"Nome: {Nome}, tipo operatore: {GetType()} Turno: {Turno}";
    }  
    public virtual void EseguiCompito()
    {
        Console.WriteLine($"Operatore in servizio");
    }
}


public class OperatoreEmergenza : Operatore
{
    private int _livelloUrgenza;

    public OperatoreEmergenza(string nome, string turno, int liv) : base(nome, turno)
    {
        _livelloUrgenza = liv;
    }

    public int LivelloUrgenza
    {
        get { return _livelloUrgenza; }
        set
        {
            if (value >= 1 && value <= 5)
            {
                _livelloUrgenza = value;
            }
        }
    }


    public override void EseguiCompito()
    {
        Console.WriteLine($"{Nome}: Gestione emergenza di livello {LivelloUrgenza}");
    }
}

public class OperatoreSicurezza : Operatore
{
    private string _areaSorvegliata;

    public OperatoreSicurezza(string nome, string turno, string area) : base(nome, turno)
    {
        _areaSorvegliata = area;
    }

    public string AreaSorvegliata
    {
        get { return _areaSorvegliata; }
        set { _areaSorvegliata = value; }
    }

    public override void EseguiCompito()
    {
        Console.WriteLine($"{Nome}: Sorveglianza dell'area {AreaSorvegliata}");
    }

}

public class OperatoreLogistica : Operatore
{
    private int _numConsegne;

    public OperatoreLogistica(string nome, string turno, int n) : base(nome, turno)
    {
        _numConsegne = n;
    }

    public int NumConsegne
    {
        get { return _numConsegne; }
        set
        {
            if (value >= 0)
            {
                _numConsegne = value;
            }
        }
    }

    public override void EseguiCompito()
    {
        Console.WriteLine($"{Nome}: Coordinamento di {NumConsegne} consegne");
    }
}
