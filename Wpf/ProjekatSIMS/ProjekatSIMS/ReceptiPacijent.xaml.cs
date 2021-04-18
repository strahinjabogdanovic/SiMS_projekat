using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ProjekatSIMS.Package1;

namespace ProjekatSIMS
{
    /// <summary>
    /// Interaction logic for ReceptiPacijent.xaml
    /// </summary>
    public partial class ReceptiPacijent : Window
    {
        private readonly string filePath;
        public Timer timer;

        public ObservableCollection<Recepti> ReceptiSpisak
        {
            get;
            set;
        }

        public ReceptiPacijent()
        {
            InitializeComponent();

            filePath = "recepti.txt";
            ReceptiSpisak = new ObservableCollection<Recepti>();
            List<String> lines = new List<string>();
            lines = File.ReadAllLines(filePath).ToList();


            foreach (string linee in lines)
            {
                String[] deo = linee.Split('/');
                var recept = new Recepti();

                recept.sifraLeka = deo[0].ToString();
                recept.nazivLeka = deo[1].ToString();
                recept.nacinUzimanja = deo[2].ToString();
                recept.naKolikoSati = int.Parse(deo[3].ToString());
                recept.jmbg = deo[4];
                ReceptiSpisak.Add(recept);

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

        private void Podsetnik_Click(object sender, RoutedEventArgs e)
        {
            timer = new System.Timers.Timer(10000);
            timer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            timer.Start();
        }

        private static void OnTimedEvent(object source, ElapsedEventArgs e) {
            MessageBox.Show("Popijte lek!");
        }
    }
}
