using System.ComponentModel;

namespace ProjekatSIMS.Package1.Model
{
    public class MedIzvestaj : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }


        private string Vrsta;
        private string Odeljenje;
        private string Sala;
        private string Nalaz;
        private string Kontrola;
        private string Terapija;
        private string Datum;
        private string Jmbg;

        public string vrsta
        {
            get
            {
                return Vrsta;
            }
            set
            {
                if (value != Vrsta)
                {
                    Vrsta = value;
                    OnPropertyChanged("vrsta");
                }
            }
        }

        public string odeljenje
        {
            get
            {
                return Odeljenje;
            }
            set
            {
                if (value != Odeljenje)
                {
                    Odeljenje = value;
                    OnPropertyChanged("prezime");
                }
            }
        }

        public string sala
        {
            get
            {
                return Sala;
            }
            set
            {
                if (value != Sala)
                {
                    Sala = value;
                    OnPropertyChanged("sala");
                }
            }
        }

        public string nalaz
        {
            get
            {
                return Nalaz;
            }
            set
            {
                if (value != Nalaz)
                {
                    Nalaz = value;
                    OnPropertyChanged("nalaz");
                }
            }
        }

        public string kontrola
        {
            get
            {
                return Kontrola;
            }
            set
            {
                if (value != Kontrola)
                {
                    Kontrola = value;
                    OnPropertyChanged("kontrola");
                }
            }
        }

        public string terapija
        {
            get
            {
                return Terapija;
            }
            set
            {
                if (value != Terapija)
                {
                    Terapija = value;
                    OnPropertyChanged("terapija");
                }
            }
        }

        public string datum
        {
            get
            {
                return Datum;
            }
            set
            {
                if (value != Datum)
                {
                    Datum = value;
                    OnPropertyChanged("brojTelefona");
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


    }
}
