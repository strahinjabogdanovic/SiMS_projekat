using System;
using System.Collections.Generic;
using System.IO;

namespace ProjekatSIMS.Package1.Repozitorijum
{
    public class AnketaStorage
    {
        public List<String> Doktori()
        {

            using (var sr = new StreamReader("doktori.txt"))
            {
                string lines;
                string doktor = "";
                List<String> doktori_cb = new List<String>();
                while ((lines = sr.ReadLine()) != null)
                {
                    String[] doktori = lines.Split('/');
                    doktor = doktori[0];
                    doktori_cb.Add(doktor);
                }

                return doktori_cb;
            }

        }

        public bool Anketa_period(String s)
        {

            using (var sr = new StreamReader("anketaLekar.txt"))
            {
                string lines;
                string datum_prosle_ankete = "";
                bool retVal = false;

                while ((lines = sr.ReadLine()) != null)
                {
                    String[] doktori = lines.Split('|');
                    string[] datum = doktori[4].Split('.');
                    datum_prosle_ankete = datum[1] + "." + datum[0] + "." + datum[2] + ".";

                    if (doktori[0].Equals(s))
                    {
                        DateTime dt = DateTime.Parse(datum_prosle_ankete + " " + "00:00:00");
                        if (DateTime.Now.Subtract(dt).Days > 40)
                        {
                            retVal = true;
                        }
                        else
                            retVal = false;
                    }
                    else { retVal = true; }
                }

                return retVal;

            }

        }


        public bool pravo_na_anketu_bolnica()
        {
            bool retVal = true;

            using (var sr = new StreamReader("anketaBolnica.txt"))
            {
                string lines;
                string datum_prosle_ankete = "";

                while ((lines = sr.ReadLine()) != null)
                {
                    String[] doktori = lines.Split('|');
                    string[] datum = doktori[4].Split('.');
                    datum_prosle_ankete = datum[1] + "." + datum[0] + "." + datum[2] + ".";

                    DateTime dt = DateTime.Parse(datum_prosle_ankete + " " + "00:00:00");
                    if (DateTime.Now.Subtract(dt).Days < 40)
                    {
                        retVal = false;
                        break;
                    }

                }

                return retVal;

            }

        }

        public bool pravo_na_anketu_lekar(string s)
        {

            bool retVal = false;

            using (var sr = new StreamReader("termini.txt"))
            {
                string lines;
                string doktor = "";
                List<String> doktori_cb = new List<String>();

                while ((lines = sr.ReadLine()) != null)
                {
                    String[] termin = lines.Split('/');
                    string[] datum = termin[0].Split('.');
                    string odrzan_termin = datum[1] + "." + datum[0] + "." + datum[2] + ".";
                    string m = termin[2];
                    if (m.Equals(s))
                    {
                        Console.WriteLine(m);
                        DateTime dt = DateTime.Parse(odrzan_termin + " " + "00:00:00");
                        if (dt.CompareTo(DateTime.Now) < 0 && Anketa_period(s))
                        {
                            retVal = true;
                        }
                    }
                }

            }
            Console.WriteLine(retVal.ToString());
            return retVal;

        }

        public String selektovaniOdgovor(String s)
        {
            string[] c = s.Split(' ');
            return c[1];
        }
    }


}

