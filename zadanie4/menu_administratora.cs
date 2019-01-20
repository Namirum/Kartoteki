using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadanie4
{
    class menu_administratora
    {
        public void menu_glowne_administratora()
        {
            form_menu_administratoracs form_menu_admin = new form_menu_administratoracs();
            form_menu_admin.ShowDialog();
        }
    }
}
