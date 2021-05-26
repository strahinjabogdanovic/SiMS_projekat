using System.Collections.Generic;
using ProjekatSIMS.Package1.Servis;

namespace ProjekatSIMS.Package1.Kontroler
{
    class ProstorijeKontroler
    {
        ProstorijeServis ps = new ProstorijeServis();
        public void Kreiraj(string tb, string tb1, string tb2, string tb3, string tb4)
        {
            ps.Kreiraj(tb, tb1, tb2, tb3, tb4);
        }

        public void Obrisi(int currentRowIndex)
        {
            ps.Obrisi(currentRowIndex);
        }

        public void Update(string update, int currentRowIndex)
        {
            ps.Update(update, currentRowIndex);
        }

        public void Prikazi(int currentRowIndex)
        {
            ps.Prikazi(currentRowIndex);
        }

        public void stvari(int currentRowIndex)
        {
            ps.stvari(currentRowIndex);
        }

        public void renoviranje(string update, int currentRowIndex, string ren, string prostorijaRen)
        {
            ps.renoviranje(update, currentRowIndex, ren, prostorijaRen);
        }

        public List<string> prostorije_u_cb(int izabrani_red)
        {
            return ps.prostorije_u_cb(izabrani_red);
        }

        public void prostorija_iz(string naziv_u, string kolicina_u, int izabrani_red)
        {
            ps.prostorija_iz(naziv_u, kolicina_u, izabrani_red);
        }

        public void prostorija_u(string oprema_u, string naziv_u, string kolicina_u)
        {
            ps.prostorija_u(oprema_u, naziv_u, kolicina_u);
        }
        public List<string> procitaneProstorije()
        {
            return ps.procitaneProstorije();
        }
    }
}
