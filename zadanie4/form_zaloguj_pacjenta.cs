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
    public partial class form_zaloguj_pacjenta : Form
    {
        public form_zaloguj_pacjenta()
        {
            InitializeComponent();
        }

        private void form_menu_pacjenta_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int spr;
            if(textBox1.Text != "" && textBox2.Text != "")
            {
                string login = textBox1.Text;
                string haslo = textBox2.Text;
                MySQL_polaczenie polaczenie = new MySQL_polaczenie();
                spr = polaczenie.zaloguj_pacjenta(login, haslo);
                //Console.WriteLine(spr);
                if (spr == 0)
                {
                    this.label3.Text = "Nieprawidlowy login lub haslo";
                }
                else
                {
                    this.label3.Text = "";
                    form_menu_pacjenta menu_pacjenta = new form_menu_pacjenta();
                    menu_pacjenta.set_id(spr);
                    this.Hide();
                    menu_pacjenta.ShowDialog();
                    this.Show();
                }
            }
            else
            {
                this.label3.Text = "Nieprawidlowy login lub haslo";
            }
            
        }
    }
}
