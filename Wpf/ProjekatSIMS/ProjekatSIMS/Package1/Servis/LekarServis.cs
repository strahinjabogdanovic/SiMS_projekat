using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
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
        public ObservableCollection<TerminiPacijenata> NadjiTermine()
        {

            TerminiFileStorage termini = new TerminiFileStorage();
            ObservableCollection<TerminiPacijenata> tp = new ObservableCollection<TerminiPacijenata>();
            List<string> lines = termini.ProcitajTermine();
            foreach (string linee in lines)
            {
                String[] termin = linee.Split('/');
                var term = new TerminiPacijenata();
                DateTime dateValue;


                if (DateTime.TryParseExact(termin[0], "dd.MM.yyyy.", CultureInfo.InvariantCulture,
                    DateTimeStyles.AdjustToUniversal, out dateValue))
                {
                    term.PraviDatum = dateValue.Date;
                }

                term.datum = dateValue.ToString("dd.MM.yyyy.");
                term.vreme = termin[1].ToString();
                term.lekar = termin[2].ToString();
                term.soba = termin[3].ToString();
                term.id = Int16.Parse(termin[4]);
                term.pacijenti = termin[5].ToString();
                if (termin[6].ToString() != null)
                {
                    if (termin[6].ToString() == "Operacija")
                    {
                        term.vrstaTermina = Termin.Operacija;
                    }
                    else if (termin[6].ToString() == "Pregled")
                    {
                        term.vrstaTermina = Termin.Pregled;
                    }

                    ;
                }

                term.jmbg = nadjiJmbgPoImenu(term.pacijenti);

                tp.Add(term);
            }

            tp = IzdvojSkorasnje(tp);
            return tp;
        }

        public ObservableCollection<TerminiPacijenata> IzdvojSkorasnje(ObservableCollection<TerminiPacijenata> nadjeniTermini)
        {
            ObservableCollection<TerminiPacijenata> tp = new ObservableCollection<TerminiPacijenata>();
            foreach (TerminiPacijenata terminPacijenta in nadjeniTermini)
            {
                DateTime dateValue = terminPacijenta.PraviDatum;



                int SamoBuduci = DateTime.Compare(dateValue, DateTime.Today);
                Console.WriteLine(SamoBuduci);
                if (SamoBuduci >= 0)
                {
                    tp.Add(terminPacijenta);
                }
            }

            return tp;
        }

        private string nadjiJmbgPoImenu(string imeIprezime)
        {
            string[] razdvojeno = imeIprezime.Split(' ');
            string ime = razdvojeno[0].ToString();
            string prezime = razdvojeno[1].ToString();
            string jmbg = "";
            NaloziPacijenataFileStorage npfs = new NaloziPacijenataFileStorage();
            List<String> sviNalozi = npfs.procitaniNalozi();
            foreach (string nalog in sviNalozi)
            {
                string[] JedanPodatak = nalog.Split('/');
                string imeIzFajla = JedanPodatak[0];
                string prezimeIzFajla = JedanPodatak[1];
                string jmbgIzFajla = JedanPodatak[2];
                if (ime == imeIzFajla && prezime == prezimeIzFajla)
                {
                    jmbg = jmbgIzFajla;
                }
            }

            return jmbg;

        }
        public string proveriAlergije(string sast, string alergeni, string sifrica)
        {
            string MoguciAlergen = "";
            if (sast != null)
            {
                string[] sastojci = sast.Split(',');
                if (alergeni != null)
                {
                    string[] alergjedan = alergeni.Split(',');
                    foreach (string sastojak in sastojci)
                    {
                        foreach (string aljedan in alergjedan)
                            if (sastojak == "ibuprofen" && aljedan == "alergen1")
                            {
                                MoguciAlergen = sastojak;
                            }
                            else if (sastojak == "paracetamol" && aljedan == "alergen2")
                            {
                                MoguciAlergen = sastojak;
                            }
                    }
                }
            }

            return MoguciAlergen;
        }
    }
}
