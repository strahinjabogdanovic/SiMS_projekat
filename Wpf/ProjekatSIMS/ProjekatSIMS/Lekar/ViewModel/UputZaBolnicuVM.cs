using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjekatSIMS.Package1.Kontroler;

namespace ProjekatSIMS.Lekar.ViewModel
{
    class UputZaBolnicuVM : BindableBase
    {
        public string TBrojProtokola { get; set; }
        public string TPacijent { get; set; }
        public string TJmbg { get; set; }
        public string TSoba { get; set; }
        public string TKrevet { get; set; }
        public DateTime DatumOdlaska { get; set; }
        public DateTime DatumDolaska { get; set; }
        public string TDijagnoza { get; set; }
        public MyICommand SacuvajUput { get; set; }
        public UputZaBolnicuVM()
        {
        }
        public UputZaBolnicuVM(string ime, string prezime, string jmbg)
        {
            TPacijent = ime + " " + prezime;
            TJmbg = jmbg;
            SacuvajUput = new MyICommand(Sacuvaj_Click);
        }

        private void Sacuvaj_Click()
        {
            LekarKontroler lk = new LekarKontroler();
            lk.SacuvajUputZaBolnicu(TJmbg, TBrojProtokola, TSoba, TKrevet, DatumDolaska, DatumOdlaska, TDijagnoza);
        }
    }
}
