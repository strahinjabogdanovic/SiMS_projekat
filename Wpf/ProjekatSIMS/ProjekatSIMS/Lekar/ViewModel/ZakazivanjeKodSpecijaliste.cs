using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using ProjekatSIMS.Lekar.View;
using ProjekatSIMS.Package1.Repozitorijum;

namespace ProjekatSIMS.Lekar.ViewModel
{
    class ZakazivanjeKodSpecijalisteVM : ViewModels
    {
        public string TSpecijalizacija { get; set; }
        public string Jmbg { get; set; }
        public ZakazivanjeKodSpecijaliste zak;
        public RelayCommand zakazi { get; set; }
        public RelayCommand Nazad { get; set; }
        public string Vrednost { get; set; }
        public List<LekariComboBoxItems> Lekari { get; set; }
        private LekariComboBoxItems _lekari1;

        public LekariComboBoxItems Lekari1
        {
            get { return _lekari1; }
            set { _lekari1 = value; }
        }
        public ZakazivanjeKodSpecijalisteVM(ZakazivanjeKodSpecijaliste zakazivanje, string jmbg, string specijalnost)
        {
            TSpecijalizacija = specijalnost;
            Jmbg = jmbg;
            LekarFileStorage lekari = new LekarFileStorage();
            List<string> lekaripospec = lekari.dobaviLekarePoSpecijalizaciji(TSpecijalizacija);
            PopuniLekare(lekaripospec);
        }
        public void PopuniLekare(List<string> lista)
        {
            int i = 0;
            ObservableCollection<LekariComboBoxItems> lekariCombo = new ObservableCollection<LekariComboBoxItems>();
            foreach (string lekar in lista)
            {
                string vrednost = lekar;
                i++;
                LekariComboBoxItems lekarCombo = new LekariComboBoxItems() { Id = i, Name = lekar };
                lekariCombo.Add(lekarCombo);
                Vrednost = lekar;

            }
            Lekari.ForEach(lekariCombo.Add);


        }

    }


}
