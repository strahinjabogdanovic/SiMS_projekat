using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace ProjekatSIMS.Lekar.View
{
    /// <summary>
    /// Interaction logic for Izvestaj.xaml
    /// </summary>
    public partial class Izvestaj : Window
    {
        public Izvestaj()
        {
        }

        public Izvestaj(TextBlock td, TextBlock td1, TextBlock td2)
        {
            InitializeComponent();

            t.Text = td.Text;
            t1.Text = td1.Text;
            t2.Text = td2.Text;
        }



        private void Sacuvaj_Click(object sender, RoutedEventArgs e)
        {
            bool radio = (bool)r1.IsChecked;
            string odeljenje = tBox.Text;
            string soba = tBox2.Text;
            string nalaz = tBox3.Text;
            string kontrola = tBox4.Text;
            string terapija = tBox5.Text;
            DateTime datum = d.DisplayDate;

            using (var sw = new StreamWriter("izvestaji.txt", true))
            {
                string line;
                //int id = 0;


                if (radio == true)
                {
                    sw.WriteLine((r1.Content).ToString() + "/" + odeljenje + "/" + soba + "/" + nalaz + "/" + kontrola + "/" + terapija + "/" + datum.ToString("dddd, dd MMMM yyyy") + "/" + t2.Text);
                    sw.Close();
                }
                else
                {
                    sw.WriteLine((r2.Content).ToString() + "/" + odeljenje + "/" + soba + "/" + nalaz + "/" + kontrola + "/" + terapija + "/" + datum.ToString("dddd, dd MMMM yyyy") + "/" + t2.Text);
                    sw.Close();
                }

            }
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string JmbgProsledjen = t2.Text;
            KartonLekar karton = new KartonLekar(JmbgProsledjen);
            this.Close();
            karton.ShowDialog();
        }

        private void Nazad_Click(object sender, RoutedEventArgs e)
        {
            string JmbgProsledjen = t2.Text;
            KartonLekar karton = new KartonLekar(JmbgProsledjen);
            this.Close();
            karton.ShowDialog();

        }
    }
}
