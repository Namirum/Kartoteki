using System;
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
    public partial class Zarzadzanie_kontami : Form
    {
        public Zarzadzanie_kontami()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Konta konto = new zadanie4.Konta();
            konto.dodaj_konto();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Konta konto = new zadanie4.Konta();
            konto.usun_konto();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Konta konto = new zadanie4.Konta();
            konto.edytuj_konto();
        }
    }
}
