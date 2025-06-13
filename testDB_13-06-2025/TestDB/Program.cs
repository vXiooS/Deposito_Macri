using System;
using MySql.Data.MySqlClient;

class Program
{
    public static void Main(string[] args)
    {
        string connStr = "server=localhost;user=root;database=agenzia_viaggi;port=3306;password=";

        Console.Write($"Inserisci la password del database: ");
        string p = Console.ReadLine();
        connStr += p;

        MySqlConnection conn = new MySqlConnection(connStr);
        try
        {
            Console.WriteLine("Connecting to MySQL...");
            conn.Open();
            Admin a = new Admin();
            //a.AggiungiPaese(conn);
            //a.AggiungiCitta(conn);
            //a.AggiungiLocation(conn);
            bool x = true;

            // ciclo principale del menù
            do
            {
                Console.WriteLine("\n-- Menù --");
                Console.WriteLine("0. Esci");
                Console.WriteLine("1. Registrazione");
                Console.WriteLine("2. Login");
                Console.Write("Scelta: ");
                int sceltamenu = int.Parse(Console.ReadLine());

                switch (sceltamenu)
                {
                    case 0:
                        x = false;
                        break;

                    case 1:
                        Console.Write($"Inserisci nome utente: ");
                        string username = Console.ReadLine();
                        Console.Write($"Inserisci password: ");
                        string password = Console.ReadLine();
                        if (username != "admin" && password != "admin")
                        {
                            UserRegistration(conn, username, password);
                        }
                        break;

                    case 2:
                        Console.Write($"Inserisci nome utente: ");
                        username = Console.ReadLine();
                        Console.Write($"Inserisci password: ");
                        password = Console.ReadLine();

                        Admin admin = new Admin();
                        bool isAdmin = AdminLogin(admin, username, password);
                        Utente u = new Utente();
                        bool isUser = UserLogin(conn, username, password);

                        if (isAdmin)
                        {
                            AdminMenu(admin, conn);
                        }
                        else
                        {
                            //vuoto
                            UserMenu(u, conn);
                        }
                        break;

                    default:
                        Console.WriteLine("Scelta non valida.");
                        break;
                }
            }
            while (x);

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
        conn.Close();
        Console.WriteLine("Done.");
    }

    public static bool UserLogin(MySqlConnection conn, string username, string password)
    {
        string sqluser = "Select u.username, u.password_hash from userlogin u where u.username=@username and u.password_hash=@password_u;";
        MySqlCommand cmdUser = new MySqlCommand(sqluser, conn);
        cmdUser.Parameters.AddWithValue("@username", username);
        cmdUser.Parameters.AddWithValue("@password_u", password);
        MySqlDataReader rdrUser = cmdUser.ExecuteReader();

        if (rdrUser.Read())
        {
            rdrUser.Close();
            return true;
        }
        else
        {
            rdrUser.Close();
            return false;
        }
    }

    public static bool AdminLogin(Admin admin, string username, string password)
    {
        if (username == admin.Username && password == admin.Password)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static void UserRegistration(MySqlConnection conn, string username, string password)
    {
        Console.Write($"Inserisci Nome: ");
        string nome = Console.ReadLine();
        Console.Write($"Inserisci Cognome: ");
        string cognome = Console.ReadLine();
        Console.Write($"Inserisci email: ");
        string email = Console.ReadLine();

        string sqlUserId = "Select utente_id from utente where email=@email;";
        MySqlCommand cmdUserId = new MySqlCommand(sqlUserId, conn);
        cmdUserId.Parameters.AddWithValue("@email", email);
        MySqlDataReader rdrUser = cmdUserId.ExecuteReader();
        int userID = 0;
        if (rdrUser.Read())
        {
            rdrUser.Close();
            Console.WriteLine($"Utente già esistente.");
            return;
        }
        rdrUser.Close();


        string sqlUser = "insert into utente (nome, cognome, email) values (@nome,@cognome,@email)";
        MySqlCommand cmdUser = new MySqlCommand(sqlUser, conn);
        cmdUser.Parameters.AddWithValue("@nome", nome);
        cmdUser.Parameters.AddWithValue("@cognome", cognome);
        cmdUser.Parameters.AddWithValue("@email", email);
        cmdUser.ExecuteNonQuery();


        string sqlUserID2 = "Select utente_id from utente where email=@email;";
        MySqlCommand cmdUserID2 = new MySqlCommand(sqlUserID2, conn);
        cmdUserID2.Parameters.AddWithValue("@email", email);
        MySqlDataReader rdrUserID2 = cmdUserID2.ExecuteReader();
        if (rdrUserID2.Read())
        {
            userID = (int)rdrUserID2[0];
            rdrUserID2.Close();
        }
        rdrUserID2.Close();

        sqlUser = "Insert into userlogin(utente_id,username,password_hash) values (@utente_id,@username,@password)";
        cmdUser = new MySqlCommand(sqlUser, conn);
        cmdUser.Parameters.AddWithValue("@utente_id", userID);
        cmdUser.Parameters.AddWithValue("@username", username);
        cmdUser.Parameters.AddWithValue("@password", password);
        cmdUser.ExecuteNonQuery();

        Console.WriteLine($"Utente aggiunto con successo.");
    }

    public static void AdminMenu(Admin a, MySqlConnection conn)
    {
        bool x = true;
        // ciclo principale del menù
        do
        {
            Console.WriteLine("\n-- Menù --");
            Console.WriteLine("0. Esci");
            Console.WriteLine("1. Aggiungi paese");
            Console.WriteLine("2. Aggiungi citta");
            Console.WriteLine("3. Aggiungi location");
            Console.WriteLine("4. Stampa tutte le location");
            Console.Write("Scelta: ");
            int sceltamenu = int.Parse(Console.ReadLine());

            switch (sceltamenu)
            {
                case 0:
                    x = false;
                    break;

                case 1:
                    a.AggiungiPaese(conn);
                    break;

                case 2:
                    a.AggiungiCitta(conn);
                    break;

                case 3:
                    a.AggiungiLocation(conn);
                    break;

                case 4:
                    a.StampaLocations(conn);
                    break;

                default:
                    Console.WriteLine("Scelta non valida.");
                    break;
            }
        }
        while (x);
    }

    // vuoto
    public static void UserMenu(Utente u, MySqlConnection conn)
    {
        bool x = true;
        // ciclo principale del menù
        do
        {
            Console.WriteLine("\n-- Menù --");
            Console.WriteLine("0. Esci");
            Console.WriteLine("1. ");
            Console.WriteLine("2. ");
            Console.WriteLine("3. ");
            Console.Write("Scelta: ");
            int sceltamenu = int.Parse(Console.ReadLine());

            switch (sceltamenu)
            {
                case 0:
                    x = false;
                    break;

                case 1:

                    break;

                case 2:

                    break;

                case 3:

                    break;

                default:
                    Console.WriteLine("Scelta non valida.");
                    break;
            }
        }
        while (x);
    }
}
