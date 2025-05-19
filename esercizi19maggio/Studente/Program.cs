using System;

class Program
{
    static void Main(string[] args)
    {
        int x = 1;

        string nome = "";
        int numm = 0;
        double mv = 0;


        while (x <= 2)
        {
                Console.Write($"Inserisci il nome: ");
                nome = Console.ReadLine();
                Console.Write($"Inserisci il numero di matricola: ");
                numm = int.Parse(Console.ReadLine());
                Console.Write($"Inserisci la media dei voti: ");
                mv = double.Parse(Console.ReadLine());

            if (x == 1)
            {
                Studente s1 = new Studente(nome, numm, mv);
                s1.Stampa();
            }
            else if (x == 2)
            {
                Studente s2 = new Studente(nome, numm, mv);
                s2.Stampa();
            }
                x++;
            }

    }

    class Studente
    {
        public string Nome;
        public int Matricola;
        public double MediaVoti;

        public Studente(string nome, int m, double mv)
        {
            Nome = nome;
            Matricola = m;
            MediaVoti = mv;
        }

        public void Stampa()
        {
            Console.WriteLine($"Nome: {Nome}, Numero matricola: {Matricola}, media dei voti {MediaVoti}");
        }

    }
}    