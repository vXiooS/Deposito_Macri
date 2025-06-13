using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;
using Org.BouncyCastle.Asn1.Misc;

public sealed class Admin
{
    private string _username = "admin";

    public string Username
    {
        get { return _username; }
    }

    private string _password = "admin";

    public string Password
    {
        get { return _password; }
    }

    public void AggiungiPaese(MySqlConnection conn)
    {
        Console.Write($"Inserisci paese: ");
        string paese = Console.ReadLine();

        string sql = "Insert into paese_destinazione (nome) values (@paese)";
        MySqlCommand cmd = new MySqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@paese", paese);
        cmd.ExecuteNonQuery();
        Console.WriteLine($"Paese aggiunto con successo.");
    }

    public void AggiungiCitta(MySqlConnection conn)
    {
        Console.Write($"Inserisci citta: ");
        string citta = Console.ReadLine();
        Console.Write($"Inserisci paese: ");
        string paese = Console.ReadLine();
        int paeseID = 0;
        do
        {
            string sqlIDPaese = "select paese_destinazione.paese_id from paese_destinazione where paese_destinazione.nome = @nome";
            MySqlCommand cmdIDPaese = new MySqlCommand(sqlIDPaese, conn);
            cmdIDPaese.Parameters.AddWithValue("@nome", paese);
            MySqlDataReader rdr = cmdIDPaese.ExecuteReader();
            if (rdr.Read())
            {
                paeseID = (int)rdr[0];
                rdr.Close();
                break;
            }
        } while (true);

        string sql = "Insert into citta_destinazione (nome, paese_id) values (@citta, @paese_id)";
        MySqlCommand cmd = new MySqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@citta", citta);
        cmd.Parameters.AddWithValue("@paese_id", paeseID);
        cmd.ExecuteNonQuery();
        Console.WriteLine($"Citta aggiunta con successo.");
    }

    public void AggiungiLocation(MySqlConnection conn)
    {
        Console.Write($"Inserisci nome: ");
        string nome = Console.ReadLine();
        Console.Write($"Inserisci descrizione: ");
        string desc = Console.ReadLine();
        Console.Write($"Inserisci citta: ");
        string citta = Console.ReadLine();
        int cittaID = 0;
        do
        {
            string sqlIDCitta = "select citta_destinazione.citta_id from citta_destinazione where citta_destinazione.nome = @nome";
            MySqlCommand cmdIDPaese = new MySqlCommand(sqlIDCitta, conn);
            cmdIDPaese.Parameters.AddWithValue("@nome", citta);
            MySqlDataReader rdr = cmdIDPaese.ExecuteReader();
            if (rdr.Read())
            {
                cittaID = (int)rdr[0];
                rdr.Close();
                break;
            }
        } while (true);

        string sql = "Insert into location (nome, descrizione, citta_id) values (@location, @desc, @citta_id)";
        MySqlCommand cmd = new MySqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@location", nome);
        cmd.Parameters.AddWithValue("@desc", desc);
        cmd.Parameters.AddWithValue("@citta_id", cittaID);
        cmd.ExecuteNonQuery();
        Console.WriteLine($"Location aggiunta con successo.");
    }

    public void StampaLocations(MySqlConnection conn)
    {
        string sql = "select l.nome as location, l.descrizione, c.nome as citta, p.nome as paese from location l join citta_destinazione c on c.citta_id = l.citta_id join paese_destinazione p on p.paese_id = c.paese_id;";
        MySqlCommand cmd = new MySqlCommand(sql, conn);
        MySqlDataReader rdr = cmd.ExecuteReader();

        while (rdr.Read())
        {
            Console.WriteLine(rdr[0]+" -- "+rdr[1] +" -- "+ rdr[2]+" -- "+rdr[3]);
        }
        rdr.Close();
    }
}    