using System;

class Program
{
    public static void Main(string[] args)
    {
        GestoreOrdine gestoreOrdine = GestoreOrdine.GetInstance();

        gestoreOrdine.GestisciOrdine();
    }
}


// factory
public interface IPizza
{
    string Descrizione();
}

public class PizzaMargherita : IPizza
{
    public string Descrizione()
    {
        return "Pizza margherita";
    }
}

public class PizzaDiavola : IPizza
{
    public string Descrizione()
    {
        return "Pizza diavola";
    }
}

public class PizzaVegetariana : IPizza
{
    public string Descrizione()
    {
        return "Pizza vegetariana";
    }
}

public static class PizzaFactory
{
    public static IPizza CreaPizza(string tipo)
    {
        switch (tipo.ToLower())
        {
            case "margherita":
                return new PizzaMargherita();
            case "diavola":
                return new PizzaDiavola();
            case "vegetariana":
                return new PizzaVegetariana();
            default:
                throw new ArgumentException("Tipo di pizza non valido");
        }
    }
}


// decorator
public abstract class IngredienteDecorator : IPizza
{
    protected IPizza pizza;

    public IngredienteDecorator(IPizza pizza)
    {
        this.pizza = pizza;
    }

    public virtual string Descrizione()
    {
        return pizza.Descrizione();
    }
}

public class ConOlive : IngredienteDecorator
{
    public ConOlive(IPizza pizza) : base(pizza) { }

    public override string Descrizione()
    {
        return pizza.Descrizione() + " con olive";
    }
}

public class ConMozzarellaExtra : IngredienteDecorator
{
    public ConMozzarellaExtra(IPizza pizza) : base(pizza) { }

    public override string Descrizione()
    {
        return pizza.Descrizione() + " con mozzarella extra";
    }
}

public class ConFunghi : IngredienteDecorator
{
    public ConFunghi(IPizza pizza) : base(pizza) { }

    public override string Descrizione()
    {
        return pizza.Descrizione() + " con funghi";
    }
}


// strategy
public interface IMetodoCottura
{
    string Cuoci(string pizza);
}

public class FornoElettrico : IMetodoCottura
{
    public string Cuoci(string pizza)
    {
        return $"Cuocendo '{pizza}' in forno elettrico";
    }
}

public class FornoLegna : IMetodoCottura
{
    public string Cuoci(string pizza)
    {
        return $"{pizza} cotta in forno a legna";
    }
}

public class FornoVentilato : IMetodoCottura
{
    public string Cuoci(string pizza)
    {
        return $"{pizza} cotta in forno ventilato";
    }
}


// singleton
public sealed class GestoreOrdine : IPizza
{
    private static GestoreOrdine _instance;

    private GestoreOrdine() { }

    public static GestoreOrdine GetInstance()
    {
        if (_instance == null)
        {
            _instance = new GestoreOrdine();
        }
        return _instance;
    }

    private readonly List<IObserver> _observers = new List<IObserver>();

    private IMetodoCottura _metodoCottura;

    public void ImpostaMetodoCottura(IMetodoCottura metodoCottura)
    {
        _metodoCottura = metodoCottura;
    }


    IPizza pizza = null;
    public void GestisciOrdine()
    {
            Console.WriteLine("Scegli il tipo di pizza:");
            Console.WriteLine("1. Margherita");
            Console.WriteLine("2. Diavola");
            Console.WriteLine("3. Vegetariana");
            Console.Write("Scelta: ");
            int scelta = int.Parse(Console.ReadLine());

            switch (scelta)
            {
                case 1:
                    pizza = PizzaFactory.CreaPizza("margherita");
                    break;
                case 2:
                    pizza = PizzaFactory.CreaPizza("diavola");
                    break;
                case 3:
                    pizza = PizzaFactory.CreaPizza("vegetariana");
                    break;
                default:
                    Console.WriteLine("Scelta non valida.");
                    break;
            }
    }

    public string Descrizione()
    {
        if (pizza == null)
        {
            return "Nessuna pizza selezionata";
        }
        return pizza.Descrizione();
    }

    // observer
    public interface IObserver
    {
        void Aggiorna(string m);
    }

public class SistemaLog : IObserver
{
    public void Aggiorna(string m)
    {
        Console.WriteLine($"[Log] {m}");
    }
}

public class SistemaMarketing : IObserver
{
    public void Aggiorna(string m)
    {
        Console.WriteLine($"[Marketing] {m}");
    }
}
}
