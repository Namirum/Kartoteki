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
    public partial class form_dodaj_zalecenie : Form
    {
        public form_dodaj_zalecenie()
        {
            InitializeComponent();
            wypelnij_tabele_pacjentami();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                label2.Visible = true;
                textBox2.Visible = true;
                button2.Visible = true;
            }
            else
            {
                label2.Visible = false;
                textBox2.Visible = false;
                button2.Visible = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                button5.Visible = true;
            }
            else
            {
                button5.Visible = false;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MySQL_polaczenie polaczenie = new MySQL_polaczenie();
            polaczenie.dodaj_zalecenie(textBox1.Text, textBox2.Text);
            System.Windows.Forms.MessageBox.Show("Dodano zalecenie");
            this.Hide();
        }
    }
}
