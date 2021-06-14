using ProjekatSIMS.Package1.Repozitorijum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatSIMS.Package1.Servis
{
    class GuestServis
    {
        GuestFileStorage gfs = new GuestFileStorage();

        public void Kreiraj(string guestNalog)
        {
            gfs.Kreiraj(guestNalog);
        }

        public void Obrisi(int currentRowIndex)
        {
            gfs.Obrisi(currentRowIndex);
        }
    }
}
