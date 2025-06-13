using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;
using Org.BouncyCastle.Asn1.Misc;

public class Utente
{
    //private string connString = "server=localhost;user=root;password=ciao1234;database=libreria;";
    private string _username;

    public string Username
    {
        get { return _username; }
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                Console.WriteLine("Devi inserire un username.");
            }
            _username = value;
        }
    }

    private string _password;
    public string Password
    {
        get { return _password; }
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                Console.WriteLine("Devi inserire una password.");
            }
            _password = value;
        }
    }
}    