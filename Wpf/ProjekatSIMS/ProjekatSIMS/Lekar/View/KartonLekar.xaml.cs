using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace ProjekatSIMS.Lekar.View
{
    /// <summary>
    /// Interaction logic for KartonLekar.xaml
    /// </summary>
    public partial class KartonLekar : Window
    {
        private DataGrid dataGridLekar;

        public KartonLekar()
        {
        }

        public KartonLekar(string jmbg)
        {
            InitializeComponent();
            this.DataContext = new ProjekatSIMS.Lekar.ViewModel.KartonLekarVM(jmbg);
        }

        public KartonLekar(DataGrid dataGridLekar)
        {
            this.dataGridLekar = dataGridLekar;

            this.DataContext = new ProjekatSIMS.Lekar.ViewModel.KartonLekarVM(dataGridLekar);
        }
    }
}