using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine($"Ciao! Registrati: ");

        Console.Write($"Inserisci il Nickname: ");
        string nickname = Console.ReadLine();
        Console.Write("Inserisci la password: ");
        string password = Console.ReadLine();
        Console.Write("Inserisci l'età: ");
        int eta = int.Parse(Console.ReadLine());

        Utente u = new Utente(nickname, password, eta);

        Console.WriteLine($"Utente Registrato!");
        Console.WriteLine($"");
        Console.WriteLine($"Effettua il Login: ");
        Console.Write($"Inserisci il Nickname: ");
        string nt = Console.ReadLine();
        Console.Write("Inserisci la password: ");
        string pt = Console.ReadLine();

        Utente ut = new Utente(nt, pt);

        if (!ut.Equals(u))
        {
            Console.WriteLine($"Credenziali errate.");
            return;
        }
        else
        {
            Console.WriteLine($"Login effettuato!");
            Console.WriteLine($"Benvenuto nella calcolatrice");
            
            Calcolatrice c = new Calcolatrice();

            Console.Write($"Inserisci il primo numero: ");
            int n1 = int.Parse(Console.ReadLine());
            Console.Write($"Inserisci il secondo numero: ");
            int n2 = int.Parse(Console.ReadLine());

            Console.Write($"Che operazione vuoi fare? (1:somma, 2:moltiplicazione, 3:divisione) ");
            int scelta = int.Parse(Console.ReadLine());

            switch (scelta)
            {
                case 1:
                    Console.WriteLine($"Il risultato della somma è {c.Somma(n1,n2)}");
                break;
                case 2:
                    Console.WriteLine($"Il risultato della moltiplicazione è {c.Moltiplicazione(n1,n2)}");
                break;
                case 3:
                    Console.WriteLine($"Il risultato della divisione è {c.Divisione(n1,n2)}");
                break;
                default:
                    Console.WriteLine($"Scelta non valida.");
                return;
            }
        }

    }
}


public class Utente
{
    string nickname;
    string password;
    int eta;

    public Utente(string nickname, string password, int eta)
    {
        this.nickname = nickname;
        this.password = password;
        this.eta = eta;
    }

    public Utente(string nickname, string password)
    {
        this.nickname = nickname;
        this.password = password;
    }

    public override bool Equals(object obj)
    {
        if (obj is Utente u)
        {
            return nickname == u.nickname && password == u.password;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(nickname, password);
    }
}

public class Calcolatrice
{
    public int Somma(int n1, int n2)
    {
        return n1 + n2;
    }

    public int Moltiplicazione(int n1, int n2)
    {
        return n1 * n2;
    }

    public int Divisione(int n1, int n2)
    {
        return n1 / n2;
    }
}
