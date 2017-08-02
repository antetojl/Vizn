using System;

namespace Vizn
{
    internal class DailyReport
    {
        public DateTime Date;
        public float Open;
        public float High;
        public float Low;
        public float Close;
        public int Volume;
        public float Change;

        public DailyReport(DateTime date, float open, float high, float low, float close, int volume)
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
