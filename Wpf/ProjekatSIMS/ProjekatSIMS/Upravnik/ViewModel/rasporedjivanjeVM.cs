using System;
using System.Collections.Generic;
using System.Windows.Controls;
using ProjekatSIMS.Package1.Kontroler;


namespace ProjekatSIMS.Upravnik.ViewModel
{
    public class rasporedjivanjeVM : BindableBase
    {
        int izabrani_red = 0;
        ProstorijeKontroler pk = new ProstorijeKontroler();
        private ComboBox kombo;
        public rasporedjivanjeVM(int currentRowIndex)
        {
            izabrani_red = currentRowIndex;

            List<string> imena_prostorija = pk.prostorije_u_cb(izabrani_red);
            foreach (string imena in imena_prostorija)
            {
                ComboBoxItem newitem = new ComboBoxItem();
                newitem.Content = imena;
                Kombo.Items.Add(newitem);
            }
        }
        public ComboBox Kombo
        {
            get { return kombo; }
            set
            {
                if (kombo != value)
                {
                    kombo = value;
                    OnPropertyChanged("Kombo");
                }
            }
        }
        private int danasnjiDatum()
        {
            DateTime danas = DateTime.Now;
            string[] datumd = danas.ToString().Split(' ');
            string[] dand = datumd[0].Split('-');
            string dan = dand[0];
            int datum_danas = int.Parse(dan);

            return datum_danas;
        }
       /*private int izabraniDatum()
        {
            string datep = myDatePicker.ToString();
            string[] datump = datep.Split(' ');
            string[] datumpr = datump[0].Split('-');
            string danp = datumpr[0];
            int datum_premestanja = int.Parse(danp);

            return datum_premestanja;
        }*/


    }
}
