using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatSIMS.Package1
{
    public class TerminiPacijenata : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        private string Datum;
        private string Vreme;
        private string Lekar;
        private string Soba;
        private int Id;

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
