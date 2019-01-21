using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace zadanie4
{
    class MySQL_polaczenie
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;

        public MySQL_polaczenie()
        {
            Initialize();
        }

        public void Initialize()
        {

            server = "localhost";
            database = "kartoteki";
            uid = "root";
            password = "Szkarlat666";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);

        }

        public int zaloguj_administratora(string login, string haslo)
        {
            string zapytanie = "select id_admin, login, haslo from administrator;"; ;
            MySqlCommand komenda = new MySqlCommand(zapytanie, connection);
            MySqlDataReader dane;
            //MySqlDataAdapter adapter = new MySqlDataAdapter();
            int spr = 0;

            List<string[]> lista = new List<string[]>();

            connection.Open();

            dane = komenda.ExecuteReader();
            int i = 0;
            while (dane.Read())
            {
                string[] wiersz = { dane.GetInt32(0).ToString(), dane.GetString(1), dane.GetString(2) };
                lista.Add(wiersz);
                if (lista[i][1] == login && lista[i][2] == haslo)
                {
                    spr = 1;
                    break;
                }
                //lista.ad =;
                //lista[i][1] = dane.GetString(1);
                //lista[i][2] = dane.GetString(2);
                //Console.WriteLine("{0} {1} {2}", lista[i][0], lista[i][1], lista[i][2]);
                i++;
            }
            connection.Close();
            if (spr == 1)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }

        public void usun_konto_pacjenta(int id_pacjenta)
        {
            string zapytanie = "delete from pacjent where id_pacjenta=" + id_pacjenta.ToString() + ";";
            MySqlCommand komenda = new MySqlCommand(zapytanie, connection);
            MySqlDataReader dane;
            connection.Open();
            dane = komenda.ExecuteReader();
            connection.Close();
        }

        public void dodaj_konto_pacjenta(string login, string haslo, string imie, string nazwisko)
        {
            string zapytanie = "insert into pacjent (id_pacjenta, login, haslo, imie, nazwisko) values ( 0, '" + login + "', '" + haslo + "', '" + imie + "', '" + nazwisko + "');";
            MySqlCommand komenda = new MySqlCommand(zapytanie, connection);
            MySqlDataReader dane;
            connection.Open();
            dane = komenda.ExecuteReader();
            connection.Close();
        }

        public void edytuj_konto_pacjenta(string nowa_dana, string id_pacjenta, int wybor)
        {
            string zapytanie;
            if (wybor == 1)
            {
                zapytanie = "update pacjent set login = '" + nowa_dana + "' where id_pacjenta = " + id_pacjenta + ";";
                MySqlCommand komenda = new MySqlCommand(zapytanie, connection);
                MySqlDataReader dane;
                connection.Open();
                dane = komenda.ExecuteReader();
                connection.Close();
            }
            if (wybor == 2)
            {
                zapytanie = "update pacjent set haslo = '" + nowa_dana + "' where id_pacjenta = " + id_pacjenta + ";";
                MySqlCommand komenda = new MySqlCommand(zapytanie, connection);
                MySqlDataReader dane;
                connection.Open();
                dane = komenda.ExecuteReader();
                connection.Close();
            }
            if (wybor == 3)
            {
                zapytanie = "update pacjent set imie = '" + nowa_dana + "' where id_pacjenta = " + id_pacjenta + ";";
                MySqlCommand komenda = new MySqlCommand(zapytanie, connection);
                MySqlDataReader dane;
                connection.Open();
                dane = komenda.ExecuteReader();
                connection.Close();
            }
            if (wybor == 4)
            {
                zapytanie = "update pacjent set nazwisko = '" + nowa_dana + "' where id_pacjenta = " + id_pacjenta + ";";
                MySqlCommand komenda = new MySqlCommand(zapytanie, connection);
                MySqlDataReader dane;
                connection.Open();
                dane = komenda.ExecuteReader();
                connection.Close();
            }
        }

        public int sprawdz_dostepnosc_godziny(string id_lekarza, string data, string godzina)
        {
            string zapytanie = "select id_lekarza, data_wizyty from wizyta;"; ;
            MySqlCommand komenda = new MySqlCommand(zapytanie, connection);
            MySqlDataReader dane;
            //MySqlDataAdapter adapter = new MySqlDataAdapter();
            int spr = 0;

            List<string[]> lista = new List<string[]>();

            connection.Open();

            dane = komenda.ExecuteReader();
            int i = 0;
            while (dane.Read())
            {
                string[] wiersz = { dane.GetString(0), dane.GetString(1) };
                lista.Add(wiersz);
                if (lista[i][1] == (data + " " + godzina + ":00"))
                {
                    spr = 1;
                    break;
                }

                //Console.WriteLine("{0} {1}", lista[i][0], lista[i][1]);
                //Console.WriteLine(data + " " + godzina + ":00");
                i++;
            }
            connection.Close();
            if (spr == 1)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public int czy_login_dostepny()
        {
            return 0;
        }


        public void dodaj_wizyte(string id_pacjenta, string id_lekarza, string data_wizyty)
        {
            string zapytanie = "insert into wizyta (id_pacjenta, id_lekarza, data_rejestracji, data_wizyty) values (" + id_pacjenta + ", " + id_lekarza + ", sysdate(), '" + data_wizyty + "');";
            MySqlCommand komenda = new MySqlCommand(zapytanie, connection);
            MySqlDataReader dane;
            connection.Open();
            dane = komenda.ExecuteReader();
            connection.Close();
        }

        public void usun_wizyte(string id_wizyty)
        {
            string zapytanie = "delete from wizyta where id_wizyty = " + id_wizyty + ";";
            MySqlCommand komenda = new MySqlCommand(zapytanie, connection);
            MySqlDataReader dane;
            connection.Open();
            dane = komenda.ExecuteReader();
            connection.Close();
        }

        public void edytuj_wizyte(string id_wizyty, string nowa_dana, int wybor)
        {
            string zapytanie;
            if (wybor == 1)
            {
                zapytanie = "update wizyta set id_pacjenta = '" + nowa_dana + "' where id_wizyty = " + id_wizyty + ";";
                MySqlCommand komenda = new MySqlCommand(zapytanie, connection);
                MySqlDataReader dane;
                connection.Open();
                dane = komenda.ExecuteReader();
                connection.Close();
            }
            if (wybor == 2)
            {
                zapytanie = "update wizyta set id_lekarza = '" + nowa_dana + "' where id_wizyty = " + id_wizyty + ";";
                MySqlCommand komenda = new MySqlCommand(zapytanie, connection);
                MySqlDataReader dane;
                connection.Open();
                dane = komenda.ExecuteReader();
                connection.Close();
            }
            if (wybor == 3)
            {
                zapytanie = "select hour(data_wizyty) from wizyta where id_wizyty = " + id_wizyty + ";";
                string godzina;
                MySqlCommand komenda = new MySqlCommand(zapytanie, connection);
                MySqlDataReader dane;
                connection.Open();
                dane = komenda.ExecuteReader();
                dane.Read();
                godzina = dane.GetString(0);
                connection.Close();

                nowa_dana = nowa_dana + " " + godzina + ":00:00";
                zapytanie = "update wizyta set data_wizyty = '" + nowa_dana + "' where id_wizyty = " + id_wizyty + ";";
                komenda = new MySqlCommand(zapytanie, connection);
                connection.Open();
                dane = komenda.ExecuteReader();
                connection.Close();
            }
            if (wybor == 4)
            {
                zapytanie = "select date_format(data_wizyty, '%Y-%m-%d') from wizyta where id_wizyty = " + id_wizyty + ";";
                string data;
                MySqlCommand komenda = new MySqlCommand(zapytanie, connection);
                MySqlDataReader dane;
                connection.Open();
                dane = komenda.ExecuteReader();
                dane.Read();
                data = dane.GetString(0);
                connection.Close();

                nowa_dana = data + " " + nowa_dana;
                zapytanie = "update wizyta set data_wizyty = '" + nowa_dana + "' where id_wizyty = " + id_wizyty + ";";
                komenda = new MySqlCommand(zapytanie, connection);
                connection.Open();
                dane = komenda.ExecuteReader();
                connection.Close();
            }
        }

        public void dodaj_zalecenie(string id_pacjenta, string zalecenie)
        {
            string zapytanie = "insert into zalecenie (id_zalecenia, id_pacjenta, tresc_zalecenia) values ( 0, '" + id_pacjenta + "', '" + zalecenie + "');";
            MySqlCommand komenda = new MySqlCommand(zapytanie, connection);
            MySqlDataReader dane;
            connection.Open();
            dane = komenda.ExecuteReader();
            connection.Close();
        }

        public void usun_zalecenie(string id_zalecenia)
        {
            string zapytanie = "delete from zalecenie where id_zalecenia = " + id_zalecenia+ ";";
            MySqlCommand komenda = new MySqlCommand(zapytanie, connection);
            MySqlDataReader dane;
            connection.Open();
            dane = komenda.ExecuteReader();
            connection.Close();
        }

        public void edytuj_zalecenie(string id_zalecenia, string nowa_dana, int wybor)
        {
            string zapytanie;
            if (wybor == 1)
            {
                zapytanie = "update zalecenie set id_pacjenta = '" + nowa_dana + "' where id_zalecenia = " + id_zalecenia + ";";
                MySqlCommand komenda = new MySqlCommand(zapytanie, connection);
                MySqlDataReader dane;
                connection.Open();
                dane = komenda.ExecuteReader();
                connection.Close();
            }
            if (wybor == 2)
            {
                zapytanie = "update zalecenie set tresc_zalecenia = '" + nowa_dana + "' where id_zalecenia = " + id_zalecenia + ";";
                MySqlCommand komenda = new MySqlCommand(zapytanie, connection);
                MySqlDataReader dane;
                connection.Open();
                dane = komenda.ExecuteReader();
                connection.Close();
            }
        }
    }
}