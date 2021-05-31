using ProjekatSIMS.Package1.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ProjekatSIMS.Package1.Repozitorijum
{
    class IzvestajiFileStorage
    {
        public IzvestajiFileStorage() { }
        public void Izmeni(int currentRowIndex, DataGrid tabela)
        {
            string tempFile = System.IO.Path.GetTempFileName();

            using (var sr = new StreamReader("izvestaji.txt"))
            using (var sw = new StreamWriter(tempFile))
            {
                string line;
                int id = 0;
                while ((line = sr.ReadLine()) != null)
                {
                    //id++;
                    if (id == currentRowIndex)
                    {
                        String[] termin = line.Split('/');
                        var izvestaj = new MedIzvestaj();
                        string jmbg = termin[7].ToString();
                        string odeljenje = termin[1].ToString();
                        string vrsta = termin[0].ToString();

                        string sala = termin[2].ToString();
                        string nalaz = termin[3].ToString();
                        string kontrola = termin[4].ToString();
                        string terapija = termin[5].ToString();
                        string datum = termin[6].ToString();
                        DataGridRow row = (DataGridRow)tabela.ItemContainerGenerator.ContainerFromIndex(currentRowIndex);

                        TextBlock t1 = tabela.Columns[0].GetCellContent(row) as TextBlock;
                        TextBlock t2 = tabela.Columns[1].GetCellContent(row) as TextBlock;
                        TextBlock t3 = tabela.Columns[2].GetCellContent(row) as TextBlock;
                        TextBlock t4 = tabela.Columns[3].GetCellContent(row) as TextBlock;
                        TextBlock t5 = tabela.Columns[4].GetCellContent(row) as TextBlock;
                        TextBlock t6 = tabela.Columns[5].GetCellContent(row) as TextBlock;
                        if (vrsta == t1.Text && odeljenje == t3.Text)
                        {
                            sw.WriteLine(t1.Text + "/" + t3.Text + "/" + sala + "/" + t4.Text + "/" + t5.Text + "/" + t6.Text +
                                         "/" + datum + "/" + jmbg);
                        }
                        else
                        {
                            sw.WriteLine(line);
                        }
                    }
                    else
                    {
                        sw.WriteLine(line);
                        id++;
                    }
                }
            }

            File.Delete("izvestaji.txt");
            File.Move(tempFile, "izvestaji.txt");
        }

        public List<String> CitanjeIzvestaja()
        {
            List<String> lines = new List<string>();
            lines = File.ReadAllLines("izvestaji.txt").ToList();
            return lines;

            StreamReader sr = new StreamReader("izvestaji.txt");
            string line = "";

            while ((line = sr.ReadLine()) != null)
            {
                string[] components = line.Split("/".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            }

            sr.Close();
        }
    }
}
