using System;
using System.Diagnostics.Contracts;
using System.Reflection.Metadata.Ecma335;

class Program
{
    static void Main(string[] args)
    {
        List<Film> videoteca = new List<Film>();

        Console.WriteLine($"Benvenuto nella videoteca!");

        //contatore dei film inseriti
        int counter = 0;
        //bool da verificare nel while
        bool x = true;
        while (x)
        {
            //inserimento dei dati del film
            Console.WriteLine($"Inserisci un film");
            Console.Write($"Titolo: ");
            string titolo = Console.ReadLine();
            Console.Write($"Regista: ");
            string regista = Console.ReadLine();
            Console.Write($"Anno: ");
            int anno = int.Parse(Console.ReadLine());
            Console.Write($"Genere: ");
            string genere = Console.ReadLine();

            //aggiunta del film alla lista
            Film f = new Film(titolo, regista, anno, genere);
            videoteca.Add(f);

            //aumento del contatore per ogni film inserito
            counter++;

            //se abbiamo inserito 3 film, chiede se vogliamo inserirne altri o uscire
            if (counter >= 3)
            {
                Console.Write($"Vuoi inserire un altro film? (y/n) ");
                string scelta = Console.ReadLine();
                if (scelta == "y")
                {
                    //se la scelta è y, il programma riparte dall'inizio del while richiedendo un nuovo film
                }
                else if (scelta == "n")
                {
                    x = false;
                }
            }
        }

        //stampa tutti i film della videoteca
        foreach (Film film in videoteca)
        {
            Console.WriteLine(film);
        }

        //ricerca per un parametro
        Console.Write($"Per cosa vuoi cercare? (titolo, regista, anno, genere) ");
        string sceltaCerca = Console.ReadLine().ToLower();

        //stampa tutti i film dato un parametro di ricerca e il suo valore
        switch (sceltaCerca)
        {
            case "titolo":
                Console.Write("Inserisci un titolo per cercare film: ");
                string cercaTitolo = Console.ReadLine();

                foreach (Film film in videoteca)
                {
                    if (film.titolo.ToLower() == cercaTitolo.ToLower())
                    {
                        Console.WriteLine(film);
                    }
                }
            break;

            case "regista":
                Console.Write("Inserisci un regista per cercare film: ");
                string cercaRegista = Console.ReadLine();

                foreach (Film film in videoteca)
                {
                    if (film.regista.ToLower() == cercaRegista.ToLower())
                    {
                        Console.WriteLine(film);
                    }
                }
            break;

            case "anno":
                Console.Write("Inserisci un anno per cercare film: ");
                int cercaAnno = int.Parse(Console.ReadLine());

                foreach (Film film in videoteca)
                {
                    if (film.anno == cercaAnno)
                    {
                        Console.WriteLine(film);
                    }
                }
            break;
            
            case "genere":
                Console.Write("Inserisci un genere per cercare film: ");
                string cercaGenere = Console.ReadLine();

                foreach (Film film in videoteca)
                {
                    if (film.genere.ToLower() == cercaGenere.ToLower())
                    {
                        Console.WriteLine(film);
                    }
                }
            break;
            
        }    

    }
}

class Film
{
    public string titolo;
    public string regista;
    public int anno;
    public string genere;

    public Film(string titolo, string regista, int anno, string genere)
    {
        this.titolo = titolo;
        this.regista = regista;
        this.anno = anno;
        this.genere = genere;
    }

    public override string ToString()
    {
        return $"'{titolo}', diretto da {regista} ({anno}). Genere: {genere}";
    }
}