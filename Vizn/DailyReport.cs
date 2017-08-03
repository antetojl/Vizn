using System;

namespace Vizn
{
    internal class DailyReport
    {
        public DateTime Date;
        public double Open;
        public double High;
        public double Low;
        public double Close;
        public int Volume;
        public double Change;

        public DailyReport(DateTime date, double open, double high, double low, double close, int volume)
        {
            Date = date;
            Open = open;
            High = high;
            Low = low;
            Close = close;
            Volume = volume;
            Change = (Close - Open) / Open * 100;
        }
    }
}
