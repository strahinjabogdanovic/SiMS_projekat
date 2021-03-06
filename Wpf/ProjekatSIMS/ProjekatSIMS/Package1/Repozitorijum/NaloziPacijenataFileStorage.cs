using System;
using System.Collections.Generic;
using System.IO;
using ProjekatSIMS.Package1.Model;

namespace ProjekatSIMS.Package1.Repozitorijum
{
   public class NaloziPacijenataFileStorage
   {
        Pol p;
        public void Kreiraj(string nalog, string pol, string nalogNastavak)
        {     
            string nalozi = "";           
            int trenutniRed = 0;
            NaloziPacijenataFileStorage np = new NaloziPacijenataFileStorage();
            List<string> sviNalozi = np.procitaniNalozi();
            foreach (string sviN in sviNalozi)
            {
                nalozi = sviN;
                string[] informacije = nalozi.Split('/');
                trenutniRed = int.Parse(informacije[8]) + 1;
            }

            var text = File.ReadAllText(@"podaci.txt");
            File.WriteAllText(@"podaci.txt", text + nalog + "/" + proveraPola(pol) + "/" + nalogNastavak + "/" + trenutniRed + Environment.NewLine);

            var tekst = File.ReadAllText(@"medKarton.txt");
            File.WriteAllText(@"medKarton.txt", tekst + trenutniRed + "/" + Environment.NewLine);

        }

        public Korisnik GetPacijent()
        {
            Korisnik pacijent = new Korisnik();
            List<String> nalozi = procitaniNalozi();
            foreach (string s in nalozi)
            {
                String[] pac = s.Split('/');
                if (pac[0].Equals("Ana") && pac[1].Equals("Markovic"))
                {
                    pacijent.ime = pac[0];
                    pacijent.prezime = pac[1];
                    pacijent.jmbg = long.Parse(pac[2]);
                    pacijent.pol = Pol.Zenski;
                    pacijent.datumRodjenja = pac[4];
                    pacijent.email = pac[5];
                    pacijent.brojTelefona = pac[6];
                    pacijent.adresa = pac[7];
                    pacijent.idKorisnika = int.Parse(pac[8]);
                    return pacijent;
                }
            }
            return pacijent;

        }

        public void IzmenaProfilaPacijent(string adresa, string email, string telefon)
        {

            string tempFile = System.IO.Path.GetTempFileName();

            using (var sr = new StreamReader("podaci.txt"))
            using (var sw = new StreamWriter(tempFile))
            {
                string line;

                while ((line = sr.ReadLine()) != null)
                {

                    String[] pac = line.Split('/');

                    String ime = pac[0];
                    String prezime = pac[1];
                    String jmbg = pac[2];
                    String pol = "Zenski";
                    String datumRodjenja = pac[4];
                    String idKorisnika = pac[8];

                    if (ime.Equals("Ana") && prezime.Equals("Markovic"))
                    {
                        sw.WriteLine(ime + "/" + prezime + "/" + jmbg + "/" + pol + "/" + datumRodjenja + "/" + email + "/" + telefon + "/" + adresa + "/" + idKorisnika);
                    }
                    else
                    {
                        sw.WriteLine(ime + "/" + prezime + "/" + jmbg + "/" + pol + "/" + datumRodjenja + "/" + pac[5] + "/" + pac[6] + "/" + pac[7] + "/" + idKorisnika);
                    }

                }
            }

            File.Delete("podaci.txt");
            File.Move(tempFile, "podaci.txt");

        }

        public string proveraPola(string polOsobe)
        {
            string pol = "";

            if (polOsobe != null)
            {
                if (polOsobe.Contains("Muski"))
                {
                    p = Pol.Muski;
                    pol = "Muski";

                }
                else if (polOsobe.Contains("Zenski"))
                {
                    p = Pol.Zenski;
                    pol = "Zenski";
                }
            }
            return pol;
        }

        public void Obrisi(int currentRowIndex)
        {          
            try
            {
                int id = 0;
                NaloziPacijenataFileStorage np = new NaloziPacijenataFileStorage();
                List<string> sviNalozi = np.procitaniNalozi();
                foreach (string sviN in sviNalozi)
                {
                    if (id == currentRowIndex)
                    {
                        sviNalozi.RemoveAt(currentRowIndex);
                        File.WriteAllLines(@"podaci.txt", sviNalozi);
                    }
                    id++;
                }
            }
            catch (Exception e)
            { }

            try
            {
                int id = 0;
                NaloziPacijenataFileStorage np = new NaloziPacijenataFileStorage();
                List<string> sviNalozi = np.procitaniMedKartoni();
                foreach (string sviN in sviNalozi)
                {
                    if (id == currentRowIndex)
                    {
                        sviNalozi.RemoveAt(currentRowIndex);
                        File.WriteAllLines(@"medKarton.txt", sviNalozi);
                    }
                    id++;
                }
            }
            catch (Exception e)
            { }
        }
      
      public void Update(string update, int currentRowIndex)
      {
            int id = 0;
            string nalozi = "";

            try
            {
                NaloziPacijenataFileStorage np = new NaloziPacijenataFileStorage();
                List<string> sviNalozi = np.procitaniNalozi();
                foreach (string sviN in sviNalozi)
                {
                    nalozi = sviN;
                    string[] informacije = nalozi.Split('/');
                    string[] infoOstalo = update.Split('/');
                    if (id == currentRowIndex)
                    {
                        sviNalozi.RemoveAt(currentRowIndex);
                        sviNalozi.Insert(currentRowIndex, infoOstalo[0] + "/" + infoOstalo[1] + "/" + infoOstalo[2] + "/" + informacije[3] + "/" + infoOstalo[3] + "/" + informacije[5] + "/" + infoOstalo[4] + "/" + informacije[7] + "/" + informacije[8]);
                        File.WriteAllLines(@"podaci.txt", sviNalozi);
                    }
                    id++;
                }
            }
            catch (Exception e)
            { }
        }

        public int dobaviIdPacijentaPoJmbgu(string jmbg)
        {
            int idp=0;
            using (var sars = new StreamReader("podaci.txt"))

            {
                string line;
                int idps = 0;
                while ((line = sars.ReadLine()) != null)
                {
                    String[] deo = line.Split('/');
                    String idK = deo[2];

                    string sifra = deo[8];
                    if (idK == jmbg)
                    {
                        idp = int.Parse(sifra);
                    }
                    idps++;

                }
            }
            return idp;
        }
        public string DobaviAlergije(int idP)
        {
            string alergije = "";
            using (var sars = new StreamReader("medKarton.txt"))

            {
                string line;
                int idps = 0;
                while ((line = sars.ReadLine()) != null)
                {
                    String[] deo = line.Split('/');
                    String idK = deo[0];

                    String alergijica = deo[1];
                    if (int.Parse(idK) == idP)
                    {
                        alergije = alergijica;
                    }
                    idps++;

                }
            }
            return alergije;

        }


        public List<string> procitaniNalozi()
        {
            List<string> nalozi = new List<string>();

            using (var sr = new StreamReader("podaci.txt"))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    nalozi.Add(line);
                }
            }
            return nalozi;
        }

        public List<string> procitaniMedKartoni()
        {
            List<string> medKartoni = new List<string>();

            using (var sr = new StreamReader("medKarton.txt"))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    medKartoni.Add(line);
                }
            }
            return medKartoni;
        }

    }
}