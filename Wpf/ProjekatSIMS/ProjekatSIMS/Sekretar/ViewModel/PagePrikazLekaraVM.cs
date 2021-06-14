using ProjekatSIMS.Sekretar.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjekatSIMS.Package1.Model;

namespace ProjekatSIMS.Sekretar.ViewModel
{
    public class PagePrikazLekaraVM : ViewModels
    {
        public ObservableCollection<Package1.Model.Lekar> Lekari { get; set; }

        private PagePrikazLekara page;

        private RelayCommand nazad;
        private RelayCommand grafikon;

        public RelayCommand Nazad
        {
            get { return nazad; }
            set
            {
                nazad = value;
            }
        }

        public RelayCommand Grafikon
        {
            get { return grafikon; }
            set
            {
                grafikon = value;
            }
        }

        public PagePrikazLekaraVM(PagePrikazLekara page)
        {
            this.page = page;

            Lekari = new ObservableCollection<Package1.Model.Lekar>();
            List<String> lines = new List<string>();
            lines = File.ReadAllLines("sekretarLekari.txt").ToList();


            foreach (string linee in lines)
            {
                String[] termin = linee.Split('/');
                var lekar = new Package1.Model.Lekar();
                lekar.ime = termin[0].ToString();
                lekar.prezime = termin[1].ToString();
                lekar.specijalnost = termin[2].ToString();
                lekar.jmbg = long.Parse(termin[3].ToString());
                lekar.datumRodjenja = termin[4].ToString();
                lekar.email = termin[5].ToString();
                lekar.brojTelefona = termin[6].ToString();
                Lekari.Add(lekar);
            }

            this.Nazad = new RelayCommand(Executed_Nazad, CanExecute_NavigateCommand);
            this.Grafikon = new RelayCommand(Executed_Grafikon, CanExecute_NavigateCommand);
        }

        public void Executed_Nazad(object obj)
        {
            page.NavigationService.Navigate(new PageSekretar());
        }

        public void Executed_Grafikon(object obj)
        {
            page.NavigationService.Navigate(new PageGrafikonLekari());
        }

        public bool CanExecute_NavigateCommand(object obj)
        {
            return true;
        }
    }
}
