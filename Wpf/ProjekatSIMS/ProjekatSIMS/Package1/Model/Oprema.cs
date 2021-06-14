using System.ComponentModel;

namespace ProjekatSIMS.Package1.Model
{

    public class Oprema : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        private string Naziv;
        private string Opreme;
        private string Kolicina;

        public string naziv
        {
            get
            {
                return Naziv;
            }
            set
            {
                if (value != Naziv)
                {
                    Naziv = value;
                    OnPropertyChanged("naziv");
                }
            }
        }

        public string opreme
        {
            get
            {
                return Opreme;
            }
            set
            {
                if (value != Opreme)
                {
                    Opreme = value;
                    OnPropertyChanged("opreme");
                }
            }
        }

        public string kolicina
        {
            get
            {
                return Kolicina;
            }
            set
            {
                if (value != Kolicina)
                {
                    Kolicina = value;
                    OnPropertyChanged("kolicina");
                }
            }
        }


    }
}