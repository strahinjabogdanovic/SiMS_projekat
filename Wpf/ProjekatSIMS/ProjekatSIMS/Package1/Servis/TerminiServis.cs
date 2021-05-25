using ProjekatSIMS.Package1.Model;
using ProjekatSIMS.Package1.Repozitorijum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatSIMS.Package1.Servis
{
    class TerminiServis
    {
        TerminiFileStorage tfs = new TerminiFileStorage();

        public void OtkazivanjeSekretar(int currentRowIndex)
        {
            tfs.OtkazivanjeSekretar(currentRowIndex);
        }

        public void UpdateSekretar(string pacijent, int currentRowIndex)
        {
            tfs.UpdateSekretar(pacijent, currentRowIndex);
        }

        public void ZakazivanjeSekretar(string update)
        {
            tfs.ZakazivanjeSekretar(update);
        }

        public void PomeranjeTerminaSekretar(TerminiPacijenata termin)
        {
            tfs.PomeranjeTerminaSekretar(termin);
        }
    }
}
