using System;
using System.ComponentModel;

namespace Package1
{
   public class GuestNalog : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }


        private string Ime;
        private string Prezime;
        private long Jmbg;

        public string ime
        {
            get
            {
                return Ime;
            }
            set
            {
                if (value != Ime)
                {
                    Ime = value;
                    OnPropertyChanged("ime");
                }
            }
        }

        public string prezime
        {
            get
            {
                return Prezime;
            }
            set
            {
                if (value != Prezime)
                {
                    Prezime = value;
                    OnPropertyChanged("prezime");
                }
            }
        }

        public long jmbg
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