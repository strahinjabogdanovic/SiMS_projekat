using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using ProjekatSIMS.Package1.Model;

namespace ProjekatSIMS.Lekar.View
{
    /// <summary>
    /// Interaction logic for SpisakRecepata.xaml
    /// </summary>
    public partial class SpisakRecepata : Window
    {
        private readonly string filePath;

        public ObservableCollection<Recepti> ReceptiSpisak
        {
            get;
            set;
        }

        public SpisakRecepata(TextBlock tb)
        {
            InitializeComponent();

            filePath = "recepti.txt";
            ReceptiSpisak = new ObservableCollection<Recepti>();
            List<String> lines = new List<string>();
            lines = File.ReadAllLines(filePath).ToList();

            t.Text = tb.Text;

            foreach (string linee in lines)
            {
                String[] deo = linee.Split('/');
                var recept = new Recepti();

                recept.sifraLeka = deo[0].ToString();
                recept.nazivLeka = deo[1].ToString();
                recept.nacinUzimanja = deo[2].ToString();
                recept.naKolikoSati = int.Parse(deo[3].ToString());
                recept.jmbg = deo[4];

                if (tb.Text == recept.jmbg)
                {
                    ReceptiSpisak.Add(recept);
                }


            }


            this.DataContext = this;

            StreamReader sr = new StreamReader("recepti.txt");
            string line = "";

            while ((line = sr.ReadLine()) != null)
            {
                string[] components = line.Split("/".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            }
            sr.Close();
        }


        private void NoviRecept_Click(object sender, RoutedEventArgs e)
        {
            IzdavanjeRecepta ir = new IzdavanjeRecepta(t);
            ir.ShowDialog();
        }

        private void nazad_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            KartonLekar kartonLekar = new KartonLekar(t.Text);
            this.Close();
            kartonLekar.ShowDialog();
        }
    }
}
