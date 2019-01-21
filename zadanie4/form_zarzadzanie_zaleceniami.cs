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
    public partial class form_zarzadzanie_zaleceniami : Form
    {
        public form_zarzadzanie_zaleceniami()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            form_dodaj_zalecenie dodaj = new form_dodaj_zalecenie();
            dodaj.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            form_usun_zalecenie usun = new form_usun_zalecenie();
            usun.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            form_edytuj_zalecenie edytuj = new form_edytuj_zalecenie();
            edytuj.ShowDialog();
        }
    }
}
