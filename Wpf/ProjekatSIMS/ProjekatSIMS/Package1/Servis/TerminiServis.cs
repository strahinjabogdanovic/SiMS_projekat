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
        PacijentFileStorage p = new PacijentFileStorage();

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

        public void AntiTrolSekretar(TerminiPacijenata termin)
        {
            tfs.AntiTrolSekretar(termin);
        }

        public string SlobodanDoktor(string date) {

            List<TerminiPacijenata> termini = p.GetAll();
            string retVal = "";
            foreach(TerminiPacijenata t in termini) {
                if (t.lekar == "Jova Jovic")
                {
                    retVal  = "Jovan Jovanovic";
                }
                else retVal = "Jova Jovic";
            }

            return retVal;
        }
    }
}
