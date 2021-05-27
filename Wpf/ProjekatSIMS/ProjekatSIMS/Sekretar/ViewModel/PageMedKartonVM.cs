using ProjekatSIMS.Package1.Kontroler;
using ProjekatSIMS.Sekretar.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatSIMS.Sekretar.ViewModel
{
    public class PageMedKartonVM : ViewModels
    {
        private PageMedKarton page;

        private RelayCommand azuriraj;
        private RelayCommand nazad;

        private string s;
        private string s1;
        private string s2;
        private string s3;
        private string s4;
        private string s5;
        private string s6;
        private string s7;
        private string s8;

        public string S
        {
            get { return s; }
            set
            {
                if (s != value)
                {
                    s = value;
                    OnPropertyChanged("S");
                }
            }
        }

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

        public string S3
        {
            get { return s3; }
            set
            {
                if (s3 != value)
                {
                    s3 = value;
                    OnPropertyChanged("S3");
                }
            }
        }

        public string S4
        {
            get { return s4; }
            set
            {
                if (s4 != value)
                {
                    s4 = value;
                    OnPropertyChanged("S4");
                }
            }
        }

        public string S5
        {
            get { return s5; }
            set
            {
                if (s5 != value)
                {
                    s5 = value;
                    OnPropertyChanged("S5");
                }
            }
        }

        public string S6
        {
            get { return s6; }
            set
            {
                if (s6 != value)
                {
                    s6 = value;
                    OnPropertyChanged("S6");
                }
            }
        }

        public string S7
        {
            get { return s7; }
            set
            {
                if (s7 != value)
                {
                    s7 = value;
                    OnPropertyChanged("S7");
                }
            }
        }

        public string S8
        {
            get { return s8; }
            set
            {
                if (s8 != value)
                {
                    s8 = value;
                    OnPropertyChanged("S8");
                }
            }
        }



        public RelayCommand Azuriraj
        {
            get { return azuriraj; }
            set
            {
                azuriraj = value;
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

        int trenutniRed = 0;

        public PageMedKartonVM(PageMedKarton page, int currentRowIndex)
        {
            this.page = page;

            int red = 0;
            int redovi = 0;
            trenutniRed = currentRowIndex;
            string nalog = "";
            string karton = "";

            NaloziPacijenataKontroler npk = new NaloziPacijenataKontroler();

            List<string> sviNalozi = npk.procitaniNalozi();
            foreach (string sviN in sviNalozi)
            {
                if (red == currentRowIndex)
                {
                    nalog = sviN;
                }
                red++;
            }
            string[] informacije = nalog.Split('/');
            S = informacije[0];
            S1 = informacije[1];
            S2 = informacije[2];
            S3 = informacije[3];
            S4 = informacije[4];
            S5 = informacije[5];
            S6 = informacije[6];
            S7= informacije[7];

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
            S8 = infoMedKarton[1];

            this.Azuriraj = new RelayCommand(Executed_Azuriraj, CanExecute_NavigateCommand);
            this.Nazad = new RelayCommand(Executed_Nazad, CanExecute_NavigateCommand);
        }

        public void Executed_Azuriraj(object obj)
        {
            page.NavigationService.Navigate(new PageAzurirajAlergene(trenutniRed));
        }

        public void Executed_Nazad(object obj)
        {
            page.NavigationService.Navigate(new PageSekretar());
        }

        public bool CanExecute_NavigateCommand(object obj)
        {
            return true;
        }
    }
}
