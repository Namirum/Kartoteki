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
    public partial class Usun_konto : Form
    {
        public Usun_konto()
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
            string zapytanie = "select * from pacjent;";
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int wynik;
            Int32.TryParse(textBox1.Text, out wynik); //(textBox1.Text, out wynik);
            int id_pacjenta = wynik;
            MySQL_polaczenie polaczenie = new MySQL_polaczenie();
            if (textBox1.Text != "" && polaczenie.czy_int(textBox1.Text) == 00 && 0 == polaczenie.czy_id_istnieje_pacjent(textBox1.Text))
            {
                polaczenie.usun_konto_pacjenta(wynik);
                wypelnij_tabele();
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Nieprawidlowe id");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
