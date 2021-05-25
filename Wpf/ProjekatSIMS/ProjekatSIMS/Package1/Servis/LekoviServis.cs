using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjekatSIMS.Package1.Repozitorijum;

namespace ProjekatSIMS.Package1.Servis
{
    class LekoviServis
    {
        private LekoviFileStorage lfs = new LekoviFileStorage();
        public void Kreiraj(String s1, String s2, String s3, String s4)
        {
            lfs.Kreiraj(s1, s2, s3, s4);
        }

        public void Obrisi(int currentRowIndex)
        {
            lfs.Obrisi(currentRowIndex);
        }

        public void Izmeni(string update, int currentRowIndex)
        {
            lfs.Izmeni(update, currentRowIndex);
        }
    }
}
