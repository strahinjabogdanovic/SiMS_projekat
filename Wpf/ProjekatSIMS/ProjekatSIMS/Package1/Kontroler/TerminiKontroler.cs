using ProjekatSIMS.Package1.Model;
using ProjekatSIMS.Package1.Servis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatSIMS.Package1.Kontroler
{
    class TerminiKontroler
    {
        TerminiServis ts = new TerminiServis();

        public void OtkazivanjeSekretar(int currentRowIndex)
        {
            ts.OtkazivanjeSekretar(currentRowIndex);
        }

        public void UpdateSekretar(string pacijent, int currentRowIndex)
        {
            ts.UpdateSekretar(pacijent, currentRowIndex);
        }

        public void ZakazivanjeSekretar(string update)
        {
            ts.ZakazivanjeSekretar(update);
        }

        public void PomeranjeTerminaSekretar(TerminiPacijenata termin)
        {
            ts.PomeranjeTerminaSekretar(termin);
        }
    }
}
