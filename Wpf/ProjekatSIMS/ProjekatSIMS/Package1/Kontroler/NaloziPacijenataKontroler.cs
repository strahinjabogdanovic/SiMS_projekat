using ProjekatSIMS.Package1.Servis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatSIMS.Package1.Kontroler
{
    class NaloziPacijenataKontroler
    {
        NaloziPacijenataServis nps = new NaloziPacijenataServis();

        public void Kreiraj(string nalog, string pol, string nalogNastavak)
        {
            nps.Kreiraj(nalog, pol, nalogNastavak);
        }

        public void Obrisi(int currentRowIndex)
        {
            nps.Obrisi(currentRowIndex);
        }

        public void Update(string update, int currentRowIndex)
        {
            nps.Update(update, currentRowIndex);
        }

        public List<string> procitaniMedKartoni()
        {
            return nps.procitaniMedKartoni();
        }

        public List<string> procitaniNalozi()
        {
            return nps.procitaniNalozi();
        }
    }
}
