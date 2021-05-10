using System;
using System.ComponentModel;
using System.IO;

namespace Package1
{
    public class Lek : INotifyPropertyChanged
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

        public string SifraLeka;
        public string NazivLeka;
        public string Sastojci;
        public string Zamena;
        public string Validiran;

        public Lek() { }
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
        public string validiran
        {
            get
            {
                return Validiran;
            }
            set
            {
                if (value != Validiran)
                {
                    Validiran = value;
                    OnPropertyChanged("validiran");
                }
            }
        }

        public Lek dobaviLekPoNazivu(string naziv)
        {
            Lek lekic = new Lek();
            using (var sars = new StreamReader("lekovi.txt"))

            {
                string line;
                int idps = 0;
                while ((line = sars.ReadLine()) != null)
                {
                    String[] deo = line.Split('/');
                    String idK = deo[1];

                    Console.WriteLine(idK);
                    string sifra = deo[0];
                    string sastojci = deo[2];
                    string zamena = deo[3];
                    string validiran = deo[4];
                    if (idK == naziv)
                    {
                        lekic.sifraleka = sifra;
                        lekic.nazivleka = naziv;
                        lekic.sastojci = sastojci;
                        lekic.zamena = zamena;
                        lekic.validiran = validiran;
                    }
                    idps++;

                }
            }

            return lekic;
        }
    }
}