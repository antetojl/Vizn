using System;

namespace Vizn
{
    internal class DailyReport
    {
        public double Change;
        public double Close;
        public DateTime Date;
        public double High;
        public double Low;
        public double Open;
        public int Volume;

        /// <summary>
        ///     Public constructor.
        /// </summary>
        /// <param name="date">Date of stock data.</param>
        /// <param name="open">Opening price of stock data.</param>
        /// <param name="high">High price of stock data.</param>
        /// <param name="low">Low price of stock data.</param>
        /// <param name="close">Closing price of stock data.</param>
        /// <param name="volume">Volume of trades of stock data.</param>
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