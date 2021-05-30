﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using ProjekatSIMS.Lekar.View;
using ProjekatSIMS.Package1.Model;
using ProjekatSIMS.Package1.Repozitorijum;

namespace ProjekatSIMS.Lekar.ViewModel
{
    class SpisakRecepataVM : BindableBase
    {
        private string filePath;
        private string tJmbg;

        private DataGrid tabela = new DataGrid();
        public MyICommand NoviRecept { get; set; }
        public MyICommand Nazad { get; set; }


        public ObservableCollection<Recepti> ReceptiSpisak
        {
            get;
            set;
        }
        public SpisakRecepataVM(string jmbg)
        {
            ReceptiFileStorage rfs = new ReceptiFileStorage();
            tJmbg = jmbg;

            NoviRecept = new MyICommand(NoviRecept_Click);
            Nazad = new MyICommand(nazad_Click);
        }
        public SpisakRecepataVM(DataGrid dgl, string jmbg)
        {
            tabela = dgl;
            tJmbg = jmbg;
            ReceptiSpisak = new ObservableCollection<Recepti>();
            List<String> lines = new List<string>();
            lines = File.ReadAllLines("recepti.txt").ToList();

            foreach (string linee in lines)
            {
                String[] termin = linee.Split('/');
                var recepti = new Recepti();
                recepti.sifraLeka = termin[0].ToString();
                recepti.nazivLeka = termin[1].ToString();
                recepti.nacinUzimanja = termin[2].ToString();
                recepti.naKolikoSati = int.Parse(termin[3].ToString());
                if (termin[4] == jmbg)
                {

                    ReceptiSpisak.Add(recepti);
                }
            }

            NoviRecept = new MyICommand(NoviRecept_Click);
            Nazad = new MyICommand(nazad_Click);
        }



        public string TJmbg
        {
            get { return tJmbg; }
            set
            {
                if (tJmbg != value)
                {
                    tJmbg = value;
                    OnPropertyChanged("TJmbg");
                }
            }
        }

        private void NoviRecept_Click()
        {
            IzdavanjeRecepta ir = new IzdavanjeRecepta(tJmbg);
            ir.ShowDialog();
        }

        private void nazad_Click()
        {
            KartonLekar kartonLekar = new KartonLekar(tJmbg);
            kartonLekar.ShowDialog();
        }

    }
}
