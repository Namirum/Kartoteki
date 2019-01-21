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
    public partial class form_usun_wizyte : Form
    {
        public form_usun_wizyte()
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySQL_polaczenie sprawdz = new MySQL_polaczenie();
            if (textBox1.Text != "" && 0 == sprawdz.czy_id_istnieje_wizyta(textBox1.Text))
            {
                label2.Text = "";
                MySQL_polaczenie usun = new MySQL_polaczenie();
                usun.usun_wizyte(textBox1.Text);
                System.Windows.Forms.MessageBox.Show("Usunieto wizyte");
                wypelnij_tabele();
            } 
            else
            {
                label2.Text = "Nieprawidlowe id";
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
