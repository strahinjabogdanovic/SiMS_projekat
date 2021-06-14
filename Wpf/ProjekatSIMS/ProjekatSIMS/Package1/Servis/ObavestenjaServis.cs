using ProjekatSIMS.Package1.Repozitorijum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatSIMS.Package1.Servis
{
    class ObavestenjaServis
    {
        ObavestenjaFileStorage ofs = new ObavestenjaFileStorage();

        public void Kreiraj(string obavestenje)
        {
            ofs.Kreiraj(obavestenje);
        }

        public void Obrisi(int currentRowIndex)
        {
            ofs.Obrisi(currentRowIndex);
        }

        public void Update(string update, int currentRowIndex)
        {
            ofs.Update(update, currentRowIndex);
        }
    }
}
