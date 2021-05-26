using ProjekatSIMS.Package1.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjekatSIMS.Package1.Kontroler;
using ProjekatSIMS.Upravnik.View;
using System.Windows;
using System.ComponentModel;
using System.ComponentModel.Design;

namespace ProjekatSIMS.Upravnik.ViewModel
{
    public class KreirajProstorijuVM : BindableBase
    {
        public ObservableCollection<Prostorije> Prostorije { get; set; }
        public MyICommand Potvrdi { get; set; }
        private string s1;
        private string s2;
        private string s3;
        private string s4;
        private string s5;

        public KreirajProstorijuVM()
        {
            Potvrdi = new MyICommand(PotvrdiKlik);
        }
        private void PotvrdiKlik()
        {
            ProstorijeKontroler pk = new ProstorijeKontroler();
            pk.Kreiraj(S1, S2, S3, S4, S5);
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
        public string S3
        {
            get { return s3; }
            set
            {
                if (s3 != value)
                {
                    s3 = value;
                    OnPropertyChanged("S3");
                }
            }
        }
        public string S4
        {
            get { return s4; }
            set
            {
                if (s4 != value)
                {
                    s4 = value;
                    OnPropertyChanged("S4");
                }
            }
        }
        public string S5
        {
            get { return s5; }
            set
            {
                if (s5 != value)
                {
                    s5 = value;
                    OnPropertyChanged("S5");
                }
            }
        }



    }
}
