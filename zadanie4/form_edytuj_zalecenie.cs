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
    public partial class form_edytuj_zalecenie : Form
    {
        int wybor;
        public form_edytuj_zalecenie()
        {
            InitializeComponent();
            wypelnij_tabele();
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
            label3.Text = "Wprowadz nowa tresc zalecenia";
            textBox2.Visible = true;
            wybor = 2;
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
            string zapytanie = "select * from zalecenie;";
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

        public void wypelnij_tabele(string id_zalecenia)
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
            string zapytanie = "select * from zalecenie where id_zalecenia = " + id_zalecenia + ";";
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
                textBox2.Visible = false;
                button6.Visible = false;
            }
            else
            {
                wypelnij_tabele(textBox1.Text);
                label2.Visible = true;
                button2.Visible = true;
                button3.Visible = true;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                string nowa_dana = textBox2.Text;
                string id_zalecenia = textBox1.Text;
                MySQL_polaczenie polaczenie = new MySQL_polaczenie();
                polaczenie.edytuj_zalecenie(id_zalecenia, nowa_dana, wybor);
            }
        }
    }
}
