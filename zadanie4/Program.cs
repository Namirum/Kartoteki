﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace zadanie4
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Menu menu = new zadanie4.Menu();
            MySQL_polaczenie polaczenie = new MySQL_polaczenie();
            menu.menu_glowne();
        }
    }
}