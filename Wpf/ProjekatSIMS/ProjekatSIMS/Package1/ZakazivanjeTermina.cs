using System;
using System.ComponentModel;

namespace Package1
{
   public class ZakazivanjeTermina : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public bool ZakazivanjeT()
      {
         // TODO: implement
         return false;
      }
      
      public bool OtkazivanjeTermina()
      {
         // TODO: implement
         return false;
      }
      
      public string UvidUTermine()
      {
         // TODO: implement
         return "";
      }
   
      private int IdPacijenta;
      private int IdLekara;

      private Termin VrstaTermina;
      private string Lekar;
      private string Datum;
      private string Vreme;
      private string Soba;
      private int Id;

        public int idPacijenta
        {
            get
            {
                return IdPacijenta;
            }
            set
            {
                if (value != IdPacijenta)
                {
                    IdPacijenta = value;
                    OnPropertyChanged("idPacijenta");
                }
            }
        }

        public int idLekara
        {
            get
            {
                return IdLekara;
            }
            set
            {
                if (value != IdLekara)
                {
                    IdLekara = value;
                    OnPropertyChanged("idLekara");
                }
            }
        }

        public Termin vrstaTermina
        {
            get
            {
                return VrstaTermina;
            }
            set
            {
                if (value != VrstaTermina)
                {
                    VrstaTermina = value;
                    OnPropertyChanged("vrstaTermina");
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

        public string vreme
        {
            get
            {
                return Vreme;
            }
            set
            {
                if (value != Vreme)
                {
                    Vreme = value;
                    OnPropertyChanged("vreme");
                }
            }
        }

  

        public string soba
        {
            get
            {
                return Soba;
            }
            set
            {
                if (value != Soba)
                {
                    Soba = value;
                    OnPropertyChanged("soba");
                }
            }
        }

        public int id
        {
            get
            {
                return Id;
            }
            set
            {
                if (value != Id)
                {
                    Id = value;
                    OnPropertyChanged("id");
                }
            }
        }

    }
}