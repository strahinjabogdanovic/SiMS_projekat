using System;
using System.IO;
using System.Windows;

namespace ProjekatSIMS.Package1.Repozitorijum
{
    public class antiTrol
    {
        public int broj_pomeranja()
        {
            int broj_pomerenih_termina = 0;
            using (var sr = new StreamReader("termini.txt"))
            {
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    string[] termin = line.Split('/');
                    string pomeren = termin[6];
                    if (pomeren.Equals("x"))
                    {
                        broj_pomerenih_termina++;
                    }
                }

            }
            return broj_pomerenih_termina;
        }


        public bool mogucnost_pomeranja(string s)
        {

            bool retVal = true;
            int br_pom = broj_pomeranja();
            if (br_pom > 4 || s.Equals("x"))
            {
                MessageBox.Show("Nemoguce je pomeriti termin.");
                retVal = false;
            }
            return retVal;
        }



        public bool maksimalan_broj_termina()
        {

            bool retVal = true;
            int broj_termina = 0;
            using (var sr = new StreamReader("termini.txt"))
            {
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    string[] termin = line.Split('/');
                    string d = termin[0];
                    string[] dat = d.Split('.');
                    string datum = dat[1] + "." + dat[0] + "." + dat[2] + ".";

                    if (termin[5] == "Ana Markovic" && DateTime.Parse(datum) > DateTime.Now)
                    {
                        broj_termina++;
                    }

                }

                if (broj_termina > 5)
                {
                    retVal = false;
                }

            }

            return retVal;

        }
    }
}

