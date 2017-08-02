using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using Csv;

namespace Vizn
{
    internal class CSVProcessing
    {
        internal static ReportCollection GetReportCollection(IEnumerable<ICsvLine> csv)
        {
            ReportCollection rc = new ReportCollection();
            try
            {
                using (var ie = csv.GetEnumerator())
                {
                    while (ie.MoveNext())
                    {
                        var dateString = ie.Current[0].Split('-');
                        int day = int.Parse(dateString[0]);
                        int month = MonthParser(dateString[1]);
                        int year = 2000 + int.Parse(dateString[2]);

                        DailyReport dr = new DailyReport(
                            new DateTime(year, month, day), //date
                            float.Parse(ie.Current[1]), //open
                            float.Parse(ie.Current[2]), //high
                            float.Parse(ie.Current[3]), //low
                            float.Parse(ie.Current[4]), //close
                            int.Parse(ie.Current[5])); //volume
                        rc.Add(dr);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Error!{0}{0}{1}", Environment.NewLine, ex));
            }

            return rc;

        }

        internal static int MonthParser(string month)
        {
            int monthAsNumber = 0;
            #region switch for month
            switch (month)
            {
                case "Jan":
                    monthAsNumber = 1;
                    break;
                case "Feb":
                    monthAsNumber = 2;
                    break;
                case "Mar":
                    monthAsNumber = 3;
                    break;
                case "Apr":
                    monthAsNumber = 4;
                    break;
                case "May":
                    monthAsNumber = 5;
                    break;
                case "Jun":
                    monthAsNumber = 6;
                    break;
                case "Jul":
                    monthAsNumber = 7;
                    break;
                case "Aug":
                    monthAsNumber = 8;
                    break;
                case "Sep":
                    monthAsNumber = 9;
                    break;
                case "Oct":
                    monthAsNumber = 10;
                    break;
                case "Nov":
                    monthAsNumber = 11;
                    break;
                case "Dec":
                    monthAsNumber = 12;
                    break;
            }
            #endregion

            return monthAsNumber;
        }

        internal static IEnumerable<ICsvLine> ReadCSV(string file)
        {
            var stream = File.OpenRead(file);
            var options = new CsvOptions
            {
                HeaderMode = HeaderMode.HeaderPresent,
            };

            return CsvReader.ReadFromStream(stream, options);
        }
    }
}
