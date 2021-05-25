using ProjekatSIMS.Package1.Servis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatSIMS.Package1.Kontroler
{
    class ObavestenjaKontroler
    {
        ObavestenjaServis os = new ObavestenjaServis();

        public void Kreiraj(string obavestenje)
        {
            os.Kreiraj(obavestenje);
        }

        public void Obrisi(int currentRowIndex)
        {
            os.Obrisi(currentRowIndex);
        }

        public void Update(string update, int currentRowIndex)
        {
            os.Update(update, currentRowIndex);
        }
    }
}
