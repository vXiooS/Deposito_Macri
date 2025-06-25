using System;
using System.Runtime.CompilerServices;

class Program
{
    static void Main(string[] args)
    {

        VoloAereo v = new VoloAereo();

        Console.WriteLine($"Inserisci il tuo codice di volo: ");
        v.CodiceVolo = Console.ReadLine();
        v.VisualizzaStato();

        bool x = true;
        do
        {
            Console.WriteLine($"1: prenota posti");
            Console.WriteLine($"2: annulla prenotazione");
            Console.WriteLine($"2: esci");
            
            Console.Write($"Cosa vuoi fare? ");
            int scelta = int.Parse(Console.ReadLine());

            switch (scelta)
            {
                case 1:
                    Console.Write($"Quanti posti vuoi prenotare: ");
                    int pp = int.Parse(Console.ReadLine());
                    v.EffettuaPrenotazione(pp);
                    v.VisualizzaStato();
                    break;
                case 2:
                    Console.Write($"Quanti posti vuoi annullare: ");
                    int ap = int.Parse(Console.ReadLine());
                    v.AnnullaPrenotazione(ap);
                    v.VisualizzaStato();
                    break;
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

public class VoloAereo
{
    private int _postiOccupati = 0;
    private const int _maxPosti = 150;

    private string _codiceVolo;

    public string CodiceVolo { get; set; }
    

    public int PostiOccupati
    {
        get { return _postiOccupati;}
    }

    public int PostiLiberi
    {
        get { return _maxPosti - _postiOccupati; }
    }

    public void EffettuaPrenotazione(int n)
    {
        if (n == 0)
        {
            Console.WriteLine($"Numero non valido");
        }
        else if (n <= PostiLiberi)
        {
            _postiOccupati += n;
            Console.WriteLine($"La prenotazione è andata a buon fine. Posti prenotati: {n}");
        }
        else
        {
            Console.WriteLine($"Insufficenti posti disponibili");
        }
    }

    public void AnnullaPrenotazione(int n)
    {
        if (n == 0)
        {
            Console.WriteLine($"Numero non valido");
        }
        else if (n > 0 && n <= PostiLiberi)
        {
            _postiOccupati -= n;
            Console.WriteLine($"L'annullamento è andato a buon fine. Posti annullati: {n}");
        }
        else
        {
            Console.WriteLine($"Insufficenti posti disponibili");
        }
    }

    public void VisualizzaStato()
    {
        Console.WriteLine($"Codice volo: {CodiceVolo} ,posti occupati {PostiOccupati}, posti liberi {PostiLiberi}");
        
    }
}