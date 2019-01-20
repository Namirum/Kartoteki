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
    public partial class form_zarzadzanie_wizytami : Form
    {
        public form_zarzadzanie_wizytami()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            form_dodaj_wizyte dodaj = new form_dodaj_wizyte();
            dodaj.ShowDialog();
        }
    }
}
