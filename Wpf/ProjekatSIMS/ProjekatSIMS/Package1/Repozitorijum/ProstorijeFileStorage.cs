using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using Package1;
using ProjekatSIMS.Package1.Model;

namespace ProjekatSIMS.Package1.Repozitorijum
{
   public class ProstorijeFileStorage
   {
        OpremaFileStorage o = new OpremaFileStorage();
        public ObservableCollection<Prostorije> Prostorije
        {
            get;
            set;
        }
        public void Kreiraj(string tb, string tb1, string tb2, string tb3, string tb4)
      {
            var text = File.ReadAllText(@"prostorije.txt");
            File.WriteAllText(@"prostorije.txt", text + tb + "/" + tb1 + "/" + tb2 + "/" + tb3 + "/" + tb4 + "/" + "-" + Environment.NewLine);

            UpravnikPocetnaStranica s = new UpravnikPocetnaStranica();
            s.ShowDialog();
        }
      
      public void Obrisi(int currentRowIndex)
      {
            int idp = 0;

            try
            {
                ProstorijeFileStorage p = new ProstorijeFileStorage();
                List<string> sveProstorije = p.procitaneProstorije();
                foreach (string sveP in sveProstorije)
                {
                    if (idp == currentRowIndex)
                    {
                        sveProstorije.RemoveAt(currentRowIndex);
                        File.WriteAllLines(@"prostorije.txt", sveProstorije);
                    }
                    idp++;
                }
            }
            catch (Exception e)
            { }
        }
      
      public void Prikazi(int currentRowIndex)
      {
            SveInfoUpravnik svu = new SveInfoUpravnik(currentRowIndex);
            svu.ShowDialog();
        }
      
      public void Update(string update, int currentRowIndex)
      {
            int idp = 0;
            string prostorija = "";

            try
            {
                ProstorijeFileStorage p = new ProstorijeFileStorage();
                List<string> sveProstorije = p.procitaneProstorije();
                foreach (string sveP in sveProstorije)
                {
                    prostorija = sveP;
                    string[] infoProstorija = prostorija.Split('/');
                    if (idp == currentRowIndex)
                    {
                        sveProstorije.RemoveAt(currentRowIndex);
                        sveProstorije.Insert(currentRowIndex, update + infoProstorija[4] + "/" + infoProstorija[5]);
                        File.WriteAllLines(@"prostorije.txt", sveProstorije);
                    }
                    idp++;
                }
            }
            catch (Exception e)
            { }
        }

        public void stvari(int currentRowIndex)
        {
            Stvari w1 = new Stvari(currentRowIndex);
            w1.ShowDialog();
        }

        public int red_prostorije(string s)
        {
            int red = 0;
            using (var sr = new StreamReader(s))
            {
                string ucitano = "";
                ucitano = sr.ReadLine();
                red = int.Parse(ucitano);
            }
            return red;
        }

        public List<string> prostorije_u_cb(int izabrani_red)
        {
            int idp = 0;
            List<string> prostorije = procitaneProstorije();
            List<string> nazivi = new List<string>();

            foreach(string sveP in prostorije)
            {
                if (idp != izabrani_red)
                {
                    string prostorija = sveP;
                    string[] infoProstorija = prostorija.Split('/');
                    nazivi.Add(infoProstorija[0]);
                }
                idp++;
            }
            return nazivi;
        }



        public void prostorija_iz(string naziv_u, string kolicina_u, int izabrani_red)
        {
            int intkol = int.Parse(kolicina_u);

            int idp = 0;
            string prostorija = "";

            try
            {
                List<string> sveProstorije = procitaneProstorije();
                List<string> sveOprema = o.svaOprema(izabrani_red);
                List<string> sveKolicina = o.svaKolicina(izabrani_red);
                var resultO = "";
                var resultK = "";
                foreach (string sveP in sveProstorije)
                {
                    prostorija = sveP;
                    string[] infoProstorija = prostorija.Split('/');
                    if (idp == izabrani_red)
                    {
                        int red = sveOprema.IndexOf(naziv_u);
                        int novaKolicina = o.viseNegoDostupno(naziv_u, intkol, izabrani_red);
                        if (novaKolicina == 0)
                        {
                            sveOprema.RemoveAt(red);
                            sveKolicina.RemoveAt(red);
                            sveProstorije.RemoveAt(izabrani_red);

                            resultO = string.Join(",", sveOprema.ToArray());
                            resultK = string.Join(",", sveKolicina.ToArray());
                        }
                        else
                        {
                            sveKolicina.RemoveAt(red);
                            sveKolicina.Insert(red, novaKolicina.ToString());
                            sveProstorije.RemoveAt(izabrani_red);

                            resultO = string.Join(",", sveOprema.ToArray());
                            resultK = string.Join(",", sveKolicina.ToArray());
                        }
                        sveProstorije.Insert(izabrani_red, infoProstorija[0] + "/" + infoProstorija[1] + "/" + infoProstorija[2] + "/" + resultO + "/" + resultK + "/" + infoProstorija[5]);

                        File.WriteAllLines(@"prostorije.txt", sveProstorije);
                    }
                    idp++;
                }
            }
            catch (System.InvalidOperationException exp)
            { }
        }

