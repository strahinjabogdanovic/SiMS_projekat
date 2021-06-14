using System;
using System.Collections.Generic;
using System.IO;

namespace ProjekatSIMS.Package1.Repozitorijum
{
    class LekarFileStorage
    {
        string Specijalizacija;
        string Ime;

        public LekarFileStorage() { }
        public string ime
        {
            get
            {
                return Ime;
            }
            set
            {
                if (value != Ime)
                {
                    Ime = value;
                }
            }
        }

        private string prezime;
        private string pol;
        private string datumr;
        private string mail;
        private string broj;
        private string adresa;
        private string jmbg;
        private string tJmbg;


        public List<string> dobaviLekarePoSpecijalizaciji(string spec)
        {

            List<string> spisakLekara = new List<string>();
            using (var sars = new StreamReader("doktoriSpec.txt"))

            {
                string line;
                int idps = 0;
                while ((line = sars.ReadLine()) != null)
                {
                    //if (idps == currentRowIndex)
                    //{


                    String[] deo = line.Split('/');
                    String idK = deo[1];

                    Console.WriteLine(idK);
                    ime = deo[0];
                    if (idK == spec)
                    {
                        spisakLekara.Add(ime);
                    }
                    idps++;

                }
                return spisakLekara;
            }

        }


        private void CitanjeDoKrajaFajla(string spec, StreamReader sars, List<string> spisakLekara, int idps)
        {
            string line;
            while ((line = sars.ReadLine()) != null)
            {
                var idK = IzdvojenoImeLekaraUFajlu(line);
                NadjenLekarOveSpecijalnosti(spec, idK, spisakLekara);
                idps++;
            }
        }

        private string IzdvojenoImeLekaraUFajlu(string line)
        {
            String[] deo = line.Split('/');
            String idK = deo[1];
            ime = deo[0];
            return idK;
        }

        private void NadjenLekarOveSpecijalnosti(string spec, string idK, List<string> spisakLekara)
        {
            if (idK == spec)
            {
                spisakLekara.Add(ime);
            }
        }
        public string[] IzdvajanjeZeljenogKartona(int currentRowIndex)
        {
            string[] podaci = new string[8];

            string tempFile = System.IO.Path.GetTempFileName();

            using (var sr = new StreamReader("lekar.txt")) podaci = UzimanjeRednogBrojaIzabranogTermina(tempFile, sr, currentRowIndex);
            return podaci;
        }

        private string[] UzimanjeRednogBrojaIzabranogTermina(string tempFile, StreamReader sr, int currentRowIndex)
        {
            string[] podaci = new string[8];
            using (var sw = new StreamWriter(tempFile))
            {
                string line;
                int idp = 0;
                while ((line = sr.ReadLine()) != null)
                {
                    podaci = TrazenjeIzabranogTermina(idp, currentRowIndex, line);

                    idp++;
                }
            }

            return podaci;
        }

        private string[] TrazenjeIzabranogTermina(int idp, int currentRowIndex, string line)
        {
            string[] podaci = new string[8];
            if (idp == currentRowIndex)
            {
                UzimanjeJmbgaPacijenta(line);
                using (var sars = new StreamReader("podaci.txt"))
                {
                    string liness;
                    int idps = 0;
                    podaci = CitanjePodatakaOPacijentima(sars, idps);
                }
            }

            return podaci;
        }

        private void UzimanjeJmbgaPacijenta(string line)
        {
            String[] termin = line.Split('/');
            jmbg = termin[6];
            tJmbg = jmbg;
        }

        private string[] CitanjePodatakaOPacijentima(StreamReader sars, int idps)
        {
            string[] podaci = new string[8];
            string liness;
            while ((liness = sars.ReadLine()) != null)
            {
                String[] termini = liness.Split('/');
                var idK = PopunjavanjePacijentaRedom(termini);
                podaci = PopunjavanjeOdgovarajucegPacijenta(idK);

                idps++;
            }

            return podaci;
        }

        private string PopunjavanjePacijentaRedom(string[] termini)
        {
            String idK = termini[2];
            ime = termini[0];
            prezime = termini[1];
            pol = termini[3];
            datumr = termini[4];
            mail = termini[5];
            broj = termini[6];
            adresa = termini[7];
            return idK;
        }

        private string[] PopunjavanjeOdgovarajucegPacijenta(string idK)
        {
            string[] podaci = new string[8];
            if (idK == jmbg)
            {
                podaci[0] = ime;
                podaci[1] = prezime;
                podaci[2] = jmbg;
                podaci[3] = pol;
                podaci[4] = datumr;
                podaci[5] = mail;
                podaci[6] = broj;
                podaci[7] = adresa;
            }

            return podaci;
        }
        public String[] KartonPoJmbgu(string jmbg)
        {
            String[] podaci = new string[8];
            using (var sars = new StreamReader("podaci.txt"))

            {
                string line;
                int idps = 0;
                while ((line = sars.ReadLine()) != null)
                {


                    String[] deo = line.Split('/');
                    String idK = deo[2];

                    Console.WriteLine(idK);
                    string im = deo[0];
                    string prezim = deo[1];
                    string po = deo[3];
                    string datu = deo[4];
                    string mai = deo[5];
                    string br = deo[6];
                    string adre = deo[7];
                    if (idK == jmbg)
                    {
                        podaci[0] = im;
                        podaci[1] = prezim;
                        podaci[2] = jmbg;
                        podaci[3] = po;
                        podaci[4] = datu;
                        podaci[5] = mai;
                        podaci[6] = br;
                        podaci[7] = adre;
                    }

                    idps++;
                }
            }

            return podaci;
        }

    }
}
