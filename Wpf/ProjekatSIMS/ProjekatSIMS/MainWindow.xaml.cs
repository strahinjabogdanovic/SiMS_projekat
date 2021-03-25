using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProjekatSIMS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        List<string> users = new List<string>();
        List<string> pass = new List<string>();
        List<string> rola = new List<string>();
        string string1 = "pacijent";
        string string2 = "sekretar";
        string string3 = "upravnik";
        string string4 = "lekar";

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            StreamReader sr = new StreamReader("LoginPodaci.txt");
            string line = "";

            while ((line = sr.ReadLine()) != null)
            {
                string[] components = line.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                users.Add(components[0]);
                pass.Add(components[1]);
                rola.Add(components[2]);
            }
            sr.Close();

            if (users.Contains(textBox.Text) && pass.Contains(textBox1.Text) && Array.IndexOf(users.ToArray(), textBox.Text) ==
                Array.IndexOf(pass.ToArray(), textBox1.Text))
            {
                if (rola.Contains(string4) && Array.IndexOf(users.ToArray(), textBox.Text) ==
                Array.IndexOf(rola.ToArray(), string4))
                {
                    LekarPocetnaStranica ps4 = new LekarPocetnaStranica();
                    ps4.ShowDialog();
                }
                else if (rola.Contains(string3) && Array.IndexOf(users.ToArray(), textBox.Text) ==
                Array.IndexOf(rola.ToArray(), string3))
                {
                    UpravnikPocetnaStranica ps3 = new UpravnikPocetnaStranica();
                    ps3.ShowDialog();
                }
                else if (rola.Contains(string2) && Array.IndexOf(users.ToArray(), textBox.Text) ==
                Array.IndexOf(rola.ToArray(), string2))
                {
                    SekretarPocetnaStrana ps2 = new SekretarPocetnaStrana();
                    ps2.ShowDialog();
                }
                else
                {
                    PacijentPocetnaStranica ps = new PacijentPocetnaStranica();
                    ps.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Korisnicko ime ili lozinka je netacno");
            }
        }
    }
}
