using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjekatSIMS.Package1.Servis;

namespace ProjekatSIMS.Package1.Kontroler
{
    class LekoviKontroler
    {
        private LekoviServis ls = new LekoviServis();
        public void Kreiraj(String s1, String s2, String s3, String s4)
        {
            ls.Kreiraj(s1, s2, s3, s4);
        }

        public void Obrisi(int currentRowIndex)
        {
            ls.Obrisi(currentRowIndex);
        }

        public void Izmeni(string update, int currentRowIndex)
        {
            ls.Izmeni(update, currentRowIndex);
        }
    }
}
