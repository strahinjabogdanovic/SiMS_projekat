using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjekatSIMS.Package1.Repozitorijum;

namespace ProjekatSIMS.Package1.Servis
{
    class OpremaServis
    {
        private OpremaFileStorage ofs = new OpremaFileStorage();
        public void Kreiraj(string tb, string tb1, int redStvari)
        {
            ofs.Kreiraj(tb, tb1, redStvari);
        }

        public void Obrisi(int currentRowIndex, int currentRowIndexo)
        {
            ofs.Obrisi(currentRowIndex, currentRowIndexo);
        }

        public void Update(int redProstorije, int currentRowIndex, string t1, string t2)
        {
            ofs.Update(redProstorije, currentRowIndex, t1, t2);
        }
    }
}
