using System.ComponentModel;

namespace ProjekatSIMS.Package1.Model
{
    public class Recepti : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
        private string SifraLeka;
        private string NazivLeka;
        private string NacinUzimanja;
        private int NaKolikoSati;
        private string Jmbg;


        public string sifraLeka
        {
            get
            {
                return SifraLeka;
            }
            set
            {
                if (value != SifraLeka)
                {
                    SifraLeka = value;
                    OnPropertyChanged("sifraLeka");
                }
            }
        }
        public string nazivLeka
        {
            get
            {
                return NazivLeka;
            }
            set
            {
                if (value != NazivLeka)
                {
                    NazivLeka = value;
                    OnPropertyChanged("nazivLeka");
                }
            }
        }
        public string nacinUzimanja
        {
            get
            {
                return NacinUzimanja;
            }
            set
            {
                if (value != NacinUzimanja)
                {
                    NacinUzimanja = value;
                    OnPropertyChanged("nacinUzimanja");
                }
            }
        }

        public string jmbg
        {
            get
            {
                return Jmbg;
            }
            set
            {
                if (value != Jmbg)
                {
                    Jmbg = value;
                    OnPropertyChanged("jmbg");
                }
            }
        }
        public int naKolikoSati
        {
            get
            {
                return NaKolikoSati;
            }
            set
            {
                if (value != NaKolikoSati)
                {
                    NaKolikoSati = value;
                    OnPropertyChanged("naKolikoSati");
                }
            }
        }
    }
}
