using ProjekatSIMS.Package1.Servis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatSIMS.Package1.Kontroler
{
    class GuestKontroler
    {
        GuestServis gs = new GuestServis();

        public void Kreiraj(string guestNalog)
        {
            gs.Kreiraj(guestNalog);
        }

        public void Obrisi(int currentRowIndex)
        {
            gs.Obrisi(currentRowIndex);
        }
    }
}
