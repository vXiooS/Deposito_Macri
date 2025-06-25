using System;
using System.Diagnostics.Tracing;

class Operazioni
{
    static void Main(string[] args)
    {

        int x = 0;
        int y = 0;

        try
        {
            //input dall'utente dei numeri
            Console.Write("Inserisci il primo numero: ");
            x = int.Parse(Console.ReadLine());
            Console.Write("Inserisci il secondo numero: ");
            y = int.Parse(Console.ReadLine());

            //menu di scelta dell'operazione
            Console.WriteLine($"Che operazione vuoi fare?");
            Console.WriteLine($"1: somma");
            Console.WriteLine($"2: moltiplicazione");
            Console.WriteLine($"3: divisione");
            int scelta = int.Parse(Console.ReadLine());

            switch (scelta)
            {
                case 1:
                    StampaRisultato("somma", Somma(x, y));
                break;

                case 2:
                    StampaRisultato("moltiplicazione", Moltiplicazione(x, y));
                break;

                case 3:
                    StampaRisultato("divisione", Divisione(x, y));
                break;

                default:
                    Console.WriteLine($"Scelta non valida!");
                break;
            }
            
        }
        catch (FormatException)
        {
            System.Console.WriteLine("Non hai inserito un numero!");
        }

    }


    static int Somma(int x, int y)
    {
        int somma = x + y;
        return somma;
    }

    static int Moltiplicazione(int x, int y)
    {
        int mol = x * y;
        return mol;
    }

    static object Divisione(int x, int y)
    {
        double res = 0;

        try
        {
            res = x / y;
            return res;
        }
        catch (DivideByZeroException)
        {
            return ($"Non valido");
        }
        
    }

    static void StampaRisultato(string op, object risultato)
    {
        Console.WriteLine($"Il risultato dell'operazione {op} è {risultato}");
    }


}
