using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjekatSIMS.Package1.Repozitorijum;

namespace ProjekatSIMS.Package1.Servis
{
    class PrioritetZakazivanjaLekar : NalazenjeTermina
    {

        public List<string> NadjiTermin(string filter)
        {
            List<String> slobodniTermini = new List<String>();


            int br = 0;
            using (var sr = new System.IO.StreamReader("termini.txt"))
            {
                string line;
                DateTime ter = DateTime.Now;

                while ((line = sr.ReadLine()) != null)
                {
                    String[] termin = line.Split('/');

                    if (termin[2].Equals(filter))
                    {
                        br++;

                        String[] dat = termin[0].Split('.');
                        String datum = dat[2] + "/" + dat[1] + "/" + dat[0];
                        String vreme = termin[1] + ":00";
                        String d = datum + " " + vreme;
                        DateTime t2 = DateTime.Now;
                        Convert.ChangeType("2020/12/31 23:00", typeof(DateTime));
                        DateTime parsedDate = DateTime.Parse(d);


                        using (var sr2 = new System.IO.StreamReader("termini.txt"))
                        {

                            String datum2 = "";
                            String vreme2 = "";

                            DateTime parsedDate33 = DateTime.Parse("2100/2/1 00:00:00");
                            TimeSpan span = parsedDate33.Subtract(parsedDate);

                            int i = 0;
                            while ((line = sr2.ReadLine()) != null)
                            {

                                String[] termin2 = line.Split('/');

                                String[] dat2 = termin2[0].Split('.');
                                datum2 = dat2[2] + "/" + dat2[1] + "/" + dat2[0];
                                vreme2 = termin2[1] + ":00";
                                String d2 = datum2 + " " + vreme2;


                                Convert.ChangeType("2020/12/31 23:00", typeof(DateTime));
                                DateTime parsedDate2 = DateTime.Parse(d2);

                                if (termin[0].Equals(termin2[0]) && termin[2].Equals(termin2[2]))
                                {

                                    if (DateTime.Compare(parsedDate, parsedDate2) < 0)
                                    {
                                        if (DateTime.Compare(parsedDate.AddMinutes(30), parsedDate2) != 0)
                                        {

                                            slobodniTermini.Add(parsedDate.AddMinutes(30).ToString());

                                        }
                                        i++;
                                    }
                                    else if (DateTime.Compare(parsedDate, parsedDate2) > 0)
                                    {
                                        if (DateTime.Compare(parsedDate2.AddMinutes(30), parsedDate) != 0)
                                        {
                                            slobodniTermini.Add(parsedDate2.AddMinutes(30).ToString());
                                        }
                                        i++;
                                    }


                                }

                                if (i == 0)
                                {
                                    String[] t = termin[0].Split('.');
                                    DateTime parsedDate332 = DateTime.Parse(t[2] + "/" + t[1] + "/" + t[0] + " " + "08:00:00");
                                    if (DateTime.Compare(parsedDate, parsedDate332) != 0)
                                    {
                                        slobodniTermini.Add(parsedDate332.ToString());
                                        i++;
                                    }
                                    else
                                    {
                                        slobodniTermini.Add(parsedDate332.AddMinutes(30).ToString());
                                        i++;
                                    }

                                }
                                else if (i < 3)
                                {
                                    slobodniTermini.Add(parsedDate.AddMinutes(i * 30).ToString());

                                    slobodniTermini.Add(parsedDate.AddMinutes(i * 30 + 30).ToString());
                                    ;

                                    i += 2;
                                }

                            }



                        }


                    }

                }
                if (br == 0)
                {

                    String[] t = DateTime.Now.AddDays(1).ToString().Split(' ');
                    DateTime parsedDate332 = DateTime.Parse(t[0] + " " + "08:00:00");
                    slobodniTermini.Add(parsedDate332.ToString());
                    slobodniTermini.Add(parsedDate332.AddMinutes(30).ToString());
                    slobodniTermini.Add(parsedDate332.AddMinutes(60).ToString());

                }

            }
            return slobodniTermini;
        }
    }
}
