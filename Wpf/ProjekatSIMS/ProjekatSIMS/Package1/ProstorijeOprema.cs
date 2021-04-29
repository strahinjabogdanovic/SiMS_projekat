using System;
using System.ComponentModel;

namespace Package1
{
   public class ProstorijeOprema: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

      private int KolicinaOpreme;
      private string DatumPremestanja;
      private string ImeProstorije;
      private string OznakaProstorije;
      private string NazivOpreme;

        public string datumpremestanja
        {
            get
            {
                return DatumPremestanja;
            }
            set
            {
                if (value != DatumPremestanja)
                {
                    DatumPremestanja = value;
                    OnPropertyChanged("datumpremestanja");
                }
            }
        }

        public string imeprostorije
        {
            get
            {
                return ImeProstorije;
            }
            set
            {
                if (value != ImeProstorije)
                {
                    ImeProstorije = value;
                    OnPropertyChanged("imeprostorije");
                }
            }
        }

        public string oznakaprostorije
        {
            get
            {
                return OznakaProstorije;
            }
            set
            {
                if (value != OznakaProstorije)
                {
                    OznakaProstorije = value;
                    OnPropertyChanged("oznakaprostorije");
                }
            }
        }

        public string nazivopreme
        {
            get
            {
                return NazivOpreme;
            }
            set
            {
                if (value != NazivOpreme)
                {
                    NazivOpreme = value;
                    OnPropertyChanged("nazivopreme");
                }
            }
        }

        public int kolicinaopreme
        {
            get
            {
                return KolicinaOpreme;
            }
            set
            {
                if (value != KolicinaOpreme)
                {
                    KolicinaOpreme = value;
                    OnPropertyChanged("kolicinaopreme");
                }
            }
        }

    }
}