using System;
using System.Runtime.ConstrainedExecution;
using Microsoft.VisualBasic;

class Program
{
    static void Main(string[] args)
    {
        PrenotazioneViaggio p = new PrenotazioneViaggio();

        Console.Write($"Inserisci la destinazione del viaggio: ");
        p.Destinazione = Console.ReadLine();

        Console.Write($"Quanti posti vuoi prenotare: ");
        int pp = int.Parse(Console.ReadLine());
        p.PrenotaPosti(pp);
        p.Stampa();

        Console.Write($"Quanti posti vuoi prenotare: ");
        int pp2 = int.Parse(Console.ReadLine());
        p.PrenotaPosti(pp2);
        p.Stampa();

        Console.Write($"Quanti posti vuoi annullare: ");
        int ap = int.Parse(Console.ReadLine());
    }
}



class PrenotazioneViaggio
{

    private int _maxPosti = 20;
    private int _postiPrenotati;

    private string _destinazione;

    private int postiDisponibili;

    public string Destinazione { get; set; }

    //sola lettura
    public int PostiPrenotati
    {
        get { return _postiPrenotati;}
    }

    //sola lettura, calcolo dei posti non prenotati
    public int PostiDisponibili
    {
        get { return _maxPosti - PostiPrenotati; }
    }

    //metodo per la prenotazione dei posti
    public void PrenotaPosti(int n)
    {
        if (n == 0)
        {
            Console.WriteLine($"Numero non valido");
        }
        else if (n <= PostiDisponibili)
        {
            _postiPrenotati += n;
            Console.WriteLine($"La prenotazione è andata a buon fine. Posti prenotati: {n}");
        }
        else
        {
            Console.WriteLine($"Insufficenti posti disponibili");
        }
    }

    //metodo per l'annullazione dei posti prenotati, inverso a quello della prenotazione
    public void AnnullaPrenotazione(int n)
    {
        if (n == 0)
        {
            Console.WriteLine($"Numero non valido");
        }
        else if (n> 0 && n <= PostiDisponibili)
        {
            _postiPrenotati -= n;
            Console.WriteLine($"L'annullamento è andato a buon fine. Posti annullati: {n}");
        }
        else
        {
            Console.WriteLine($"Insufficenti posti disponibili");
        }
    }

    //tostring per stampare destinazione e posti prenotati e disponibili
    public void Stampa()
    {
        Console.WriteLine($"Destinazione: {Destinazione} \n Posti prenotati: {PostiPrenotati} \n Posti disponibili: {PostiDisponibili}");
    }

}
