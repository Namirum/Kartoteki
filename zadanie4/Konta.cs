using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadanie4
{
    class Konta
    {
        public void dodaj_konto()
        {
            Dodaj_konto dodaj = new Dodaj_konto();
            dodaj.ShowDialog();
        }

        public void usun_konto()
        {
            Usun_konto usun = new Usun_konto();
            usun.ShowDialog();
        }

        public void edytuj_konto()
        {
            Edytuj_konto edytuj = new Edytuj_konto();
            edytuj.ShowDialog();
        }

        public void wyswietl_konta()
        {

        }

        public void wyswietl_konta(int id_konta)
        {

        }
    }
}
