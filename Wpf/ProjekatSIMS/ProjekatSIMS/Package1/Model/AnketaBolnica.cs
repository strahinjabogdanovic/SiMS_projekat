using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatSIMS.Package1.Model
{
    class AnketaBolnica : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }


        private string Usluga;
        private string Zaposleni;
        private string Prostorija;
        private string Komentar;
        private string Datum;

        public string datum
        {
            get
            {
                return Datum;
            }
            set
            {
                if (value != datum)
                {
                    Datum = value;
                    OnPropertyChanged("datum");
                }
            }
        }

        public string usluga
        {
            get
            {
                return Usluga;
            }
            set
            {
                if (value != usluga)
                {
                    Usluga = value;
                    OnPropertyChanged("usluga");
                }
            }
        }

        public string prostorija
        {
            get
            {
                return Prostorija;
            }
            set
            {
                if (value != Prostorija)
                {
                    Prostorija = value;
                    OnPropertyChanged("prostorija");
                }
            }
        }


        public string zaposleni
        {
            get
            {
                return Zaposleni;
            }
            set
            {
                if (value != Zaposleni)
                {
                    Zaposleni = value;
                    OnPropertyChanged("zaposleni");
                }
            }
        }

        public string komentar
        {
            get
            {
                return Komentar;
            }
            set
            {
                if (value != Komentar)
                {
                    Komentar = value;
                    OnPropertyChanged("komentar");
                }
            }
        }

    }
}

