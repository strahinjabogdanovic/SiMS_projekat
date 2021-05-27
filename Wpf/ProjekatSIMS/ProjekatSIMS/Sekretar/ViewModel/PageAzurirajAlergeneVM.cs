using ProjekatSIMS.Package1.Kontroler;
using ProjekatSIMS.Sekretar.View;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatSIMS.Sekretar.ViewModel
{
    public class PageAzurirajAlergeneVM : ViewModels
    {
        private PageAzurirajAlergene page;
        private RelayCommand nazad;
        private RelayCommand potvrdi;
        int trenutniRed = 0;
        private string s1;

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

        public PageAzurirajAlergeneVM(PageAzurirajAlergene page, int currentRowIndex)
        {
            this.page = page;

            int redovi = 0;
            string karton = "";
            trenutniRed = currentRowIndex;
            NaloziPacijenataKontroler npk = new NaloziPacijenataKontroler();
            List<string> sviMedKartoni = npk.procitaniMedKartoni();
            foreach (string svi in sviMedKartoni)
            {
                if (redovi == currentRowIndex)
                {
                    karton = svi;
                }
                redovi++;
            }
            string[] infoMedKarton = karton.Split('/');
            S1 = infoMedKarton[1];

            this.Nazad = new RelayCommand(Executed_Nazad, CanExecute_NavigateCommand);
            this.Potvrdi = new RelayCommand(Executed_Potvrdi, CanExecute_NavigateCommand);
        }

        public void Executed_Nazad(object obj)
        {
            page.NavigationService.Navigate(new PageMedKarton(trenutniRed));
        }

        public void Executed_Potvrdi(object obj)
        {
            int idp = 0;
            string kartoni = "";

            try
            {
                NaloziPacijenataKontroler npk = new NaloziPacijenataKontroler();
                List<string> sviKartoni = npk.procitaniMedKartoni();
                foreach (string sviK in sviKartoni)
                {
                    kartoni = sviK;
                    string[] informacije = kartoni.Split('/');
                    if (idp == trenutniRed)
                    {
                        sviKartoni.RemoveAt(trenutniRed);
                        sviKartoni.Insert(trenutniRed, informacije[0] + "/" + S1);
                        File.WriteAllLines(@"medKarton.txt", sviKartoni);
                    }
                    idp++;
                }
            }
            catch (Exception exp)
            { }

            page.NavigationService.Navigate(new PageMedKarton(trenutniRed));
        }

        public bool CanExecute_NavigateCommand(object obj)
        {
            return true;
        }
    }
}
