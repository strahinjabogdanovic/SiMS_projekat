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
using ProjekatSIMS.Package1.Repozitorijum;

namespace ProjekatSIMS
{
    /// <summary>
    /// Interaction logic for SpisakLekova.xaml
    /// </summary>
    public partial class SpisakLekova : Window
    {
        private readonly string filePath;

        public ObservableCollection<Lek> SviLekovi
        {
            get;
            set;
        }

        public SpisakLekova()
        {
            filePath = "lekovi.txt";
            SviLekovi = new ObservableCollection<Lek>();
            List<String> lines = new List<string>();
            lines = File.ReadAllLines(filePath).ToList();


            foreach (string linee in lines)
            {
                String[] deoLeka = linee.Split('/');
                var lek = new Lek();
                lek.sifraleka = deoLeka[0];
                lek.nazivleka = deoLeka[1].ToString();
                lek.sastojci = deoLeka[2].ToString();
                lek.zamena = deoLeka[3].ToString();
                if (deoLeka[4]=="ne" || deoLeka[4]=="da")
                {
                    lek.validiran = deoLeka[4].ToString();
                }
                else
                {
                    lek.validiran = "ne";
                }
                SviLekovi.Add(lek);

            }

            InitializeComponent();
            this.DataContext = this;

            StreamReader sr = new StreamReader("lekovi.txt");
            string line = "";

            while ((line = sr.ReadLine()) != null)
            {
                string[] components = line.Split("/".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            }
            sr.Close();
        }

        private void Izmeni_Click(object sender, RoutedEventArgs e)
        {
            //update funkcija kod lekova je izmenjena, prima druge parametre (15.05.2021.)
            /*LekoviFileStorage p = new LekoviFileStorage();
            p.Izmeni(dataGridLekovi);*/
        }


        private void Upravniku_Click(object sender, RoutedEventArgs e)
        {
            LekoviFileStorage p = new LekoviFileStorage();
            Lek zaUpravnika = new Lek();
            zaUpravnika=p.vratiUpravniku(dataGridLekovi);
            
        }
    }
}
