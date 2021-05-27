using ProjekatSIMS.Sekretar.View;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatSIMS.Sekretar.ViewModel
{
    public class PageHitnoZakazivanjeVM : ViewModels
    {
        private PageHitnoZakazivanje page;

        private RelayCommand nazad;
        private RelayCommand potvrdi;

        private string s1;
        private string s2;

        public string S1
        {
            get { return s1; }
            set
            {
                if (s1 != value)
                {
                    s1 = value;
                    OnPropertyChanged("S1");
                }
            }
        }
        public string S2
        {
            get { return s2; }
            set
            {
                if (s2 != value)
                {
                    s2 = value;
                    OnPropertyChanged("S2");
                }
            }
        }

        public RelayCommand Nazad
        {
            get { return nazad; }
            set
            {
                nazad = value;
            }
        }

        public RelayCommand Potvrdi
        {
            get { return potvrdi; }
            set
            {
                potvrdi = value;
            }
        }

        public PageHitnoZakazivanjeVM(PageHitnoZakazivanje page)
        {
            this.page = page;

            this.Nazad = new RelayCommand(Executed_Nazad, CanExecute_NavigateCommand);
            this.Potvrdi = new RelayCommand(Executed_Potvrdi, CanExecute_NavigateCommand);
        }

        public void Executed_Nazad(object obj)
        {
            page.NavigationService.Navigate(new PageSekretar());
        }

        public void Executed_Potvrdi(object obj)
        {
            //string oblastLekara = comboBox1.SelectedValue.ToString();
            string tb = S1;
            string tb1 = S2;

            String ime = "";
            String prezime = "";
            Boolean nasao = false;

            using (var sr = new StreamReader("podaci.txt"))
            {

                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    String[] termin = line.Split('/');
                    ime = termin[0];
                    prezime = termin[1];

                    if (ime.Equals(tb) && prezime.Equals(tb1))
                    {
                        //page.NavigationService.Navigate(new PageHitnoZakazTermin(oblastLekara));
                        nasao = true;
                    }


                }

            }

            using (var sr = new StreamReader("naloziGuest.txt"))
            {

                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    String[] termin = line.Split('/');
                    ime = termin[0];
                    prezime = termin[1];

                    if (ime.Equals(tb) && prezime.Equals(tb1))
                    {
                        //page.NavigationService.Navigate(new PageHitnoZakazTermin(oblastLekara));
                        nasao = true;
                    }

                }

            }

            if (nasao == false)
            {
                page.NavigationService.Navigate(new PageKreirajGuestNalog());
            }
            
        }

        public bool CanExecute_NavigateCommand(object obj)
        {
            return true;
        }
    }
}
