using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using ProjekatSIMS.Lekar.View;
using ProjekatSIMS.Package1.Kontroler;
using ProjekatSIMS.Package1.Model;
using ProjekatSIMS.Upravnik.View;

namespace ProjekatSIMS.Lekar.ViewModel
{
    class LekarPocetnaStranicaVM : BindableBase
    {
        public ObservableCollection<TerminiPacijenata> ZakazTermina
        {
            get;
            set;
        }


        private DataGrid tabela = new DataGrid();
        public MyICommand Kreiraj { get; set; }
        public MyICommand Obrisi { get; set; }
        public MyICommand Promeni { get; set; }
        public MyICommand Prikazi { get; set; }
        public MyICommand Oprema { get; set; }
        public MyICommand Rasporedjivanje { get; set; }
        public MyICommand Lekovi { get; set; }
        public MyICommand Pretrazi { get; set; }
        public MyICommand Renoviranje { get; set; }
        private string pretraga;
        public LekarPocetnaStranicaVM(DataGrid dgp)
        {
            tabela = dgp;
            ZakazTermina = new ObservableCollection<TerminiPacijenata>();
            List<String> lines = new List<string>();
            lines = File.ReadAllLines("termini.txt").ToList();

            foreach (string linee in lines)
            {
                String[] termin = linee.Split('/');
                var termini = new TerminiPacijenata();
                termini.datum = termin[0].ToString();
                termini.vreme = termin[1].ToString();
                termini.lekar = termin[2].ToString();
                termini.soba = termin[3].ToString();
                termini.id = Int16.Parse(termin[4]);
                termini.pacijenti = termin[5].ToString();
                if (termin[6] == "x")
                {
                    termini.vrstaTermina = Termin.Operacija;
                }
                else
                {
                    termini.vrstaTermina = Termin.Pregled;
                }


                ZakazTermina.Add(termini);
            }

        }

        private void KreirajTermin()
        {
            KreirajTerminLekar kp = new KreirajTerminLekar();
            kp.ShowDialog();
        }






    }
}
