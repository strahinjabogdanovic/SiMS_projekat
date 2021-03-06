using Package1;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ProjekatSIMS.Package1.Model;

namespace ProjekatSIMS
{
    public partial class FiltriranaOprema : Window
    {
        public ObservableCollection<ProstorijeOprema> PO
        {
            get;
            set;
        }
        public FiltriranaOprema(String s)
        {
            InitializeComponent();

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

                for (int i = 0; i<duzina; i++)
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

            tb2.Text = s;

            this.DataContext = this;
        }
    }
}
