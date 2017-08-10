using System.Linq;
using Accord.Statistics.Models.Regression.Linear;

namespace Vizn
{
    /// <summary>
    ///     Enumerable for linear/polynomial regressions.
    /// </summary>
    public enum RegressionType
    {
        Linear,
        Poly
    }

    internal class Calculations
    {
        /// <summary>
        ///     Returns a linear regression object for a ReportCollection, rc.
        /// </summary>
        /// <param name="rc">Report collection to create regression from.</param>
        /// <returns>Regression line.</returns>
        public static SimpleLinearRegression Linear(ReportCollection rc)
        {
            var ols = new OrdinaryLeastSquares();
            var Opens = rc.Opens().ToArray();
            var Dates = new double[Opens.Length];

            var count = Dates.Length;

            for (var i = 0; i < count; i++)
            {
                Dates[i] = i;
            }

            var regression = ols.Learn(
                Opens,
                Dates);

            return regression;
        }
    }
}