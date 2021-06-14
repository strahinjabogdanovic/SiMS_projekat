using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjekatSIMS.Package1.Servis;

namespace ProjekatSIMS.Package1.Kontroler
{
    class OpremaKontroler
    {
        private OpremaServis os = new OpremaServis();
        public void Kreiraj(string tb, string tb1, int redStvari)
        {
            os.Kreiraj(tb, tb1, redStvari);
        }

        public void Obrisi(int currentRowIndex, int currentRowIndexo)
        {
            os.Obrisi(currentRowIndex, currentRowIndexo);
        }

        public void Update(int redProstorije, int currentRowIndex, string t1, string t2)
        {
            os.Update(redProstorije, currentRowIndex, t1, t2);
        }
    }
}
