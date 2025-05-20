using System;
using System.Diagnostics.Contracts;

class Program
{
    static void Main(string[] args)
    {
        Libro l1 = new Libro("Oshi no Ko", "Aka Akasaka", 2020);
        Libro l2 = new Libro("Houseki no Kuni", "Haruko Ichikawa", 2012);
        Libro l3 = new Libro("Oshi no Ko", "Aka Akasaka", 2020);

        //stampa i Libri utilizzando il toString
        Console.WriteLine(l1);
        Console.WriteLine(l2);
        Console.WriteLine(l3);

        //controllo se i Libri sono uguali con Equals
        Console.WriteLine("l1 = l2? " + l1.Equals(l2));
        Console.WriteLine("l1 = l3? " + l1.Equals(l3));
        
        //controllo degli Hash con getHashCode
        Console.WriteLine($"hash l1: {l1.GetHashCode()}");
        Console.WriteLine($"hash l2: {l2.GetHashCode()}");
        Console.WriteLine($"hash l3: {l3.GetHashCode()}");
    }
}

public class Libro
{
    string titolo;
    string autore;
    int annoPublicazione;

    //costruttore di Libro
    public Libro(string titolo, string autore, int annoPublicazione)
    {
        this.titolo = titolo;
        this.autore = autore;
        this.annoPublicazione = annoPublicazione;
    }

    //override di toString, ritorna i dati di Libro stampati in maniera leggibile
    public override string ToString()
    {
        return $"'{titolo}' di {autore} ({annoPublicazione})";
    }

    //override di Equals, controlla se autore e titolo di 2 oggetti sono uguali
    public override bool Equals(object? obj)
    {
        if (obj is Libro l)
        {
            return titolo == l.titolo && autore == l.autore;
        }
        return false;
    }

    //override di HashCode, ritorna l'hash univoco
    public override int GetHashCode()
    {
        return HashCode.Combine(titolo, autore);
    }   
}
