using System;
using System.ComponentModel;

namespace Package1
{
   public class Obavestenja : INotifyPropertyChanged
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
      private string Sadrzaj;
      private string Uloga;
      private string Datum;

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

        public string sadrzaj
        {
            get
            {
                return Sadrzaj;
            }
            set
            {
                if (value != Sadrzaj)
                {
                    Sadrzaj = value;
                    OnPropertyChanged("sadrzaj");
                }
            }
        }


        public string uloga
        {
            get
            {
                return Uloga;
            }
            set
            {
                if (value != Uloga)
                {
                    Uloga = value;
                    OnPropertyChanged("uloga");
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
                    OnPropertyChanged("datum");
                }
            }
        }

    }
}