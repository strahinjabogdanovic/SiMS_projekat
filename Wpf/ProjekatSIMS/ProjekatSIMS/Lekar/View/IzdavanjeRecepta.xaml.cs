using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using ProjekatSIMS.Package1.Model;
using ProjekatSIMS.Package1.Repozitorijum;

namespace ProjekatSIMS.Lekar.View
{
    /// <summary>
    /// Interaction logic for IzdavanjeRecepta.xaml
    /// </summary>
    public partial class IzdavanjeRecepta : Window
    {
        public Lek lek = new Lek();
        public NaloziPacijenataFileStorage pac = new NaloziPacijenataFileStorage();
        public IzdavanjeRecepta(TextBlock tb)
        {
            InitializeComponent();
            string jmbg = tb.Text;
            textBlock.Text = jmbg;
            
        }

        private void Izdaj_Click(object sender, RoutedEventArgs e)
        {
            string sifra = t.Text;
            string naziv = t2.Text;
            string nacin = t3.Text;
            string naKolikoSati = t4.Text;
            using (var sw = new StreamWriter("recepti.txt", true))
            {
                int id = 0;

                sw.WriteLine(sifra + "/" + naziv + "/" + nacin + "/" + naKolikoSati + "/" + textBlock.Text);
                sw.Close();



            }
        }


        private void t2_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Lek lekicPrazan = new Lek();
            lek = lekicPrazan.dobaviLekPoNazivu(t2.Text);
            NaloziPacijenataFileStorage nalozi = new NaloziPacijenataFileStorage();
            int id = nalozi.dobaviIdPacijentaPoJmbgu(textBlock.Text);
            string alerg = nalozi.DobaviAlergije(id);
            proveriAlergije(lek.sastojci, alerg,lek.sifraleka);
            
        }
        private void proveriAlergije(string sast, string alergeni,string sifrica)
        {
            string[] sastojci = sast.Split(',');
            string[] alergjedan = alergeni.Split(',');
            foreach (string sastojak in sastojci) {
                foreach (string aljedan in alergjedan)
                    if (sastojak == "ibuprofen" && aljedan == "alergen1")
                    {
                        upozorenje.Text = "Pacijent je alergican na ovaj lek!";
                        upozorenje.Visibility = Visibility.Visible;
                    }
                else if(sastojak == "paracetamol" && aljedan == "alergen2")
                    {
                        upozorenje.Text = "Pacijent je alergican na ovaj lek!";
                        upozorenje.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        t.Text = sifrica;
                    }
            }
        }

        private void upozorenje_MouseUp(object sender, MouseButtonEventArgs e)
        {
            upozorenje.Visibility = Visibility.Hidden;
        }
    }
}
