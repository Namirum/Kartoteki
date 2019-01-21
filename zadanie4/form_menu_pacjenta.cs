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
    public partial class form_menu_pacjenta : Form
    {
        int id_pacjenta;

        public form_menu_pacjenta()
        {
            InitializeComponent();
        }

        public void set_id(int id)
        {
            id_pacjenta = id;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            form_historia_wizyt historia = new form_historia_wizyt();
            historia.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            form_historia_zalecen historia = new form_historia_zalecen();
            historia.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            form_dostepnosc_lekarzy dostepnosc = new form_dostepnosc_lekarzy();
            dostepnosc.ShowDialog();
        }

        private void form_menu_pacjenta_Load(object sender, EventArgs e)
        {

        }
    }
}
