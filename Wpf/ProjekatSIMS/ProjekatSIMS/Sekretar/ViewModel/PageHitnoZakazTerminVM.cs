using ProjekatSIMS.Package1.Kontroler;
using ProjekatSIMS.Package1.Model;
using ProjekatSIMS.Sekretar.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ProjekatSIMS.Sekretar.ViewModel
{
    public class PageHitnoZakazTerminVM : ViewModels
    {
        public ObservableCollection<TerminiPacijenata> TerminiP { get; set; }

        private PageHitnoZakazTermin page;
        private readonly string filePath;

        private RelayCommand nazad;
        private RelayCommand zakazi;
        private RelayCommand pomeranje;

        public RelayCommand Nazad
        {
            get { return nazad; }
            set
            {
                nazad = value;
            }
        }

        public RelayCommand Zakazi
        {
            get { return zakazi; }
            set
            {
                zakazi = value;
            }
        }

        public RelayCommand Pomeranje
        {
            get { return pomeranje; }
            set
            {
                pomeranje = value;
            }
        }


        String oblastL = "";
        private DataGrid tabela = new DataGrid();

        public PageHitnoZakazTerminVM(PageHitnoZakazTermin page, string oblastLekara, DataGrid dataGridHitnoZakazivanje)
        {
            this.page = page;
            tabela = dataGridHitnoZakazivanje;

            if (oblastLekara != null)
            {
                if (oblastLekara.Contains("Opsta praksa"))
                {
                    oblastL = "Opsta praksa";

                }
                else if (oblastLekara.Contains("Hirurgija"))
                {
                    oblastL = "Hirurgija";
                }
            }

            DateTime danas = DateTime.Now;
            String[] terminin = danas.ToString().Split(' ');
            String[] termin1 = terminin[0].Split('/');
            string dan = "";
            string mesec = "";
            if (int.Parse(termin1[1]) < 10)
            {
                dan = "0" + termin1[1];
            }
            else
            {
                dan = termin1[1];
            }
            if (int.Parse(termin1[0]) < 10)
            {
                mesec = "0" + termin1[0];
            }
            else
            {
                mesec = termin1[0];
            }
            string datum = dan + "." + mesec + "." + termin1[2] + ".";

            String[] termin2 = terminin[1].Split(':');
            string vreme = "";
            int v;
            if (terminin[2].Equals("PM") && int.Parse(termin2[0]) != 12)
            {
                v = int.Parse(termin2[0]) + 12;
                vreme = v.ToString() + ":" + termin2[1];
            }
            else
            {
                v = int.Parse(termin2[0]);
                vreme = v.ToString() + ":" + termin2[1];
            }



            String ime = "";
            String oblast = "";
            using (var srr = new StreamReader("doktoriSpec.txt"))
            {
                string lin;

                while ((lin = srr.ReadLine()) != null)
                {
                    String[] termin = lin.Split('/');
                    ime = termin[0];
                    oblast = termin[1];

                    if (oblast.Equals(oblastL))
                    {
                        filePath = "termini.txt";
                        TerminiP = new ObservableCollection<TerminiPacijenata>();
                        List<String> lines = new List<string>();
                        lines = File.ReadAllLines(filePath).ToList();


                        foreach (string linee in lines)
                        {
                            String[] termini = linee.Split('/');
                            var pacijent = new TerminiPacijenata();

                            if (termini[2].Equals(ime) && termini[0].Equals(datum))
                            {
                                String[] sat = termini[1].Split(':');
                                string sati = sat[0] + sat[1];
                                string sadSati = v.ToString() + termin2[1];

                                if (int.Parse(sati) >= int.Parse(sadSati))
                                {
                                    pacijent.datum = termini[0].ToString();
                                    pacijent.vreme = termini[1].ToString();
                                    pacijent.lekar = termini[2].ToString();
                                    pacijent.soba = termini[3].ToString();
                                    pacijent.id = int.Parse(termini[4].ToString());
                                    pacijent.pacijenti = termini[5].ToString();

                                    TerminiP.Add(pacijent);

                                }
                            }
                        }
                    }
                }

            }


            this.Nazad = new RelayCommand(Executed_Nazad, CanExecute_NavigateCommand);
            this.Zakazi = new RelayCommand(Executed_Zakazi, CanExecute_NavigateCommand);
            this.Pomeranje = new RelayCommand(Executed_Pomeranje, CanExecute_NavigateCommand);
        }

        public void Executed_Nazad(object obj)
        {
            page.NavigationService.Navigate(new PageHitnoZakazivanje());
        }

        public void Executed_Zakazi(object obj)
        {
            int currentRowIndex = tabela.Items.IndexOf(tabela.SelectedItem);
            DataGridRow row = (DataGridRow)tabela.ItemContainerGenerator.ContainerFromIndex(currentRowIndex);

            TextBlock tbPacijent = tabela.Columns[0].GetCellContent(row) as TextBlock;
            TextBlock tbDatum = tabela.Columns[1].GetCellContent(row) as TextBlock;
            TextBlock tbVreme = tabela.Columns[2].GetCellContent(row) as TextBlock;
            TextBlock tbLekar = tabela.Columns[3].GetCellContent(row) as TextBlock;
            TextBlock tbSoba = tabela.Columns[4].GetCellContent(row) as TextBlock;
            string update = (tbPacijent.Text + "/" + tbDatum.Text + "/" + tbVreme.Text + "/" + tbLekar.Text + "/" + tbSoba.Text);

            TerminiKontroler tk = new TerminiKontroler();
            tk.ZakazivanjeSekretar(update);
        }

        public void Executed_Pomeranje(object obj)
        {
            TerminiKontroler tk = new TerminiKontroler();
            int currentRowIndex = tabela.Items.IndexOf(tabela.SelectedItem);

            if (currentRowIndex != -1)
            {
                TerminiPacijenata k = TerminiP.ElementAt(currentRowIndex);
                if (TerminiP.Count > 0)
                {
                    TerminiP.RemoveAt(currentRowIndex);
                }
                else
                {
                    MessageBox.Show("Nije moguce brisati iz prazne tabele.", "Greska!", MessageBoxButton.OK, MessageBoxImage.Error);
                }

                tk.PomeranjeTerminaSekretar(k);
            }

            page.NavigationService.Navigate(new PageHitnoZakazTermin(oblastL));
        }

        public bool CanExecute_NavigateCommand(object obj)
        {
            return true;
        }
    }
}
