﻿using System;
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
    public partial class form_statystyka_zachorowan : Form
    {
        public form_statystyka_zachorowan()
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
            string zapytanie = "select choroba.id_choroby, choroba.nazwa, count(zachorowanie.id_pacjenta) from choroba join zachorowanie on choroba.id_choroby = zachorowanie.id_choroby group by choroba.id_choroby order by count(zachorowanie.id_pacjenta) desc;";
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
        //select choroba.id_choroby, choroba.nazwa, count(zachorowanie.id_pacjenta) from choroba join zachorowanie on choroba.id_choroby = zachorowanie.id_choroby group by choroba.id_choroby order by count(zachorowanie.id_pacjenta);

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
