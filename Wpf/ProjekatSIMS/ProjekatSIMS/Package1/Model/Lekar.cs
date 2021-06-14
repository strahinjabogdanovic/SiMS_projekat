using System.ComponentModel;

namespace ProjekatSIMS.Package1.Model
{
   public class Lekar : Zaposleni, INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }



        public System.Collections.ArrayList zakazivanjeTermina;
      
      /// <pdGenerated>default getter</pdGenerated>
      public System.Collections.ArrayList GetZakazivanjeTermina()
      {
         if (zakazivanjeTermina == null)
            zakazivanjeTermina = new System.Collections.ArrayList();
         return zakazivanjeTermina;
      }
      
      /// <pdGenerated>default setter</pdGenerated>
      public void SetZakazivanjeTermina(System.Collections.ArrayList newZakazivanjeTermina)
      {
         RemoveAllZakazivanjeTermina();
         foreach (ZakazivanjeTermina oZakazivanjeTermina in newZakazivanjeTermina)
            AddZakazivanjeTermina(oZakazivanjeTermina);
      }
      
      /// <pdGenerated>default Add</pdGenerated>
      public void AddZakazivanjeTermina(ZakazivanjeTermina newZakazivanjeTermina)
      {
         if (newZakazivanjeTermina == null)
            return;
         if (this.zakazivanjeTermina == null)
            this.zakazivanjeTermina = new System.Collections.ArrayList();
         if (!this.zakazivanjeTermina.Contains(newZakazivanjeTermina))
            this.zakazivanjeTermina.Add(newZakazivanjeTermina);
      }
      
      /// <pdGenerated>default Remove</pdGenerated>
      public void RemoveZakazivanjeTermina(ZakazivanjeTermina oldZakazivanjeTermina)
      {
         if (oldZakazivanjeTermina == null)
            return;
         if (this.zakazivanjeTermina != null)
            if (this.zakazivanjeTermina.Contains(oldZakazivanjeTermina))
               this.zakazivanjeTermina.Remove(oldZakazivanjeTermina);
      }
      
      /// <pdGenerated>default removeAll</pdGenerated>
      public void RemoveAllZakazivanjeTermina()
      {
         if (zakazivanjeTermina != null)
            zakazivanjeTermina.Clear();
      }
   
      private Specijalizacija Specijalizacija;

      private string Ime;
      private string Prezime;
      private string Specijalnost;
      private long Jmbg;
      private string DatumRodjenja;
      private string Email;
      private string BrojTelefona;
      private string Adresa;

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

      public string specijalnost
        {
          get
          {
              return Specijalnost;
          }
          set
          {
              if (value != Specijalnost)
              {
                  Specijalnost = value;
                  OnPropertyChanged("specijalnost");
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

    }
}