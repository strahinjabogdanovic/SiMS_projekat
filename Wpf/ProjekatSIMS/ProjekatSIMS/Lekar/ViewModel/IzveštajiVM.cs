using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using ProjekatSIMS.Lekar.View;
using ProjekatSIMS.Package1.Model;
using ProjekatSIMS.Package1.Repozitorijum;
using ProjekatSIMS.Package1.Servis;

using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Windows;

namespace ProjekatSIMS.Lekar.ViewModel
{
    class IzveštajiVM : ViewModels
    {
        public ObservableCollection<MedIzvestaj> Izvopr { get; set; }

        private DataGrid tabela = new DataGrid();
        public string TJmbg { get; set; }
        public RelayCommand Izmeni { get; set; }
        public RelayCommand Nazad { get; set; }
        private Izveštaji page;
        public RelayCommand PDF { get; set; }

        PdfPTable table = new PdfPTable(4);

        List<string> data = new List<string>();

        public IzveštajiVM(Izveštaji izv, DataGrid dg, string jmbg)
        {
            tabela = dg;
            TJmbg = jmbg;
            page = izv;
            Izvopr = new ObservableCollection<MedIzvestaj>();
            LekarServis ifs = new LekarServis();
            Izvopr = ifs.NadjiIzvestaje(jmbg);

            PridruzivanjeMetodaKomandama();
        }
        private void PridruzivanjeMetodaKomandama()
        {
            Izmeni = new RelayCommand(Izmeni_Click, CanExecute_NavigateCommand);
            Nazad = new RelayCommand(Nazad_Click, CanExecute_NavigateCommand);
            PDF = new RelayCommand(PDF_Click);
        }
        private void Izmeni_Click(object obj)
        {

            if (tabela.SelectedItem == null)
            {
                //Prikazi tooltip
            }

            int currentRowIndex = tabela.Items.IndexOf(tabela.SelectedItem);
            IzvestajiFileStorage ifs = new IzvestajiFileStorage();
            ifs.Izmeni(currentRowIndex, tabela);
        }
        private void Nazad_Click(object obj)
        {
            page.NavigationService.Navigate(new KartonPacijenta(TJmbg));
        }
        public bool CanExecute_NavigateCommand(object obj)
        {
            return true;
        }

        private void PDF_Click(object obj)
        {
            FileStream fs = new FileStream("IzvestajiOPregleduStanja.pdf", FileMode.Create, FileAccess.Write, FileShare.None);
            iTextSharp.text.Rectangle rec = new iTextSharp.text.Rectangle(PageSize.A4);
            Document doc = new Document(rec);
            PdfWriter pdfwriter = PdfWriter.GetInstance(doc, fs);
            BaseFont bfTimes = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, false);
            Font titleFont = new Font(bfTimes, 16);
            iTextSharp.text.Paragraph title = new iTextSharp.text.Paragraph("Izvestaj o pregledu stanja pacijenta", titleFont);
            title.Alignment = Element.ALIGN_CENTER;

            iTextSharp.text.Paragraph blanc = new iTextSharp.text.Paragraph("    ", titleFont);

            doc.Open();
            doc.Add(title);
            doc.Add(blanc);
            fillTable();
            doc.Add(table);
            doc.Close();
            MessageBox.Show("PDF je kreiran.");

        }
        public void fillTable()
        {

            PdfPHeaderCell vrstaHeader = new PdfPHeaderCell();
            PdfPHeaderCell timeHeader = new PdfPHeaderCell();
            PdfPHeaderCell odeljenjeHeader = new PdfPHeaderCell();
            PdfPHeaderCell nalazHeader = new PdfPHeaderCell();
            PdfPHeaderCell kontrolaHeader = new PdfPHeaderCell();
            PdfPHeaderCell terapijaHeader = new PdfPHeaderCell();


            vrstaHeader.Phrase = new Phrase("Vrsta");
            timeHeader.Phrase = new Phrase("Datum");
            odeljenjeHeader.Phrase = new Phrase("Odeljenje");
            nalazHeader.Phrase = new Phrase("Nalaz");
            kontrolaHeader.Phrase = new Phrase("Kontrola");
            terapijaHeader.Phrase = new Phrase("Terapija");


            table.AddCell(vrstaHeader);
            table.AddCell(timeHeader);
            table.AddCell(odeljenjeHeader);
            table.AddCell(nalazHeader);
            table.AddCell(kontrolaHeader);
            table.AddCell(terapijaHeader);


            foreach (string s in data)
            {
                PdfPCell cell = new PdfPCell(new Phrase(s));
                table.AddCell(cell);
            }

        }
    }
}
