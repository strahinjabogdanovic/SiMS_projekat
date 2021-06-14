using System.ComponentModel;

namespace ProjekatSIMS.Package1.Model
{
   public class ZdravstveniKarton : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        private int IdKartona;
      private int IdPacijenta;
      private string Alergije;

        public int idKartona
        {
            get
            {
                return IdKartona;
            }
            set
            {
                if (value != IdKartona)
                {
                    IdKartona = value;
                    OnPropertyChanged("idKartona");
                }
            }
        }

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

        public string alergije
        {
            get
            {
                return Alergije;
            }
            set
            {
                if (value != Alergije)
                {
                    Alergije = value;
                    OnPropertyChanged("alergije");
                }
            }
        }
    }
}