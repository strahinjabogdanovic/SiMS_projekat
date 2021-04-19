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
using System.Windows.Shapes;

namespace ProjekatSIMS
{
    /// <summary>
    /// Interaction logic for PrioritetLekar.xaml
    /// </summary>
    public partial class PrioritetLekar : Window
    {
        public PrioritetLekar()
        {
            InitializeComponent();
            using (var sr = new StreamReader("doktori.txt"))
            {
                string line = " ";
                while ((line = sr.ReadLine()) != null)
                {
                    String[] termin = line.Split('/');
                    ComboBoxItem newitem = new ComboBoxItem();
                    newitem.Content = termin[0];
                    cb1.Items.Add(newitem);
                }
            }
        }

        private void Potvrdi_Click(object sender, RoutedEventArgs e)
        {
            String cb = cb1.SelectedValue.ToString();
            String[] cbb = cb.Split(' ');
            Console.WriteLine(cbb[1] + cbb[2]);
            LekarZakaz lz = new LekarZakaz(cbb[1] + " " + cbb[2]);
            lz.ShowDialog();
        }
    }
}
