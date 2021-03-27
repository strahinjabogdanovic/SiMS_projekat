using System;
using System.ComponentModel;

namespace Package1
{
   public class Prostorije : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }


        public bool DodavanjeProstorije()
      {
         // TODO: implement
         return false;
      }
      
      public bool BrisanjeProstorije()
      {
         // TODO: implement
         return false;
      }
      
      public string UvidUProstorije()
      {
         // TODO: implement
         return "";
      }
      
      public string UpdateProstorije()
      {
         // TODO: implement
         return "";
      }
      
      public bool Renoviranje()
      {
         // TODO: implement
         return false;
      }
   
      private string Ime;
      private string Oznaka;
      private string Namena;
      private string Oprema;
      private string VremePocetkaKoriscenja;
      private string VremeKrajaKoriscenja;

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

        public string oznaka
        {
            get
            {
                return Oznaka;
            }
            set
            {
                if (value != Oznaka)
                {
                    Oznaka = value;
                    OnPropertyChanged("oznaka");
                }
            }
        }

        public string namena
        {
            get
            {
                return Namena;
            }
            set
            {
                if (value != Namena)
                {
                    Namena = value;
                    OnPropertyChanged("namena");
                }
            }
        }

        public string oprema
        {
            get
            {
                return Oprema;
            }
            set
            {
                if (value != Oprema)
                {
                    Oprema = value;
                    OnPropertyChanged("oprema");
                }
            }
        }

        public string vremePocetkaKoriscenja
        {
            get
            {
                return VremePocetkaKoriscenja;
            }
            set
            {
                if (value != VremePocetkaKoriscenja)
                {
                    VremePocetkaKoriscenja = value;
                    OnPropertyChanged("vremePocetkaKoriscenja");
                }
            }
        }


        public string vremeKrajaKoriscenja
        {
            get
            {
                return VremeKrajaKoriscenja;
            }
            set
            {
                if (value != VremeKrajaKoriscenja)
                {
                    VremeKrajaKoriscenja = value;
                    OnPropertyChanged("vremeKrajaKoriscenja");
                }
            }
        }

    }
}