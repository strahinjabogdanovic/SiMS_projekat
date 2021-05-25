using System.Collections.Generic;
using ProjekatSIMS.Package1.Repozitorijum;

namespace ProjekatSIMS.Package1.Servis
{
    class ProstorijeServis
    {
        ProstorijeFileStorage pfs = new ProstorijeFileStorage();
        public void Kreiraj(string tb, string tb1, string tb2, string tb3, string tb4)
        {
            pfs.Kreiraj(tb, tb1, tb2, tb3, tb4);
        }

        public void Obrisi(int currentRowIndex)
        {
            pfs.Obrisi(currentRowIndex);
        }

        public void Update(string update, int currentRowIndex)
        {
            pfs.Update(update, currentRowIndex);
        }

        public void Prikazi(int currentRowIndex)
        {
            pfs.Prikazi(currentRowIndex);
        }

        public void stvari(int currentRowIndex)
        {
            pfs.stvari(currentRowIndex);
        }

        public void renoviranje(string update, int currentRowIndex, string ren, string prostorijaRen)
        {
            pfs.renoviranje(update, currentRowIndex, ren, prostorijaRen);
        }

        public List<string> prostorije_u_cb(int izabrani_red)
        {
            return pfs.prostorije_u_cb(izabrani_red);
        }

        public void prostorija_iz(string naziv_u, string kolicina_u, int izabrani_red)
        {
            pfs.prostorija_iz(naziv_u, kolicina_u, izabrani_red);
        }

        public void prostorija_u(string oprema_u, string naziv_u, string kolicina_u)
        {
            pfs.prostorija_u(oprema_u, naziv_u, kolicina_u);
        }
    }
}
