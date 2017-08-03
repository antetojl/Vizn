using System;
using System.Collections.Generic;
using System.Linq;

namespace Vizn
{
    internal class ReportCollection
    {
        public List<DailyReport> DailyReports;
        public int Count;

        public ReportCollection()
        {
            DailyReports =  new List<DailyReport>();
        }

        public void Add(DailyReport dr)
        {
            DailyReports.Add(dr);
            Count = DailyReports.Count;
        }

        public void Remove(DailyReport dr)
        {
            DailyReports.Remove(dr);
            Count = DailyReports.Count;
        }

        public List<DailyReport> GetDailyReports()
        {
            return DailyReports;
        }

        public IEnumerable<DateTime> Dates()
        {
            return DailyReports.Select(dr => dr.Date);
        }

        public IEnumerable<double> Opens()
        {
            return DailyReports.Select(dr => dr.Open);
        }

        public IEnumerable<double> Highs()
        {
            return DailyReports.Select(dr => dr.High);
        }

        public IEnumerable<double> Lows()
        {
            return DailyReports.Select(dr => dr.Low);
        }

        public IEnumerable<double> Closes()
        {
            return DailyReports.Select(dr => dr.Close);
        }

        public IEnumerable<int> Volumes()
        {
            return DailyReports.Select(dr => dr.Volume);
        }

        public IEnumerable<double> Changes()
        {
            return DailyReports.Select(dr => dr.Change);
        }

        public double MinOpen()
        {
            var min = DailyReports[0].Open;
            min = DailyReports.Select(dr => dr.Open).Concat(new[] { min }).Min();
            return min;
        }
    }
}