        public void prostorija_u(string oprema_u, string naziv_u, string kolicina_u)
        {
            int intkol = int.Parse(kolicina_u);

            int idp = 0;
            string prostorija = "";
            int brojac = 0;

            try
            {
                List<string> sveProstorije = procitaneProstorije();
                foreach (string sveP in sveProstorije)
                {
                    prostorija = sveP;
                    string[] infoProstorija = prostorija.Split('/');
                    if (oprema_u.Contains(infoProstorija[0]))
                    {
                        List<string> sveOprema = o.svaOprema(idp);
                        List<string> sveKolicina = o.svaKolicina(idp);
                        if (sveOprema.Contains(naziv_u))
                        {
                            int red = sveOprema.IndexOf(naziv_u);
                            int izabrana_kolicina = int.Parse(sveKolicina.ElementAt(red));
                            sveKolicina.RemoveAt(red);
                            sveKolicina.Insert(red, (izabrana_kolicina + intkol).ToString());
                            var resultK = string.Join(",", sveKolicina.ToArray());

                            sveProstorije.RemoveAt(idp);
                            sveProstorije.Insert(idp, infoProstorija[0] + "/" + infoProstorija[1] + "/" + infoProstorija[2] + "/" + infoProstorija[3] + "/" + resultK + "/" + infoProstorija[5]);
                            File.WriteAllLines(@"prostorije.txt", sveProstorije);
                            brojac++;
                        }
                        else if(brojac == 0)
                        {
                            string oprema = infoProstorija[3];
                            oprema += "," + naziv_u;

                            string kolicina = infoProstorija[4];
                            kolicina += "," + kolicina_u;

                            sveProstorije.RemoveAt(idp);
                            sveProstorije.Insert(idp, infoProstorija[0] + "/" + infoProstorija[1] + "/" + infoProstorija[2] + "/" + oprema + "/" + kolicina + "/" + infoProstorija[5]);
                            File.WriteAllLines(@"prostorije.txt", sveProstorije);
                        }
                    }
                    idp++;
                }
            }
            catch (System.InvalidOperationException exp)
            { }
        }

        public void renoviranje(string update, int currentRowIndex, string ren)
        {
            int idp = 0;
            string prostorija = "";

            try
            {
                ProstorijeFileStorage p = new ProstorijeFileStorage();
                List<string> sveProstorije = p.procitaneProstorije();
                foreach (string sveP in sveProstorije)
                {
                    prostorija = sveP;
                    string[] infoProstorija = prostorija.Split('/');
                    if (idp == currentRowIndex)
                    {
                        sveProstorije.RemoveAt(currentRowIndex);
                        sveProstorije.Insert(currentRowIndex, update + infoProstorija[4] + "/" + ren);
                        File.WriteAllLines(@"prostorije.txt", sveProstorije);
                    }
                    idp++;
                }
            }
            catch (Exception e)
            { }
        }
        public List<string> procitaneProstorije()
        {
            List<string> prostorije = new List<string>();

            using (var sr = new StreamReader("prostorije.txt"))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    String[] termin = line.Split('/');
                    String ime = termin[0];
                    String oznaka = termin[1];
                    String namena = termin[2];
                    String oprema = termin[3];
                    String kolicina = termin[4];
                    String ren = termin[5];
                    prostorije.Add(ime + "/" + oznaka + "/" + namena + "/" + oprema + "/" + kolicina + "/" + ren);
                }
            }
            return prostorije;
        }

    }
}