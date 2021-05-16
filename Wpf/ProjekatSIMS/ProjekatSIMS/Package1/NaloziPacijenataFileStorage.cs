using ProjekatSIMS;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows.Controls;

namespace Package1
{
   public class NaloziPacijenataFileStorage
   {
        
        public ObservableCollection<Pacijent> Korisnici
        {
            get;
            set;
        }

        Pol p;
        public void Kreiraj(string nalog, string gender, string nalogNastavak)
        {     
            string nalozi = "";           
            int currentRowIndex = 0;
            NaloziPacijenataFileStorage pn = new NaloziPacijenataFileStorage();
            List<string> sviNalozi = pn.procitaniNalozi();
            foreach (string sviN in sviNalozi)
            {
                nalozi = sviN;
                string[] informacije = nalozi.Split('/');
                currentRowIndex = int.Parse(informacije[8]) + 1;
            }

            var text = File.ReadAllText(@"podaci.txt");
            File.WriteAllText(@"podaci.txt", text + nalog + "/" + proveraPola(gender) + "/" + nalogNastavak + "/" + currentRowIndex + Environment.NewLine);

            var tekst = File.ReadAllText(@"medKarton.txt");
            File.WriteAllText(@"medKarton.txt", tekst + currentRowIndex + "/" + Environment.NewLine);

        }

        public string proveraPola(string gender)
        {
            string pol = "";

            if (gender != null)
            {
                if (gender.Contains("Muski"))
                {
                    p = Pol.Muski;
                    pol = "Muski";

                }
                else if (gender.Contains("Zenski"))
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
                int idp = 0;
                NaloziPacijenataFileStorage p = new NaloziPacijenataFileStorage();
                List<string> sviNalozi = p.procitaniNalozi();
                foreach (string sviN in sviNalozi)
                {
                    if (idp == currentRowIndex)
                    {
                        sviNalozi.RemoveAt(currentRowIndex);
                        File.WriteAllLines(@"podaci.txt", sviNalozi);
                    }
                    idp++;
                }
            }
            catch (Exception e)
            { }

            try
            {
                int idp = 0;
                NaloziPacijenataFileStorage p = new NaloziPacijenataFileStorage();
                List<string> sviNalozi = p.procitaniMedKartoni();
                foreach (string sviN in sviNalozi)
                {
                    if (idp == currentRowIndex)
                    {
                        sviNalozi.RemoveAt(currentRowIndex);
                        File.WriteAllLines(@"medKarton.txt", sviNalozi);
                    }
                    idp++;
                }
            }
            catch (Exception e)
            { }
        }
      
      
      public void Prikazi(DataGrid dataGridNalozi)
      {
            int currentRowIndex = dataGridNalozi.Items.IndexOf(dataGridNalozi.SelectedItem);

            using (var sw = new StreamWriter("redovi.txt"))
            {
                sw.WriteLine(currentRowIndex);
            }

        }
      
      public void Update(string update, int currentRowIndex)
      {
            int idp = 0;
            string nalozi = "";

            try
            {
                NaloziPacijenataFileStorage p = new NaloziPacijenataFileStorage();
                List<string> sviNalozi = p.procitaniNalozi();
                foreach (string sviN in sviNalozi)
                {
                    nalozi = sviN;
                    string[] informacije = nalozi.Split('/');
                    string[] infoOstalo = update.Split('/');
                    if (idp == currentRowIndex)
                    {
                        sviNalozi.RemoveAt(currentRowIndex);
                        sviNalozi.Insert(currentRowIndex, infoOstalo[0] + "/" + infoOstalo[1] + "/" + infoOstalo[2] + "/" + informacije[3] + "/" + infoOstalo[3] + "/" + informacije[5] + "/" + infoOstalo[4] + "/" + informacije[7] + "/" + informacije[8]);
                        File.WriteAllLines(@"podaci.txt", sviNalozi);
                    }
                    idp++;
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
                    String[] informacije = line.Split('/');
                    String ime = informacije[0];
                    String prezime = informacije[1];
                    String jmbg = informacije[2];
                    String pol = informacije[3];
                    String datum = informacije[4];
                    String mail = informacije[5];
                    String brojTel = informacije[6];
                    String adresa = informacije[7];
                    String idx = informacije[8];
                    nalozi.Add(ime + "/" + prezime + "/" + jmbg + "/" + pol + "/" + datum + "/" + mail + "/" + brojTel + "/" + adresa + "/" + idx);
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
                    String[] informacije = line.Split('/');
                    String idx = informacije[0];
                    String alergen = informacije[1];

                    medKartoni.Add(idx + "/" + alergen);
                }
            }
            return medKartoni;
        }

    }
}