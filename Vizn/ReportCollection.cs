using System;
using System.Collections.Generic;
using System.Linq;

namespace Vizn
{
    internal class ReportCollection
    {
        public int Count;
        internal List<DailyReport> DailyReports;

        /// <summary>
        ///     Default constructor.
        /// </summary>
        public ReportCollection()
        {
            DailyReports = new List<DailyReport>();
        }

        /// <summary>
        ///     Adds DailyReport to internal list of reports.
        /// </summary>
        /// <param name="dr">Daily report to add.</param>
        public void Add(DailyReport dr)
        {
            DailyReports.Add(dr);
            Count = DailyReports.Count;
        }

        /// <summary>
        ///     Removes DailyReport from internal list of reports.
        /// </summary>
        /// <param name="dr">DailyReport to remove.</param>
        public void Remove(DailyReport dr)
        {
            DailyReports.Remove(dr);
            Count = DailyReports.Count;
        }

        /// <summary>
        ///     Returns internal list of DailyReports.
        /// </summary>
        /// <returns></returns>
        public List<DailyReport> GetDailyReports()
        {
            return DailyReports;
        }

        /// <summary>
        ///     Return IEnumerable of dates in internal list of DailyReports.
        /// </summary>
        /// <returns>IEnumerable of dates.</returns>
        public IEnumerable<DateTime> Dates()
        {
            return DailyReports.Select(dr => dr.Date);
        }

        /// <summary>
        ///     Return IEnumerable of open prices in internal list of DailyReports.
        /// </summary>
        /// <returns>IEnumerable of open prices.</returns>
        public IEnumerable<double> Opens()
        {
            return DailyReports.Select(dr => dr.Open);
        }

        /// <summary>
        ///     Return IEnumerable of high prices in internal list of DailyReports.
        /// </summary>
        /// <returns>IEnumerable of high prices.</returns>
        public IEnumerable<double> Highs()
        {
            return DailyReports.Select(dr => dr.High);
        }

        /// <summary>
        ///     Return IEnumerable of low prices in internal list of DailyReports.
        /// </summary>
        /// <returns>IEnumerable of low prices.</returns>
        public IEnumerable<double> Lows()
        {
            return DailyReports.Select(dr => dr.Low);
        }

        /// <summary>
        ///     Return IEnumerable of closing prices in internal list of DailyReports.
        /// </summary>
        /// <returns>IEnumerable of closing prices.</returns>
        public IEnumerable<double> Closes()
        {
            return DailyReports.Select(dr => dr.Close);
        }

        /// <summary>
        ///     Return IEnumerable of volume of trades in internal list of DailyReports.
        /// </summary>
        /// <returns>IEnumerable of volume of trades.</returns>
        public IEnumerable<int> Volumes()
        {
            return DailyReports.Select(dr => dr.Volume);
        }

        /// <summary>
        ///     Return IEnumerable of difference between open and close prices in internal list of DailyReports.
        /// </summary>
        /// <returns>IEnumerable of difference between open and close prices.</returns>
        public IEnumerable<double> Changes()
        {
            return DailyReports.Select(dr => dr.Change);
        }

        /// <summary>
        ///     Returns lowest opening price in internal list of DailyReports.
        /// </summary>
        /// <returns>Lowest price.</returns>
        public double MinOpen()
        {
            var min = DailyReports[0].Open;
            min = DailyReports.Select(dr => dr.Open).Concat(new[] {min}).Min();
            return min;
        }
    }
}