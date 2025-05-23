using System;

class Program
{
    static void Main(string[] args)
    {
        ContoCorrente c = new ContoCorrente(0);

        c.Versa(64);
        c.Versa(4);

        c.Preleva(85);
        c.Preleva(45);

        Console.WriteLine($"Numero di operazioni effettuate: {c.NumeroOperazioni}");
    }
}

public class ContoCorrente
{
    private decimal _saldo;

    private int _numeroOperazioni;

    public ContoCorrente(decimal saldo)
    {
        _saldo = saldo;
    }
    public decimal Saldo
    {
        get { return _saldo; }
    }

    public int NumeroOperazioni
    {
        get { return _numeroOperazioni; }
    }

    public void Versa(decimal importo)
    {
        if (importo > 0)
        {
            _saldo += importo;
            _numeroOperazioni++;
            Console.WriteLine($"versamento andato a buon fine. Il saldo ora è {Saldo}");
        }
        else
        {
            Console.WriteLine($"L'importo non può essere minore o uguale a 0");
        }
    }

    public void Preleva(decimal importo)
    {
        if (importo <= _saldo)
        {
            _saldo -= importo;
            _numeroOperazioni++;
            Console.WriteLine($"prelievo andato a buon fine. Il saldo ora è {Saldo}");
        }
        else
        {
            Console.WriteLine($"Importo più grande del saldo");
        }
    }
}
