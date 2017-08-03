using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accord;
using Accord.Statistics;
using Accord.Statistics.Models.Regression.Linear;


namespace Vizn
{
    public enum RegressionType
    {
        Linear,
        Poly

    }
    class Calculations
    {
        public static SimpleLinearRegression Linear(ReportCollection rc)
        {
            OrdinaryLeastSquares ols = new OrdinaryLeastSquares();
            var Opens = rc.Opens().ToArray();
            var Dates = new double[Opens.Length];

            var count = Dates.Length;

            for (int i = 0; i < count; i++)
            {
                Dates[i] = i;
            }

            SimpleLinearRegression regression = ols.Learn(
                Opens,
                Dates);

            return regression;
        }
    }
}
