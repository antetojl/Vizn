using System;
using System.Collections.Generic;
using System.Linq;

namespace Vizn
{
    internal class ReportCollection
    {
        private readonly List<DailyReport> _dailyReports;

        public ReportCollection()
        {
            _dailyReports =  new List<DailyReport>();
        }

        public void Add(DailyReport dr)
        {
            _dailyReports.Add(dr);
        }

        public void Remove(DailyReport dr)
        {
            _dailyReports.Remove(dr);
        }

        public List<DailyReport> GetDailyReports()
        {
            return _dailyReports;
        }

        public IEnumerable<DateTime> Dates()
        {
            return _dailyReports.Select(dr => dr.Date);
        }

        public IEnumerable<float> Opens()
        {
            return _dailyReports.Select(dr => dr.Open);
        }

        public IEnumerable<float> Highs()
        {
            return _dailyReports.Select(dr => dr.High);
        }

        public IEnumerable<float> Lows()
        {
            return _dailyReports.Select(dr => dr.Low);
        }

        public IEnumerable<float> Closes()
        {
            return _dailyReports.Select(dr => dr.Close);
        }

        public IEnumerable<int> Volumes()
        {
            return _dailyReports.Select(dr => dr.Volume);
        }

        public IEnumerable<float> Changes()
        {
            return _dailyReports.Select(dr => dr.Change);
        }
    }
}
