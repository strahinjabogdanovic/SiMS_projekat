using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ProjekatSIMS.Package1.Servis
{
    public class DatumiServis
    {
        public int danasnjiDatum()
        {
            DateTime danas = DateTime.Now;
            string[] datumd = danas.ToString().Split(' ');
            string[] dand = datumd[0].Split('-');
            string dan = dand[0];
            int datum_danas = int.Parse(dan);

            return datum_danas;
        }

        public int izabraniDatum(DatePicker myDatePicker)
        {
            string datep = myDatePicker.ToString();
            string[] datump = datep.Split(' ');
            string[] datumpr = datump[0].Split('-');
            string danp = datumpr[0];
            int datum_premestanja = int.Parse(danp);

            return datum_premestanja;
        }

        public String izvestajDatumi(DatePicker myDatePicker)
        {
            string datum = myDatePicker.ToString();
            String[] termin = datum.Split(' ');
            String[] termin1 = termin[0].Split('-');
            string datum1 = termin1[0] + "." + termin1[1] + "." + termin1[2] + ".";
            return datum1;
        }


    }
}