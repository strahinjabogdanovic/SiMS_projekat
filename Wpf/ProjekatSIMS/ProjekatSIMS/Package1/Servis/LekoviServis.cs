using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjekatSIMS.Package1.Model;
using ProjekatSIMS.Package1.Repozitorijum;

namespace ProjekatSIMS.Package1.Servis
{
    class LekoviServis
    {
        private LekoviFileStorage lfs = new LekoviFileStorage();
        public void Kreiraj(String s1, String s2, String s3, String s4)
        {
            lfs.Kreiraj(s1, s2, s3, s4);
        }

        public void Obrisi(int currentRowIndex)
        {
            lfs.Obrisi(currentRowIndex);
        }

        public void Izmeni(string update, int currentRowIndex)
        {
            lfs.Izmeni(update, currentRowIndex);
        }
        public Lek VratiNevalidiraneLekove()
        {
            List<string> sviLekovi = lfs.procitaniLekovi();
            var lekPrazan = new Lek();

            foreach (string linee in sviLekovi)
            {
                String[] deo = linee.Split('/');
                var lek = new Lek();

                lek.sifraleka = deo[0].ToString();
                lek.nazivleka = deo[1].ToString();
                lek.sastojci = deo[2].ToString();
                lek.zamena = deo[3].ToString();
                lek.validiran = deo[4].ToString();
                if (lek.validiran != "da")
                {
                    return lek;
                }
            }
            return lekPrazan;
        }
    }
}
