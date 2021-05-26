using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjekatSIMS.Package1.Kontroler;
using ProjekatSIMS.Package1.Model;

namespace ProjekatSIMS.Upravnik.ViewModel
{
    public class DodajOpremuVM : BindableBase
    {
        public ObservableCollection<Oprema> Opreme{ get; set;}
        int redStvari = 0;
        private string s1;
        private string s2;
        public MyICommand Potvrdi { get; set; }
        public DodajOpremuVM(int c)
        {
            redStvari = c;
            Potvrdi = new MyICommand(PotvrdiKlik);


        }

        private void PotvrdiKlik()
        {
            OpremaKontroler ok = new OpremaKontroler();
            ok.Kreiraj(S1, S2, redStvari);
        }
        public string S1
        {
            get { return s1; }
            set
            {
                if (s1 != value)
                {
                    s1 = value;
                    OnPropertyChanged("S1");
                }
            }
        }
        public string S2
        {
            get { return s2; }
            set
            {
                if (s2 != value)
                {
                    s2 = value;
                    OnPropertyChanged("S2");
                }
            }
        }
    }
}
