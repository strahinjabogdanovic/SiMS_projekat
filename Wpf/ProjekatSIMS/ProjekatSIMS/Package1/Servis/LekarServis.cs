using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using ProjekatSIMS.Package1.Model;
using ProjekatSIMS.Package1.Repozitorijum;

namespace ProjekatSIMS.Package1.Servis
{
    class LekarServis
    {
        public LekarServis() { }

        public void SacuvajUputZaBolnicu(string JmbgP, string brk, string soba, string krevet, DateTime datumd, DateTime datumo, string dijag)
        {
            UputiFileStorage u = new UputiFileStorage();
            u.SacuvajUputZaBolnicu(JmbgP, brk, soba, krevet, datumd, datumo, dijag);
        }
        public ObservableCollection<Recepti> NadjiRecepte(string jmbg)
        {
            ObservableCollection<Recepti> ReceptiOdPacijenta = new ObservableCollection<Recepti>();
            List<String> lines = new List<string>();
            ReceptiFileStorage r = new ReceptiFileStorage();
            lines=r.Citanje();

            foreach (string linee in lines)
            {
                String[] termin = linee.Split('/');
                var recepti = new Recepti();
                recepti.sifraLeka = termin[0].ToString();
                recepti.nazivLeka = termin[1].ToString();
                recepti.nacinUzimanja = termin[2].ToString();
                recepti.naKolikoSati = int.Parse(termin[3].ToString());
                if (termin[4] == jmbg)
                {
                    ReceptiOdPacijenta.Add(recepti);
                }
            }
            return ReceptiOdPacijenta;
        }

        public ObservableCollection<MedIzvestaj> NadjiIzvestaje(string tJmbg)
        {
            IzvestajiFileStorage izv = new IzvestajiFileStorage();
            List<String> lines = izv.CitanjeIzvestaja();
            ObservableCollection<MedIzvestaj> mi = new ObservableCollection<MedIzvestaj>();
            foreach (string linee in lines)
            {
                String[] deo = linee.Split('/');
                var izvestaj = new MedIzvestaj();

                izvestaj.vrsta = deo[0].ToString();
                izvestaj.odeljenje = deo[1].ToString();
                izvestaj.sala = deo[2].ToString();
                izvestaj.nalaz = deo[3].ToString();
                izvestaj.kontrola = deo[4].ToString();
                izvestaj.terapija = deo[5].ToString();
                izvestaj.datum = deo[6].ToString();
                izvestaj.jmbg = deo[7].ToString();

                if (tJmbg == izvestaj.jmbg)
                {
                    mi.Add(izvestaj);
                    tJmbg = izvestaj.jmbg;
                }
            }

            return mi;

        }
    }
}
