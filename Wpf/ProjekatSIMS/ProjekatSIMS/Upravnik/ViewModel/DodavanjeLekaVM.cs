﻿using ProjekatSIMS.Package1.Kontroler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using ProjekatSIMS.Sekretar.ViewModel;
using ProjekatSIMS.Upravnik.View;

namespace ProjekatSIMS.Upravnik.ViewModel
{
    public class DodavanjeLekaVM : ViewModels
    {
        private DodavanjeLekaPage page;
        private DataGrid tabela = new DataGrid();
        public MyICommand Potvrdi { get; set; }
        private string s1;
        private string s2;
        private string s3;
        private string s4;
        public DodavanjeLekaVM(DodavanjeLekaPage page)
        {
            Potvrdi = new MyICommand(PotvrdiKlik);
            this.page = page;
        }

        private void PotvrdiKlik()
        {
            LekoviKontroler lk = new LekoviKontroler();
            MessageBox.Show("Lek poslat na validaciju kod lekara");
            lk.Kreiraj(S1, S2, S3, S4);
            page.NavigationService.Navigate(new LekoviPage());
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
    }
}
