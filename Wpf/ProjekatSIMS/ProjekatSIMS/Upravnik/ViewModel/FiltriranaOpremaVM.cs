using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using ProjekatSIMS.Package1.Model;
using ProjekatSIMS.Upravnik.View;

namespace ProjekatSIMS.Upravnik.ViewModel
{
    public class FiltriranaOpremaVM : BindableBase
    {
        public ObservableCollection<ProstorijeOprema> PO { get; set;}
        private FiltriranaPage page;
        private DataGrid tabela = new DataGrid();
        private string s1;

        public FiltriranaOpremaVM(FiltriranaPage page, DataGrid dgp, string s)
        {
            this.page = page;
            tabela = dgp;
            PO = new ObservableCollection<ProstorijeOprema>();
            List<String> lines = new List<string>();
            lines = File.ReadAllLines("prostorije.txt").ToList();

            foreach (string linee in lines)
            {
                String[] termin = linee.Split('/');

                string opremap = termin[3].ToString();
                String[] oprema = opremap.Split(',');
                int duzina = oprema.Length;

                string kolicinap = termin[4].ToString();
                String[] kolicina = kolicinap.Split(',');

                for (int i = 0; i < duzina; i++)
                {
                    string neki = oprema[i];
                    if (neki.Equals(s))
                    {
                        var prostorije = new ProstorijeOprema();
                        prostorije.imeprostorije = termin[0].ToString();
                        prostorije.oznakaprostorije = termin[1].ToString();
                        prostorije.kolicinaopreme = int.Parse(kolicina[i]);
                        PO.Add(prostorije);
                    }
                }
            }

            S1 = s;

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
    }
}
