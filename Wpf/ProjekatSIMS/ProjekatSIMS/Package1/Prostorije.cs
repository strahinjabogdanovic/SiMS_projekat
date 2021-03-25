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
      private DateTime VremePocetkaKoriscenja;
      private DateTime VremeKrajaKoriscenja;

      public string Ime1
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
                    OnPropertyChanged("Ime");
                }
            }
        }

        public string Oznaka1
        {
            get
            {
                return Oznaka;
            }
            set
            {
                if (value != Oznaka)
                {
                    Ime = value;
                    OnPropertyChanged("Oznaka");
                }
            }
        }

    }
}