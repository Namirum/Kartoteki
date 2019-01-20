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
    public partial class form_edytuj_wizyte : Form
    {
        int wybor;

        public form_edytuj_wizyte()
        {
            InitializeComponent();
            wypelnij_tabele();
        }

        public void wypelnij_tabele()
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
            string zapytanie = "select * from wizyta;";
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

        public void wypelnij_tabele(string id_wizyty)
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
            string zapytanie = "select * from wizyta where id_wizyty = " + id_wizyty + ";";
            MySqlCommand komenda = new MySqlCommand(zapytanie, connection);
            //MySqlDataReader dane = komenda.ExecuteReader();
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


        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                wypelnij_tabele();
                label2.Visible = false;
                label3.Visible = false;
                button2.Visible = false;
                button3.Visible = false;
                button4.Visible = false;
                button5.Visible = false;
                textBox2.Visible = false;
                button6.Visible = false;
            }
            else
            {
                wypelnij_tabele(textBox1.Text);
                label2.Visible = true;
                button2.Visible = true;
                button3.Visible = true;
                button4.Visible = true;
                button5.Visible = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label3.Visible = true;
            button6.Visible = true;
            label3.Text = "Wprowadz nowe id pacjenta";
            textBox2.Visible = true;
            wybor = 1;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label3.Visible = true;
            button6.Visible = true;
            label3.Text = "Wprowadz nowe id lekarza";
            textBox2.Visible = true;
            wybor = 2;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            label3.Visible = true;
            button6.Visible = true;
            label3.Text = "Wprowadz nowa date (rrrr-mm-dd)";
            textBox2.Visible = true;
            wybor = 3;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                string nowa_dana = textBox2.Text;
                string id_wizyty = textBox1.Text;
                MySQL_polaczenie polaczenie = new MySQL_polaczenie();
                polaczenie.edytuj_wizyte(id_wizyty, nowa_dana, wybor);
            }
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            label3.Visible = true;
            button6.Visible = true;
            label3.Text = "Wprowadz nowa godzine (hh:mm)";
            textBox2.Visible = true;
            wybor = 4;
        }
    }
}
