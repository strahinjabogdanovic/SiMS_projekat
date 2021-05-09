using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatSIMS.Package1
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

    }
}
