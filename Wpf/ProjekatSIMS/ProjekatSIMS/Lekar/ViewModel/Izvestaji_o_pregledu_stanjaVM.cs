using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using ProjekatSIMS.Lekar.View;
using ProjekatSIMS.Package1.Model;
using ProjekatSIMS.Package1.Repozitorijum;

namespace ProjekatSIMS.Lekar.ViewModel
{
    class Izvestaji_o_pregledu_stanjaVM : BindableBase
    {
        private DataGrid tabela = new DataGrid();
        private string tJmbg;
        public MyICommand Izmeni { get; set; }

        public MyICommand PrikaziTooltip { get; set; }
        public MyICommand SakrijTooltip { get; set; }
        public MyICommand Nazad { get; set; }

        private Visibility tooltip = Visibility.Hidden;

        public Visibility Tooltip
        {
            get
            {
                return tooltip;
            }
            set
            {
                tooltip = value;

                OnPropertyChanged("Tooltip");
            }
        }
        public ObservableCollection<MedIzvestaj> Izvopr { get; set; }
        public Izvestaji_o_pregledu_stanjaVM(TextBlock t, DataGrid dgp)
        {
            tabela = dgp;
            tJmbg = t.Text;
            Izvopr = new ObservableCollection<MedIzvestaj>();
            IzvestajiFileStorage ifs = new IzvestajiFileStorage();
            ifs.CitanjeIzvestaja(tJmbg, dgp, Izvopr);

            PridruzivanjeMetodaKomandama();
        }

        private void PridruzivanjeMetodaKomandama()
        {
            Izmeni = new MyICommand(Izmeni_Click);
            SakrijTooltip = new MyICommand(Button_MouseLeave);
            Nazad = new MyICommand(TextBlock_MouseLeftButtonUp);
        }


        public string TJmbg
        {
            get { return tJmbg; }
            set
            {
                if (tJmbg != value)
                {
                    tJmbg = value;
                    OnPropertyChanged("TJmbg");
                }
            }
        }


        private void Izmeni_Click()
        {

            if (tabela.SelectedItem == null)
            {
                PrikaziTooltip = new MyICommand(Button_MouseEnter);

            }

            int currentRowIndex = tabela.Items.IndexOf(tabela.SelectedItem);
            IzvestajiFileStorage ifs = new IzvestajiFileStorage();
            ifs.Izmeni(currentRowIndex, tabela);
        }



        private void TextBlock_MouseLeftButtonUp()
        {
            KartonLekar karton = new KartonLekar(tJmbg);
            karton.ShowDialog();
        }

        private void Button_MouseEnter()
        {
            Tooltip = Visibility.Visible;
        }

        private void Button_MouseLeave()
        {
            Tooltip = Visibility.Hidden;
        }
    }
}
