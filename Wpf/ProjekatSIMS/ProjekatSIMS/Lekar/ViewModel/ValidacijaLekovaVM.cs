using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjekatSIMS.Lekar.View;
using ProjekatSIMS.Package1.Model;
using ProjekatSIMS.Package1.Servis;

namespace ProjekatSIMS.Lekar.ViewModel
{
    class ValidacijaLekovaVM : ViewModels
    {
        public string Validacija { get; set; }
        public RelayCommand Nazad { get; set; }
        public RelayCommand LekoviCl { get; set; }
        public RelayCommand Zahtev { get; set; }

        public Lek lekKojiValidiramo;

        private ValidacijaLekova vl;

        public ValidacijaLekovaVM(ValidacijaLekova valLekova)
        {
            vl = valLekova;
            LekoviServis ls = new LekoviServis();
            Lek lekNevalidiran = ls.VratiNevalidiraneLekove();
            Validacija = "Zahtev za validaciju leka " + lekNevalidiran.nazivleka;
            lekKojiValidiramo = lekNevalidiran;
            Zahtev = new RelayCommand(Zahtev_Click);
            Nazad = new RelayCommand(Nazad_Click);
            LekoviCl = new RelayCommand(Lekovi_Click);
        }

        private void Zahtev_Click(object obj)
        {
            vl.NavigationService.Navigate(new ValidirajLek(lekKojiValidiramo));
        }

        private void Nazad_Click(object obj)
        {
            vl.NavigationService.Navigate(new LekarPocetna());
        }

        private void Lekovi_Click(object obj)
        {
            vl.NavigationService.Navigate(new Lekovi());
        }
    }
}
