using System;
using System.Diagnostics.Contracts;

class Program
{
    static void Main(string[] args)
    {

        List<IPagamento>  pagamenti = new List<IPagamento>();

        bool x = true;
        
        // ciclo principale del menù
        do 
        {
            Console.WriteLine("\n-- Menù --");
            Console.WriteLine("1. pagamento con carta");
            Console.WriteLine("2. pagamento in contanti");
            Console.WriteLine("3. pagamento con paypal");
            Console.WriteLine("4. esegui pagamenti");
            Console.WriteLine("5. Esci");
            Console.Write("Scelta: ");
            int sceltamenu = int.Parse(Console.ReadLine());
        
            switch (sceltamenu)
            {
                case 0:
                    x = false;
                    break;

                case 1:
                    PagamentoCarta pc = new PagamentoCarta();
                    Console.Write($"Inserisci il circuito della carta: ");
                    pc.Circuito = Console.ReadLine();
                    pagamenti.Add(pc);
                    break;

                case 2:
                    PagamentoContanti pcon = new PagamentoContanti();
                    pagamenti.Add(pcon);
                    break;
        
                case 4:
                    PagamentoPaypal pp = new PagamentoPaypal();
                    Console.Write($"Inserisci l'email associata a Paypal: ");
                    pp.EUtente  = Console.ReadLine();
                    pagamenti.Add(pp);
                    break;
        
                case 5:
                    foreach (IPagamento p in pagamenti)
                    {
                        p.MostraMetodo();
                        Console.Write($"Inserisci l'importo: ");
                        decimal importo = int.Parse(Console.ReadLine());
                        p.EseguiPagamento(importo);
                    }
                    break;

                default:
                    Console.WriteLine("Scelta non valida.");
                    break;
            }
        }
        while (x);
    }
}

public interface IPagamento
{
    public void EseguiPagamento(decimal importo);
    public void MostraMetodo();
}

public class PagamentoCarta : IPagamento
{
    private string _circuito;

    public string Circuito
    {
        get { return _circuito; }
        set { _circuito = value; }
    }

    public void EseguiPagamento(decimal importo)
    {
        Console.WriteLine($"Pagamento di {importo} euro con carta (circuito: {Circuito})");
    }

    public void MostraMetodo()
    {
        Console.WriteLine($"Metodo : carta di credito \n");
    }
}

public class PagamentoContanti : IPagamento
{
    public void EseguiPagamento(decimal importo)
    {
        Console.WriteLine($"Pagamento di {importo} euro in contanti");
    }

    public void MostraMetodo()
    {
        Console.WriteLine($"Metodo : contanti \n");
    }
}

public class PagamentoPaypal : IPagamento
{
    private string eUtente;

    public string EUtente
    {
        get { return eUtente; }
        set { eUtente = value;}
    }

    public void EseguiPagamento(decimal importo)
    {
        Console.WriteLine($"Pagamento di {importo} euro tramite Paypal da {EUtente}");
    }

    public void MostraMetodo()
    {
        Console.WriteLine($"Metodo : Paypal \n");
    }
}
