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
            //string rok = "" + data[6] + data[7] + data[8] + data[9];
            //string miesiac = "" + data[3] + data[4];
           // string dzien = "" + data[0] + data[1];
            //string nowa_data = rok + "-" + miesiac + "-" + dzien;

            Func<string> zamien = () => { return (data[6].ToString() + data[7].ToString() + data[8].ToString() + data[9].ToString() + "-" + data[3].ToString() + data[4].ToString() + "-" + data[0].ToString() + data[1].ToString()); };
            
            string nowa_data = zamien();
            //Console.WriteLine(nowa_data);
            database = "kartoteki";
            uid = "root";
            password = "Szkarlat666";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);
            connection.Open();
            string zapytanie = "select hour(data_wizyty) from wizyta where id_lekarza = "+ id_lekarza + " and date(data_wizyty) = '" + nowa_data + "';";
            MySqlCommand komenda = new MySqlCommand(zapytanie, connection);
            MySqlDataReader dane;
            dane = komenda.ExecuteReader();

            int i = 0;
            List<string[]> lista = new List<string[]>();
            while (dane.Read())
            {
                string[] wiersz = { dane.GetInt32(0).ToString() };
                lista.Add(wiersz);
                i++;
            }

            DataTable tabela = new DataTable();
            DataColumn kolumna = new DataColumn();
            kolumna.DataType = System.Type.GetType("System.String");
            kolumna.ColumnName = "dostepna godzina";
            tabela.Columns.Add(kolumna);

            DataRow w;

            int spr_h;
            for(int k=0; k<10; k++)
            {
                spr_h = 0;
                for (int j = 0; j < i; j++)
                {
                    if (lista[j][0] == godzina.ToString())
                    {
                        spr_h = 1;
                    }
                }
                if(spr_h == 0)
                {
                    w = tabela.NewRow();
                    w["dostepna godzina"] = godzina.ToString() + ":00";
                    tabela.Rows.Add(w);
                }
                godzina++;
            }

            DataView widok = new DataView(tabela);
            dataGridView1.DataSource = widok;

            connection.Close();
        }

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
            MySQL_polaczenie polaczenie = new MySQL_polaczenie();
            if(textBox1.Text != "" && polaczenie.czy_int(textBox1.Text) == 0 )
            {
                label5.Text = "";
                if (polaczenie.czy_id_istnieje_pacjent(textBox1.Text) == 0)
                {
                    wypelnij_tabele_lekarzami();
                    label2.Visible = true;
                    textBox2.Visible = true;
                    button2.Visible = true;
                    
                }
                else
                {
                    label5.Text = "Nieprawidlowe id";
                    wypelnij_tabele_pacjentami();
                    label2.Visible = false;
                    textBox2.Visible = false;
                    button2.Visible = false;
                    
                }
            }
            else
            {
                wypelnij_tabele_pacjentami();
                label2.Visible = false;
                textBox2.Visible = false;
                button2.Visible = false;
                label5.Text = "Nieprawidlowe id";
            }
            
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            MySQL_polaczenie polaczenie = new MySQL_polaczenie();
            if (textBox2.Text != "" && polaczenie.czy_int(textBox2.Text) == 0)
            {
                    label5.Text = "";
                if (polaczenie.czy_id_istnieje_lekarz(textBox2.Text) == 0)
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
            else
            {
                label3.Visible = false;
                textBox3.Visible = false;
                button3.Visible = false;
                label5.Text = "Nieprawidlowe id";
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
            MySQL_polaczenie polaczenie = new MySQL_polaczenie();
            if (textBox3.Text != "" && (polaczenie.czy_data(textBox3.Text) == 0))
            {
                label4.Visible = true;
                textBox4.Visible = true;
                button4.Visible = true;
                label5.Text = "";
                wypelnij_tabele_datami(textBox3.Text, textBox2.Text);
            }
            else
            {
                label4.Visible = false;
                textBox4.Visible = false;
                button4.Visible = false;
                label5.Text = "Nieprawidlowa data";
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string data = textBox3.Text;
            string rok = "" + data[6] + data[7] + data[8] + data[9];
            string miesiac = "" + data[3] + data[4];
            string dzien = "" + data[0] + data[1];
            string nowa_data = rok + "-" + miesiac + "-" + dzien;
            nowa_data = nowa_data + " " + textBox4.Text + ":00";
            MySQL_polaczenie polaczenie = new MySQL_polaczenie();
            polaczenie.dodaj_wizyte(textBox1.Text, textBox2.Text, nowa_data);
            System.Windows.Forms.MessageBox.Show("Dodano wizyte");
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox4.Text != "")
            {
                MySQL_polaczenie sprawdz = new MySQL_polaczenie();
                if(0 == sprawdz.czy_godzina(textBox4.Text))
                {
                    int spr = sprawdz.sprawdz_dostepnosc_godziny(textBox2.Text, textBox3.Text, textBox4.Text);
                    if (spr == 0)
                    {
                        button5.Visible = true;
                        label5.Text = "";
                    }
                    else
                    {
                        label5.Text = "Ta godzina nie jest dostepna";
                    }
                }
                else
                {
                    label5.Text = "Nieprawdilowa godzina";
                }
                
                
            }
            else
            {
                button5.Visible = false;
            }
        }
    }
}
