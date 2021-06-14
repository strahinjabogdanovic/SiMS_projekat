using System;
using System.Collections.Generic;
using System.IO;

namespace ProjekatSIMS.Package1.Repozitorijum
{
   public class ObavestenjaFileStorage
   {
        public void Kreiraj(string obavestenje)
        {
            var text = File.ReadAllText(@"obavestenja.txt");
            File.WriteAllText(@"obavestenja.txt", text + obavestenje + Environment.NewLine);
        }

        public void Obrisi(int currentRowIndex)
        {
            try
            {
                int id = 0;
                ObavestenjaFileStorage o = new ObavestenjaFileStorage();
                List<string> svaObavestenja = o.procitanaObavestenja();
                foreach (string svaO in svaObavestenja)
                {
                    if (id == currentRowIndex)
                    {
                        svaObavestenja.RemoveAt(currentRowIndex);
                        File.WriteAllLines(@"obavestenja.txt", svaObavestenja);
                    }
                    id++;
                }
            }
            catch (Exception e)
            { }

        }
      
      public void Prikazi()
      {}
      
      public void Update(string update, int currentRowIndex)
      {
            int id = 0;
            string obavestenja = "";

            try
            {
                ObavestenjaFileStorage o = new ObavestenjaFileStorage();
                List<string> svaObavestenja = o.procitanaObavestenja();
                foreach (string svaO in svaObavestenja)
                {
                    obavestenja = svaO;
                    string[] informacije = obavestenja.Split('/');
                    if (id == currentRowIndex)
                    {
                        svaObavestenja.RemoveAt(currentRowIndex);
                        svaObavestenja.Insert(currentRowIndex, update);
                        File.WriteAllLines(@"obavestenja.txt", svaObavestenja);
                    }
                    id++;
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
                    obavestenja.Add(line);
                }
            }
            return obavestenja;
        }

    }
}