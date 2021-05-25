using ProjekatSIMS.Package1.Repozitorijum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatSIMS.Package1.Servis
{
    class NaloziPacijenataServis
    {
        NaloziPacijenataFileStorage npfs = new NaloziPacijenataFileStorage();

        public void Kreiraj(string nalog, string pol, string nalogNastavak)
        {
            npfs.Kreiraj(nalog, pol, nalogNastavak);
        }

        public void Obrisi(int currentRowIndex)
        {
            npfs.Obrisi(currentRowIndex);
        }

        public void Update(string update, int currentRowIndex)
        {
            npfs.Update(update, currentRowIndex);
        }

        public List<string> procitaniMedKartoni()
        {
            return npfs.procitaniMedKartoni();
        }

        public List<string> procitaniNalozi()
        {
            return npfs.procitaniNalozi();
        }
    }
}
