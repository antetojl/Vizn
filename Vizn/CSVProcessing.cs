using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using Csv;

namespace Vizn
{
    internal class CSVProcessing
    {
        /// <summary>
        ///     Takes in enumerable of csv file., and returns ReportCollection object that is an object entity of the csv file.
        /// </summary>
        /// <param name="csv">Enumerable of CSV file.</param>
        /// <returns>ReportCollection of DailyReport entities.</returns>
        internal static ReportCollection GetReportCollection(IEnumerable<ICsvLine> csv)
        {
            var rc = new ReportCollection();
            try
            {
                using (var ie = csv.GetEnumerator())
                {
                    while (ie.MoveNext())
                    {
                        //makes sure no fields are empty
                        if (ie.Current[0] == null || ie.Current[1] == null || ie.Current[2] == null ||
                            ie.Current[3] == null || ie.Current[4] == null || ie.Current[5] == null)
                        {
                            continue;
                        }

                        var dateString = ie.Current[0].Split('-');
                        var day = int.Parse(dateString[0]);
                        var month = MonthParser(dateString[1]);
                        var year = 2000 + int.Parse(dateString[2]);

                        //create DailyReport from csv IEnumerable
                        var dr = new DailyReport(
                            new DateTime(year, month, day), //date
                            double.Parse(ie.Current[1]), //open
                            double.Parse(ie.Current[2]), //high
                            double.Parse(ie.Current[3]), //low
                            double.Parse(ie.Current[4]), //close
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

        /// <summary>
        ///     Converts month as abbreviation to number of month.
        /// </summary>
        /// <param name="month">Abbreviation of month.</param>
        /// <returns>Integer representing month #.</returns>
        internal static int MonthParser(string month)
        {
            var monthAsNumber = 0;

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

        /// <summary>
        ///     Helper method to read csv file.
        /// </summary>
        /// <param name="file">Filepath of csv file.</param>
        /// <returns>IEnumerable of ICsvLines that have been read.</returns>
        internal static IEnumerable<ICsvLine> ReadCSV(string file)
        {
            var stream = File.OpenRead(file);
            var options = new CsvOptions
            {
                HeaderMode = HeaderMode.HeaderPresent
            };

            return CsvReader.ReadFromStream(stream, options);
        }
    }
}