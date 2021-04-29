using System;
using System.ComponentModel;

namespace Package1
{
   public class Lek: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
        /*public System.Collections.ArrayList sastojci;

        /// <pdGenerated>default getter</pdGenerated>
        public System.Collections.ArrayList GetSastojci()
        {
           if (sastojci == null)
              sastojci = new System.Collections.ArrayList();
           return sastojci;
        }

        /// <pdGenerated>default setter</pdGenerated>
        public void SetSastojci(System.Collections.ArrayList newSastojci)
        {
           RemoveAllSastojci();
           foreach (Sastojci oSastojci in newSastojci)
              AddSastojci(oSastojci);
        }

        /// <pdGenerated>default Add</pdGenerated>
        public void AddSastojci(Sastojci newSastojci)
        {
           if (newSastojci == null)
              return;
           if (this.sastojci == null)
              this.sastojci = new System.Collections.ArrayList();
           if (!this.sastojci.Contains(newSastojci))
              this.sastojci.Add(newSastojci);
        }

        /// <pdGenerated>default Remove</pdGenerated>
        public void RemoveSastojci(Sastojci oldSastojci)
        {
           if (oldSastojci == null)
              return;
           if (this.sastojci != null)
              if (this.sastojci.Contains(oldSastojci))
                 this.sastojci.Remove(oldSastojci);
        }

        /// <pdGenerated>default removeAll</pdGenerated>
        public void RemoveAllSastojci()
        {
           if (sastojci != null)
              sastojci.Clear();
        }*/

        private string SifraLeka;
        private string NazivLeka;
        private string Sastojci;
        private string Zamena;


        public string nazivleka
        {
            get
            {
                return NazivLeka;
            }
            set
            {
                if (value != NazivLeka)
                {
                    NazivLeka = value;
                    OnPropertyChanged("nazivleka");
                }
            }
        }



            public string sifraleka
        {
            get
            {
                return SifraLeka;
            }
            set
            {
                if (value != SifraLeka)
                {
                    SifraLeka = value;
                    OnPropertyChanged("sifraleka");
                }
            }
        }

        public string sastojci
        {
            get
            {
                return Sastojci;
            }
            set
            {
                if (value != Sastojci)
                {
                    Sastojci = value;
                    OnPropertyChanged("sastojci");
                }
            }
        }

        public string zamena
        {
            get
            {
                return Zamena;
            }
            set
            {
                if (value != Zamena)
                {
                    Zamena = value;
                    OnPropertyChanged("zamena");
                }
            }
        }
    }
}