using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace zadanie4
{
    public partial class form_dodaj_wizyte : Form
    {
        public form_dodaj_wizyte()
        {
            InitializeComponent();
            wypelnij_tabele_pacjentami();
        }

        public void wypelnij_tabele_pacjentami()
        {
            MySqlConnection connection;
            string server;
            string database;
            string uid;
            string password;
            server = "localhost";

            database = "kartoteki";
            uid = "root";
            password = "Szkarlat666";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);
            connection.Open();
            string zapytanie = "select * from pacjent;";
            MySqlCommand komenda = new MySqlCommand(zapytanie, connection);
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            BindingSource zrodlo = new BindingSource();
            adapter.SelectCommand = komenda;
            DataTable tabela = new DataTable();
            adapter.Fill(tabela);
            zrodlo.DataSource = tabela;
            dataGridView1.DataSource = zrodlo;
            adapter.Update(tabela);

            connection.Close();
        }

        public void wypelnij_tabele_lekarzami()
        {
            MySqlConnection connection;
            string server;
            string database;
            string uid;
            string password;
            server = "localhost";

            database = "kartoteki";
            uid = "root";
            password = "Szkarlat666";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);
            connection.Open();
            string zapytanie = "select * from lekarz;";
            MySqlCommand komenda = new MySqlCommand(zapytanie, connection);
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            BindingSource zrodlo = new BindingSource();
            adapter.SelectCommand = komenda;
            DataTable tabela = new DataTable();
            adapter.Fill(tabela);
            zrodlo.DataSource = tabela;
            dataGridView1.DataSource = zrodlo;
            adapter.Update(tabela);

            connection.Close();
        }

        public void wypelnij_tabele_datami(string data, string id_lekarza)
        {
            MySqlConnection connection;
            string server;
            string database;
            string uid;
            string password;
            int godzina = 8;
            server = "localhost";
            string rok = "" + data[6] + data[7] + data[8] + data[9];
            string miesiac = "" + data[3] + data[4];
            string dzien = "" + data[0] + data[1];
            string nowa_data = rok + "-" + miesiac + "-" + dzien;
            database = "kartoteki";
            uid = "root";
            password = "Szkarlat666";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);
            connection.Open();
            string zapytanie = "select hour(data_wizyty) from wizyta where id_lekarza = "+ id_lekarza + " and date(data_wizyty) = '" + data + "';";
            MySqlCommand komenda = new MySqlCommand(zapytanie, connection);
            MySqlDataReader dane;
            dane = komenda.ExecuteReader();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            BindingSource zrodlo = new BindingSource();
            //adapter.SelectCommand = komenda;
            DataTable tabela = new DataTable();
            List<string[]> lista = new List<string[]>();
            while (dane.Read())
            {
                if(dane.GetString(0) == (godzina.ToString() + ":00:00"))
                {

                }
                else
                {
                    string[] wiersz = { dane.GetString(0) };
                    lista.Add(wiersz);
                    tabela.Rows.Add(wiersz);
                }
                godzina++;
                //lista.Add(wiersz);
                //i++;
            }
            adapter.Fill(tabela);
            zrodlo.DataSource = tabela;
            dataGridView1.DataSource = zrodlo;
            adapter.Update(tabela);
            //adapter.Fill(tabela);
            //zrodlo.DataSource = tabela;
            //dataGridView1.DataSource = zrodlo;
            //adapter.Update(tabela);

            connection.Close();
        }

        //funkcja = (string data) => { return 1; };

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text != "")
            {
                wypelnij_tabele_lekarzami();
                label2.Visible = true;
                textBox2.Visible = true;
                button2.Visible = true;
            }
            else
            {
                wypelnij_tabele_pacjentami();
                label2.Visible = false;
                textBox2.Visible = false;
                button2.Visible = false;
            }
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                //wypelnij_tabele_lekarzami();
                label3.Visible = true;
                textBox3.Visible = true;
                button3.Visible = true;
            }
            else
            {
               // wypelnij_tabele_pacjentami();
                label3.Visible = false;
                textBox3.Visible = false;
                button3.Visible = false;
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox3.Text != "")
            {
                //wypelnij_tabele_lekarzami();
                label4.Visible = true;
                textBox4.Visible = true;
                button4.Visible = true;
                wypelnij_tabele_datami(textBox3.Text, textBox2.Text);
            }
            else
            {
                // wypelnij_tabele_pacjentami();
                label4.Visible = false;
                textBox4.Visible = false;
                button4.Visible = false;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox4.Text != "")
            {
                MySQL_polaczenie sprawdz = new MySQL_polaczenie();
                int spr = sprawdz.sprawdz_dostepnosc_godziny(textBox2.Text, textBox3.Text, textBox4.Text);
                if ( spr == 0)
                {
                    button5.Visible = true;
                }
                else
                {
                    label5.Text = "Ta godzina nie jest dostepna";
                }
                
            }
            else
            {
                button5.Visible = false;
            }
        }
    }
}
