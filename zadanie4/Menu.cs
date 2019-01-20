using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace zadanie4
{
    
    class Menu
    {
        [STAThread]
        public void menu_glowne()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new form_menu_glowne());
        }

        public void menu_administratora()
        {
            form_zaloguj_administratora menu_administratora = new form_zaloguj_administratora();
            menu_administratora.ShowDialog();
        }

        public void zaloguj_pacjenta()
        {
            form_zaloguj_pacjenta menu_pacjenta = new form_zaloguj_pacjenta();
            menu_pacjenta.ShowDialog();
        }
    }
}
