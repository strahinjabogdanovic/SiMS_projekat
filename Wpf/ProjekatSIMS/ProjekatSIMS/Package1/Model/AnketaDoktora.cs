using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatSIMS.Package1.Model
{
    class AnketaDoktora : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }


        private string Lekar;
        private string Ljubaznost;
        private string Strucnost;
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


        public string lekar
        {
            get
            {
                return Lekar;
            }
            set
            {
                if (value != Lekar)
                {
                    Lekar = value;
                    OnPropertyChanged("lekar");
                }
            }
        }

        public string ljubaznost
        {
            get
            {
                return Ljubaznost;
            }
            set
            {
                if (value != Ljubaznost)
                {
                    Ljubaznost = value;
                    OnPropertyChanged("ljubaznost");
                }
            }
        }


        public string strucnost
        {
            get
            {
                return Strucnost;
            }
            set
            {
                if (value != Strucnost)
                {
                    Strucnost = value;
                    OnPropertyChanged("strucnost");
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
