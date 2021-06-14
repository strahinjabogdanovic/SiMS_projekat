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
    /// Interaction logic for StareBeleske.xaml
    /// </summary>
    public partial class StareBeleske : Window
    {
        public StareBeleske()
        {
            InitializeComponent();

            using (var sr = new StreamReader("beleske.txt"))
            {
                String beleske = "";
                string line;
                int id = 0;
                while ((line = sr.ReadLine()) != null)
                {

                    beleske += "\n" + line;

                }

                tx.Text = beleske;
            }

        }
    }
}
