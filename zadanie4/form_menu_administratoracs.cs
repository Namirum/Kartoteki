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
    public partial class form_menu_administratoracs : Form
    {
        public form_menu_administratoracs()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Zarzadzanie_kontami zarzadzaj = new Zarzadzanie_kontami();
            this.Hide();
            zarzadzaj.ShowDialog();
            this.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            form_zarzadzanie_wizytami zarzadzaj = new form_zarzadzanie_wizytami();
            this.Hide();
            zarzadzaj.ShowDialog();
            this.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            form_zarzadzanie_zaleceniami zarzadzaj = new form_zarzadzanie_zaleceniami();
            this.Hide();
            zarzadzaj.ShowDialog();
            this.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            form_statystyka_zachorowan statystyka = new form_statystyka_zachorowan();
            this.Hide();
            statystyka.ShowDialog();
            this.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            form_statystyka_lekarzy statystyka = new form_statystyka_lekarzy();
            this.Hide();
            statystyka.ShowDialog();
            this.Show();
        }
    }
}
