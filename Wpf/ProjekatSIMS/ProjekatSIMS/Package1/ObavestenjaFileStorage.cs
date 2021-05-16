using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows.Controls;

namespace Package1
{
   public class ObavestenjaFileStorage
   {
        public ObservableCollection<Obavestenja> Obavesti
        {
            get;
            set;
        }

        public void Kreiraj(string obavestenje)
        {
            var text = File.ReadAllText(@"obavestenja.txt");
            File.WriteAllText(@"obavestenja.txt", text + obavestenje + Environment.NewLine);
        }

        public void Obrisi(int currentRowIndex)
        {
            try
            {
                int idp = 0;
                ObavestenjaFileStorage p = new ObavestenjaFileStorage();
                List<string> svaObavestenja = p.procitanaObavestenja();
                foreach (string svaO in svaObavestenja)
                {
                    if (idp == currentRowIndex)
                    {
                        svaObavestenja.RemoveAt(currentRowIndex);
                        File.WriteAllLines(@"obavestenja.txt", svaObavestenja);
                    }
                    idp++;
                }
            }
            catch (Exception e)
            { }

        }
      
      public void Prikazi()
      {}
      
      public void Update(string update, int currentRowIndex)
      {
            int idp = 0;
            string obavestenja = "";

            try
            {
                ObavestenjaFileStorage p = new ObavestenjaFileStorage();
                List<string> svaObavestenja = p.procitanaObavestenja();
                foreach (string svaO in svaObavestenja)
                {
                    obavestenja = svaO;
                    string[] informacije = obavestenja.Split('/');
                    if (idp == currentRowIndex)
                    {
                        svaObavestenja.RemoveAt(currentRowIndex);
                        svaObavestenja.Insert(currentRowIndex, update);
                        File.WriteAllLines(@"obavestenja.txt", svaObavestenja);
                    }
                    idp++;
                }
            }
            catch (Exception e)
            { }
        }

        public List<string> procitanaObavestenja()
        {
            List<string> obavestenja = new List<string>();

            using (var sr = new StreamReader("obavestenja.txt"))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    String[] informacije = line.Split('/');
                    String naslov = informacije[0];
                    String sadrzaj = informacije[1];
                    String datum = informacije[2];
                    String uloga = informacije[3];

                    obavestenja.Add(naslov + "/" + sadrzaj + "/" + datum + "/" + uloga);
                }
            }
            return obavestenja;
        }

    }
}