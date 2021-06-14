using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
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
    /// Interaction logic for Podsetnik.xaml
    /// </summary>
    public partial class Podsetnik : Window
    {
        public Timer timer;


        public Podsetnik()
        {
            InitializeComponent();
        }

        private void Potvrdi_Click(object sender, RoutedEventArgs e)
        {
            if (t.Text == null)
            {
                MessageBox.Show("Unesite broj sati!");
            }
            else
            {
                int time = int.Parse(t.Text);
                timer = new System.Timers.Timer(time * 1000);
                timer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
                timer.Start();

            }
            this.Close();
        }

        private static void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            MessageBox.Show("Podsetnik!");
        }
    }
}
