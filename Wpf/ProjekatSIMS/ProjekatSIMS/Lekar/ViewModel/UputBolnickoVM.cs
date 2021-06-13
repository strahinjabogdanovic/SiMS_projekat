using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjekatSIMS.Lekar.View;
using ProjekatSIMS.Package1.Kontroler;

namespace ProjekatSIMS.Lekar.ViewModel
{
    public class UputBolnickoVM : ViewModels
    {
        public string TBrojProtokola { get; set; }
        public string TPacijent { get; set; }
        public string TJmbg { get; set; }
        public string TSoba { get; set; }
        public string TKrevet { get; set; }
        public DateTime DatumOdlaska { get; set; }
        public DateTime DatumDolaska { get; set; }
        public string TDijagnoza { get; set; }
        public RelayCommand SacuvajUput { get; set; }
        public RelayCommand Soba { get; set; }
        public UputBolnicko page { get; set; }
        public RelayCommand Nazad { get; set; }

        public UputBolnickoVM(UputBolnicko pg, string ime, string prezime, string jmbg)
        {
            page = pg;
            TPacijent = ime + " " + prezime;
            TJmbg = jmbg;
            SacuvajUput = new RelayCommand(Sacuvaj_Click);
            Soba = new RelayCommand(Soba_Click);
            Nazad = new RelayCommand(Nazad_Click);
        }

        private void Sacuvaj_Click(object obj)
        {
            LekarKontroler lk = new LekarKontroler();
            lk.SacuvajUputZaBolnicu(TJmbg, TBrojProtokola, TSoba, TKrevet, DatumDolaska, DatumOdlaska, TDijagnoza);

        }

        private void Soba_Click(object obj)
        {
            page.NavigationService.Navigate(new Sale(TPacijent.Split(' ')[0], TPacijent.Split(' ')[1], TJmbg));
        }

        private void Nazad_Click(object obj)
        {
            page.NavigationService.Navigate(new KartonPacijenta(TJmbg));
        }


    }
}
