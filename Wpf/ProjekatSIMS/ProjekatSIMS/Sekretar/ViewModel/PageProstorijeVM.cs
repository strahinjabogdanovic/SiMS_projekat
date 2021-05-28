using ProjekatSIMS.Package1.Model;
using ProjekatSIMS.Sekretar.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatSIMS.Sekretar.ViewModel
{
    public class PageProstorijeVM : ViewModels
    {
        public ObservableCollection<Prostorije> Prostorije { get; set; }
        private PageProstorije page;

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

        public PageProstorijeVM(PageProstorije page)
        {
            this.page = page;

            Prostorije = new ObservableCollection<Prostorije>();
            List<String> lines = new List<string>();
            lines = File.ReadAllLines("prostorije.txt").ToList();

            foreach (string linee in lines)
            {
                String[] termin = linee.Split('/');
                var prostorije = new Prostorije();
                prostorije.ime = termin[0].ToString();
                prostorije.oznaka = termin[1].ToString();
                prostorije.namena = termin[2].ToString();
                prostorije.oprema = termin[3].ToString();
                prostorije.renoviranje = termin[5].ToString();

                Prostorije.Add(prostorije);
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
            //page.NavigationService.Navigate(new PageSekretar());
        }

        public bool CanExecute_NavigateCommand(object obj)
        {
            return true;
        }
    }
}
