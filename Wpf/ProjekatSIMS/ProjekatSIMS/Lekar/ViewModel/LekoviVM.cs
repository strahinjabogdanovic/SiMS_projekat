using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using ProjekatSIMS.Lekar.View;
using ProjekatSIMS.Package1.Model;
using ProjekatSIMS.Package1.Repozitorijum;

namespace ProjekatSIMS.Lekar.ViewModel
{
    class LekoviVM : ViewModels
    {
        private Lekovi page;
        public RelayCommand Upravniku { get; set; }
        public RelayCommand Nazad { get; set; }
        public RelayCommand Izmeni { get; set; }
        public ObservableCollection<Lek> SviLekovi
        {
            get;
            set;
        }
        public DataGrid tabela = new DataGrid();


        public LekoviVM(Lekovi l, DataGrid dg)
        {
            page = l;
            tabela = dg;
            SviLekovi = new ObservableCollection<Lek>();
            LekoviFileStorage lfs = new LekoviFileStorage();
            SviLekovi = lfs.CitajSveLekove();
            Upravniku = new RelayCommand(Upravniku_Click);
            Nazad = new RelayCommand(Nazad_Click);

        }

        public void Upravniku_Click(object obj)
        {
            if (tabela.SelectedItem != null)
            {

                LekoviFileStorage p = new LekoviFileStorage();
                Lek zaUpravnika = new Lek();
                zaUpravnika = p.vratiUpravniku(tabela);

            }

        }

        public void Nazad_Click(object obj)
        {
            page.NavigationService.Navigate(new ValidacijaLekova());
        }

    }
}
