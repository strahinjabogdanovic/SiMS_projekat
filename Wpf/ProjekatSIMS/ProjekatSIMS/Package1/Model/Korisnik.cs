using System.ComponentModel;

namespace ProjekatSIMS.Package1.Model
{
   public class Korisnik : INotifyPropertyChanged
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
      private Pol Pol;
      private string DatumRodjenja;
      private string Email;
      private string BrojTelefona;
      private string Adresa;
      private int IdKorisnika;

      private string JMBG;

      public string jMBG
      {
          get
          {
              return JMBG;
          }
          set
          {
              if (value != JMBG)
              {
                  JMBG = value;
                  OnPropertyChanged("jMBG");
              }
          }
      }

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

        public Pol pol
        {
            get
            {
                return Pol;
            }
            set
            {
                if (value != Pol)
                {
                    Pol = value;
                    OnPropertyChanged("pol");
                }
            }
        }

        public string datumRodjenja
        {
            get
            {
                return DatumRodjenja;
            }
            set
            {
                if (value != DatumRodjenja)
                {
                    DatumRodjenja = value;
                    OnPropertyChanged("datumRodjenja");
                }
            }
        }

        public string email
        {
            get
            {
                return Email;
            }
            set
            {
                if (value != Email)
                {
                    Email = value;
                    OnPropertyChanged("email");
                }
            }
        }

        public string brojTelefona
        {
            get
            {
                return BrojTelefona;
            }
            set
            {
                if (value != BrojTelefona)
                {
                    BrojTelefona = value;
                    OnPropertyChanged("brojTelefona");
                }
            }
        }

        public string adresa
        {
            get
            {
                return Adresa;
            }
            set
            {
                if (value != Adresa)
                {
                    Adresa = value;
                    OnPropertyChanged("adresa");
                }
            }
        }

        public int idKorisnika
        {
            get
            {
                return IdKorisnika;
            }
            set
            {
                if (value != IdKorisnika)
                {
                    IdKorisnika = value;
                    OnPropertyChanged("idKorisnika");
                }
            }
        }

    }
}