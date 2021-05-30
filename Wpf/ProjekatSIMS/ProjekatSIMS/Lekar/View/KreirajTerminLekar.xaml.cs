﻿using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using ProjekatSIMS.Package1.Model;
using ProjekatSIMS.Package1.Repozitorijum;

namespace ProjekatSIMS.Lekar.View
{
    /// <summary>
    /// Interaction logic for KreirajTerminLekar.xaml
    /// </summary>
    public partial class KreirajTerminLekar : Window
    {
        string JmbgP;
        public ObservableCollection<TerminiPacijenata> ZakazTermina
        {
            get;
            set;
        }


        public KreirajTerminLekar()
        {
            InitializeComponent();
        }
        public KreirajTerminLekar(string jmbg)
        {
            InitializeComponent();
            JmbgP = jmbg;
            tBlock.Text = jmbg;

            KartonLekar karton = new KartonLekar(jmbg);
            textBox_ime.Text = karton.ime;
            textBox_prz.Text = karton.prezime;

        }

        private void Odustani_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Potvrdi_Click(object sender, RoutedEventArgs e)
        {
            Close();
            TerminiFileStorage tfs = new TerminiFileStorage();
            ComboBoxItem vrsta = (ComboBoxItem)comboBox.SelectedItem;
            ComboBoxItem lekaro = (ComboBoxItem)comboBox1.SelectedItem;
            string vrstaTermina = vrsta.Content.ToString();
            string lekar = lekaro.Content.ToString();
            DateTime date = d.DisplayDate;
            string tb = date.ToString("dd.mm.yyyy");
            string tb1 = textBox1.Text;
            string tb2 = textBox2.Text;
            string tb3 = tBlock.Text;
            tfs.Kreiraj(vrstaTermina,lekar,tb,tb1,tb2,tb3);
            
            //ZakazTermina = new ObservableCollection<TerminiPacijenata>();
            //string slj = "";
            //string kfr = "";

           // string vrstaTermina = comboBox.SelectedValue.ToString();
            //string lekar = comboBox1.SelectedValue.ToString();

            //if (lekar != null)
            //{

            //    if (lekar.Contains("Jova Jovic"))
             //   {
             //       slj = "Jova Jovic";

            //    }
            //    else if (lekar.Contains("Jovan Jovanovic"))
            //    {
            //        slj = "Jovan Jovanovic";
            //    }
           // }

           // if (vrstaTermina != null)
           // {

            //    if (vrstaTermina.Contains("Pregled"))
           //     {
           //         kfr = "Pregled";

           //     }
           //     else if (vrstaTermina.Contains("Operacija"))
            //    {
            //        kfr = "Operacija";
           //     }
           // }


           // string tempFile = System.IO.Path.GetTempFileName();

          //  using (var sr = new StreamReader("lekar.txt"))
           // using (var sw = new StreamWriter(tempFile))
           // {
           //     string line;
           //     int id = 0;
           //     while ((line = sr.ReadLine()) != null)
            //    {
          //          String[] termin = line.Split('/');
           //         var lekari = new TerminiPacijenata();
          // //         id = int.Parse(termin[5]);
           //         id++;

           //         sw.WriteLine(line);

           //     }
                
               // sw.WriteLine(kfr + "/" + textBox.Text + "/" + textBox1.Text + "/" + textBox2.Text + "/" + slj + "/" + id);


          //  }
          //  File.Delete("lekar.txt");
          //  File.Move(tempFile, "lekar.txt");



          //  Close();
         //   LekarPocetnaStranica s = new LekarPocetnaStranica();
         //   s.ShowDialog();
            
        }
    }
}