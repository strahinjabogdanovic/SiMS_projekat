using ProjekatSIMS.Lekar.View;
using ProjekatSIMS.Package1.Kontroler;
using ProjekatSIMS.Package1.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ProjekatSIMS.Lekar.ViewModel
{
    class SaleVM : ViewModels
    {
        private Sale page;

        private DataGrid tabela = new DataGrid();
        public ObservableCollection<Prostorije> Prostorije { get; set; }
        public RelayCommand Nazad { get; set; }
        public string imeP { get; set; }
        public string prezimeP { get; set; }
        public string jmbgP { get; set; }

        public SaleVM(Sale s, DataGrid dg, string ime, string prezime, string jmbg)
        {
            Prostorije = new ObservableCollection<Prostorije>();
            imeP = ime;
            prezimeP = prezime;
            jmbgP = jmbg;
            page = s;
            tabela = dg;
            ProstorijeKontroler pk = new ProstorijeKontroler();
            List<string> lines = pk.procitaneProstorije();
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

            Nazad = new RelayCommand(Nazad_Click);

        }

        public void Nazad_Click(object obj)
        {
            page.NavigationService.Navigate(new UputBolnicko(imeP, prezimeP, jmbgP));
        }

    }
}
