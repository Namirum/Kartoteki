﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace zadanie4
{
    public partial class Dodaj_konto : Form
    {
        public Dodaj_konto()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySQL_polaczenie polaczenie = new MySQL_polaczenie();
            if(polaczenie.czy_imie_nazwisko(textBox3.Text) == 0 && polaczenie.czy_imie_nazwisko(textBox4.Text) == 0)
            {
                polaczenie.dodaj_konto_pacjenta(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text);
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Nieprawidlowe dane");
            }
        }
    }
}
