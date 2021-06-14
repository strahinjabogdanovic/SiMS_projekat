using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjekatSIMS.Package1.Model;
using ProjekatSIMS.Package1.Repozitorijum;

namespace ProjekatSIMS.Package1.Servis
{
    class AnketaServis
    {
        private AnketaBolnicaStorage ba = new AnketaBolnicaStorage();

        public bool pravo_na_anketu_bolnica()
        {
            bool retVal = true;
            string datum_prosle_ankete = "";

            List<AnketaBolnica> ankete = ba.GetAll();

            foreach (AnketaBolnica ab in ankete)
            {
                string[] datum = ab.datum.Split('.');
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
}
