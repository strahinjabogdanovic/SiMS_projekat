using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace ProjekatSIMS
{
    public class IzvestajViewModel : ValidationBase
    {
        public IzvestajViewModel()
        {
            prikaziIzvestaj = new RelayCommand(Execute_PrikaziIzvestaj, CanExecute_Command);
            PocetniDatum = DateTime.Now;
            KrajnjiDatum = DateTime.Now;
        }

        public RelayCommand prikaziIzvestaj { get; set; }
        List<string> data = new List<string>();
        PdfPTable table = new PdfPTable(4);

        private DateTime pocetniDatum { get; set; }
        public DateTime PocetniDatum
        {
            get { return pocetniDatum; }
            set
            {
                pocetniDatum = value;
                OnPropertyChanged();
            }
        }

        private DateTime krajnjiDatum { get; set; }
        public DateTime KrajnjiDatum
        {
            get { return krajnjiDatum; }
            set
            {
                krajnjiDatum = value;
                OnPropertyChanged();
            }
        }

        protected override void ValidateSelf()
        {
            throw new NotImplementedException();
        }

        private void Execute_PrikaziIzvestaj(object obj)
        {
            FileStream fs = new FileStream("Pregledi.pdf", FileMode.Create, FileAccess.Write, FileShare.None);
            iTextSharp.text.Rectangle rec = new iTextSharp.text.Rectangle(PageSize.A4);
            Document doc = new Document(rec);
            PdfWriter pdfwriter = PdfWriter.GetInstance(doc, fs);
            BaseFont bfTimes = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, false);
            Font titleFont = new Font(bfTimes, 16);
            iTextSharp.text.Paragraph title = new iTextSharp.text.Paragraph("Izvestaj zakaznih pregleda u zeljenom terminu", titleFont);
            title.Alignment = Element.ALIGN_CENTER;

            iTextSharp.text.Paragraph blanc = new iTextSharp.text.Paragraph("    ", titleFont);

            doc.Open();
            doc.Add(title);
            doc.Add(blanc);
            getUsageData();
            fillTable();
            doc.Add(table);
            doc.Close();
            MessageBox.Show("PDF je kreiran.");
        }

        public void getUsageData()
        {
            using (var sr = new StreamReader("termini.txt"))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    String[] termin = line.Split('/');
                    if (termin[5].Equals("Ana Markovic"))
                    {
                        String[] datum = termin[0].Split('.');
                        DateTime dt1 = DateTime.Parse(datum[1] + "/" + datum[0] + "/" + datum[2] + " " + termin[1] + ":00");
                        if (dt1.CompareTo(PocetniDatum) > 0 && dt1.CompareTo(KrajnjiDatum) < 0)
                        {
                            data.Add(termin[0]);
                            data.Add(termin[1]);
                            data.Add(termin[2]);
                            data.Add(termin[3]);
                        }
                    }

                }

            }

        }

        public void fillTable()
        {

            PdfPHeaderCell dateHeader = new PdfPHeaderCell();
            PdfPHeaderCell timeHeader = new PdfPHeaderCell();
            PdfPHeaderCell doctorHeader = new PdfPHeaderCell();
            PdfPHeaderCell roomHeader = new PdfPHeaderCell();
            dateHeader.Phrase = new Phrase("Datum");
            timeHeader.Phrase = new Phrase("Vreme");
            doctorHeader.Phrase = new Phrase("Lekar");
            roomHeader.Phrase = new Phrase("Soba");

            table.AddCell(dateHeader);
            table.AddCell(timeHeader);
            table.AddCell(doctorHeader);
            table.AddCell(roomHeader);

            foreach (string s in data)
            {
                PdfPCell cell = new PdfPCell(new Phrase(s));
                table.AddCell(cell);
            }

        }

        private bool CanExecute_Command(object obj)
        {
            return true;
        }

    }
}

